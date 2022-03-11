using UnityEngine;
using Leopotam.Ecs;

public class SMoveForward : IEcsRunSystem{
	private EcsFilter<CMoveForward> f = null;

	public void Run(){
		foreach (var i in f){
			ref var c = ref f.Get1(i);
			c.Moving?.Translate(new Vector3(c.Speed * Time.deltaTime, 0, 0));
		}
	}
}