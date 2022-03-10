using UnityEngine;
using Leopotam.Ecs;

public class SGun : IEcsRunSystem{
	private EcsFilter<EInputFire> fShooting = null;
	private EcsFilter<CGun> f = null;

	public void Run(){
		foreach (var i in fShooting){
			activateGuns();
			return;
		}
	}

	private void activateGuns(){
		foreach (var i in f){
			ref var c = ref f.Get1(i);
			c.CurrCd -= Time.deltaTime;
			if (c.CurrCd <= 0){
				Object.Instantiate(c.Shot, c.User.position, Quaternion.identity);
				c.CurrCd = c.Cd;
			}
		}
	}
}