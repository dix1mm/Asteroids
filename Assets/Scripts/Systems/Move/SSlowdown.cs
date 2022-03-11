using UnityEngine;
using Leopotam.Ecs;

public class SSlowdown : IEcsRunSystem{
	private EcsFilter<CMoveForward, CSlowdown> fActive = null;
	private EcsFilter<CMoveForward, CSlowdownPassive> fPassive = null;

	public void Run(){
		foreach (var i in fActive){
			ref var cMove = ref fActive.Get1(i);
			ref var cSlow = ref fActive.Get2(i);
			cMove.Speed = Mathf.Max(cMove.Speed - cSlow.Speed * Time.deltaTime, 0);
		}
		foreach (var i in fPassive){
			ref var cMove = ref fPassive.Get1(i);
			ref var cSlow = ref fPassive.Get2(i);
			cMove.Speed = Mathf.Max(cMove.Speed - cSlow.Speed * Time.deltaTime, 0);
		}
	}
}