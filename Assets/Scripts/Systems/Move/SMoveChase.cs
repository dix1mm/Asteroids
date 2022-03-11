using UnityEngine;
using Leopotam.Ecs;

public class SMoveChase : IEcsRunSystem{
	private EcsFilter<CMoveChase> f = null;

	public void Run(){
		foreach (var i in f){
			ref var c = ref f.Get1(i);
			c.Moving.position = Vector3.MoveTowards(c.Moving.position, c.ChaseTarget.position, c.Speed * Time.deltaTime);
		}
	}
}