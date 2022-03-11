using UnityEngine;
using Leopotam.Ecs;

public class SMoveInput : IEcsRunSystem{
	private enum InputOperation{//если кнопка нажата - добавляем компонент, если отпущена - убираем
		None,
		Add,
		Remove
	}

	private EcsFilter<EInputAccelerationStarted> fWStarted = null;
	private EcsFilter<EInputAccelerationStopped> fWStopped = null;
	private EcsFilter<EInputSlowdownStarted> fSStarted = null;
	private EcsFilter<EInputSlowdownStopped> fSStopped = null;
	private EcsFilter<EInputRotationLeftStarted> fAStarted = null;
	private EcsFilter<EInputRotationLeftStopped> fAStopped = null;
	private EcsFilter<EInputRotationRightStarted> fDStarted = null;
	private EcsFilter<EInputRotationRightStopped> fDStopped = null;
	private EcsFilter<CMoveInput> fMoving = null;

	public void Run(){
		/*
			пока нет идей как это упростить, нужно углубляться
			возможно не надо было делать ивенты на каждый инпут
			возможно тут бы пригодилась рефлексия, но я в своем плане обучения еще до этого не дошел
		*/
		InputOperation ioW = getIOW();
		InputOperation ioS = getIOS();
		InputOperation ioA = getIOA();
		InputOperation ioD = getIOD();
		calcMoving(ioW, ioS, ioA, ioD);
	}
	//-------------------------------------------------------------------------ковер под которым можно что-то спрятать
	private InputOperation getIOW(){
		if (fWStarted.GetEntitiesCount() > 0)
			return InputOperation.Add;
		if (fWStopped.GetEntitiesCount() > 0)
			return InputOperation.Remove;
		return InputOperation.None;
	}
	private InputOperation getIOS(){
		if (fSStarted.GetEntitiesCount() > 0)
			return InputOperation.Add;
		if (fSStopped.GetEntitiesCount() > 0)
			return InputOperation.Remove;
		return InputOperation.None;
	}
	private InputOperation getIOA(){
		if (fAStarted.GetEntitiesCount() > 0)
			return InputOperation.Add;
		if (fAStopped.GetEntitiesCount() > 0)
			return InputOperation.Remove;
		return InputOperation.None;
	}
	private InputOperation getIOD(){
		if (fDStarted.GetEntitiesCount() > 0)
			return InputOperation.Add;
		if (fDStopped.GetEntitiesCount() > 0)
			return InputOperation.Remove;
		return InputOperation.None;
	}

	private void calcMoving(InputOperation ioW, InputOperation ioS, InputOperation ioA, InputOperation ioD){
		foreach (var i in fMoving){
			ref var cMoveInput = ref fMoving.Get1(i);
			ref var e = ref fMoving.GetEntity(i);

			if (ioW == InputOperation.Add){
				ref CAcceleration c = ref e.Get<CAcceleration>();
				c.MaxSpeed = cMoveInput.MaxSpeed;
				c.AccelerationSpeed = cMoveInput.AccelerationSpeed;
			}
			if (ioW == InputOperation.Remove)
				e.Del<CAcceleration>();

			if (ioS == InputOperation.Add){
				ref CSlowdown c = ref e.Get<CSlowdown>();
				c.Speed = cMoveInput.SlowdownSpeed;
			}
			if (ioS == InputOperation.Remove)
				e.Del<CSlowdown>();
				
			if (ioA == InputOperation.Add){
				ref CRotation c = ref e.Get<CRotation>();
				c.Moving = cMoveInput.TransformLink;
				c.Speed = cMoveInput.RotationSpeed;
			}
			if (ioA == InputOperation.Remove)
				e.Del<CRotation>();
				
			if (ioD == InputOperation.Add){
				ref CRotation c = ref e.Get<CRotation>();
				c.Moving = cMoveInput.TransformLink;
				c.Speed = -cMoveInput.RotationSpeed;
			}
			if (ioD == InputOperation.Remove)
				e.Del<CRotation>();
		}
	}	
	//-------------------------------------------------------------------------конец ковра
}