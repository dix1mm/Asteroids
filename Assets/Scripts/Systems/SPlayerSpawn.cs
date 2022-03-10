using UnityEngine;
using Leopotam.Ecs;

public class SPlayerSpawn : IEcsInitSystem{
	private EcsFilter<CGameoverIfKilled> fPlayer = null;

	public void Init(){
		foreach (var i in fPlayer){
			Debug.Log(1);
			//ref var entity = ref playerFilter.GetEntity(i);
			//entity.Get<JumpEvent>();
		}
	}
}