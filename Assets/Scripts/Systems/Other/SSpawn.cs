using UnityEngine;
using Leopotam.Ecs;

public class SSpawn : IEcsRunSystem{
	private EcsFilter<CSpawn> f = null;

	public void Run(){
		foreach (var i in f){
			ref var c = ref f.Get1(i);
			c.CurrCd -= Time.deltaTime;
			if (c.CurrCd <= 0){
				Object.Instantiate(c.Unit, c.SpawnPlace.position, Quaternion.Euler(0, 0, getRandomAngle()));
				c.CurrCd = c.Cd;
			}
		}
	}

	private float getRandomAngle() => UnityEngine.Random.Range(0,360);
}