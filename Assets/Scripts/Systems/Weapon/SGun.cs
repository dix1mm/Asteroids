using UnityEngine;
using Leopotam.Ecs;

public class SGun : IEcsRunSystem{
	private EcsFilter<EInputFire> fShooting = null;
	private EcsFilter<CGun> f = null;

	public void Run(){
		decreaseGunTimer();
		foreach (var i in fShooting){
			activateGuns();
			break;
		}
	}

	private void decreaseGunTimer(){
		foreach (var i in f){
			ref var c = ref f.Get1(i);
			c.CurrCd -= Time.deltaTime;
		}
	}

	private void activateGuns(){
		foreach (var i in f){
			ref var c = ref f.Get1(i);
			if (c.CurrCd > 0) return;
			Object.Instantiate(c.Shot, c.User.position, c.User.rotation);
			c.CurrCd = c.Cd;
		}
	}
}