using UnityEngine;
using Leopotam.Ecs;

public class SLaser : IEcsRunSystem{
	private EcsFilter<EInputFireAlt> fShooting = null;
	private EcsFilter<CLaser> f = null;

	public void Run(){
		calculateLaserTimer();
		foreach (var i in fShooting){
			activateLasers();
			break;
		}
	}

	private void calculateLaserTimer(){
		foreach (var i in f){
			ref var c = ref f.Get1(i);
			if (c.CurrCharge < c.MaxCharges){
				c.CurrChargeTime += Time.deltaTime;
				if (c.CurrChargeTime >= c.RechargeTime){
					c.CurrChargeTime = 0;
					c.CurrCharge++;
				}
			}else
				c.CurrChargeTime = 0;
			c.CurrCd -= Time.deltaTime;
		}
	}	

	private void activateLasers(){
		foreach (var i in f){
			ref var c = ref f.Get1(i);
			if (c.CurrCharge == 0) return;
			if (c.CurrCd > 0) return;
			Object.Instantiate(c.Shot, c.User.position, c.User.rotation);
			c.CurrCharge--;
			c.CurrCd = c.Cd;
		}
	}
}