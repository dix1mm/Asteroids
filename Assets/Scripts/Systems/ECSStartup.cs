using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

public class ECSStartup : MonoBehaviour{
	private EcsWorld _world;
	private EcsSystems _systems;

	private void systemsAdd(){
		_systems
			.Add(new SMoveForward())//передвижение вперед
			.Add(new SMoveChase())//передвижение тарелки
			.Add(new SMoveInput())//передвижение игрока (не уверен стоило ли их разбивать на несколько систем, с одной стороны кастомизация, с другой через чур много систем)
			.Add(new SSlowdown())//замедление (активное и пассивное) игрока
			.Add(new SAcceleration())//набор скорости для игрока
			.Add(new SRotation())//повороты всех сущностей (пока только игрока)

			.Add(new SGun())//выстрел из пушки
			.Add(new SLaser())//выстрел из лазера

			.Add(new SColliders())//все столкновения
			.Add(new SSpawn())//спавн астероидов и тарелок
			.Add(new SPortal())//телепорт при входе за границу экрана
			.Add(new SLifetime())//время жизни выстрелов
			//ui
			//поражение
		;
	}

	private void systemsAddOneFrame(){
		_systems
			.OneFrame<EInputFire>()
			.OneFrame<EInputFireAlt>()
			.OneFrame<EInputAccelerationStarted>()
			.OneFrame<EInputAccelerationStopped>()
			.OneFrame<EInputSlowdownStarted>()
			.OneFrame<EInputSlowdownStopped>()
			.OneFrame<EInputRotationLeftStarted>()
			.OneFrame<EInputRotationLeftStopped>()
			.OneFrame<EInputRotationRightStarted>()
			.OneFrame<EInputRotationRightStopped>()
			.OneFrame<ETriggerEnter>()
		;
	}	
	
	private void Start(){
		_world = new EcsWorld();
		_systems = new EcsSystems(_world);
		_systems.ConvertScene();
		systemsAdd();
		systemsAddOneFrame();
		_systems.Init();
	}

	private void Update(){
		_systems.Run();
	}

	private void OnDestroy(){
		_systems.Destroy();
		_systems = null;
		_world.Destroy();
		_world = null;
	}
}