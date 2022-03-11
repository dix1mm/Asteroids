using UnityEngine;
using Leopotam.Ecs;

public class SRotation : IEcsRunSystem{
	private EcsFilter<CRotation> f = null;

	public void Run(){
		foreach (var i in f){
			ref var c = ref f.Get1(i);
			c.Moving?.Rotate(new Vector3(0, 0, c.Speed * Time.deltaTime));
		}
	}
}