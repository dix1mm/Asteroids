using UnityEngine;
using Leopotam.Ecs;

public class SLifetime : IEcsRunSystem{
	private EcsFilter<CLifetime> f = null;

	public void Run(){
		foreach (var i in f){
			ref var c = ref f.Get1(i);
			c.Val -= Time.deltaTime;
			if (c.Val <= 0)
				Object.Destroy(c.Target);
		}
	}
}