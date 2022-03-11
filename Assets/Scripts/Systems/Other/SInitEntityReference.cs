using UnityEngine;
using Leopotam.Ecs;

public class SInitEntityReference : IEcsRunSystem{//не init потому что есть враги, появляющиеся не сразу
	private EcsFilter<CInitEntityReference> f = null;
	
	public void Run(){
		foreach (var i in f){
			ref var e = ref f.GetEntity(i);
			ref var c = ref f.Get1(i);
			c.Target.Entity = e;
			c.Target.Initialized = true;
		}
	}
}