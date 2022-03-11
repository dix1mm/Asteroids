using UnityEngine;
using Leopotam.Ecs;

public class SAcceleration : IEcsRunSystem{
	private EcsFilter<CMoveForward, CAcceleration> f = null;

	public void Run(){
		foreach (var i in f){
			ref var cMove = ref f.Get1(i);
			ref var cAccel = ref f.Get2(i);
			cMove.Speed = Mathf.Min(cMove.Speed + cAccel.AccelerationSpeed * Time.deltaTime, cAccel.MaxSpeed);
		}
	}
}