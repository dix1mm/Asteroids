using UnityEngine;
using Leopotam.Ecs;

public class SPlayerSearcher : IEcsRunSystem{
	private EcsFilter<CPlayer> fPlayers = null;
	private EcsFilter<CMoveChase> fChasers = null;

	public void Run(){
		foreach (var i in fPlayers){
			ref var cPlayer = ref fPlayers.Get1(i);
			foreach (var j in fChasers){
				ref var cChaser = ref fChasers.Get1(j);
				cChaser.ChaseTarget = cPlayer.PlayerTransform;
			}
		}
	}
}