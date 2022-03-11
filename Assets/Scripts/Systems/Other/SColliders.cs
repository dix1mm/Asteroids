using UnityEngine;
using Leopotam.Ecs;

public class SColliders : IEcsRunSystem{
	private enum ColliderType{
		None,
		Player,
		Enemy,
		Shot
	}

	private EcsFilter<ETriggerEnter> f = null;

	public void Run(){
		foreach (var i in f){
			ref var enterEvent = ref f.Get1(i);
			GameObject go1 = enterEvent.GO1;
			GameObject go2 = enterEvent.GO2;
			if ((go1 == null) || (go2 == null)) continue;
			EntityReference eRef1 = go1.GetEntityReference();
			EntityReference eRef2 = go2.GetEntityReference();
			if ((!eRef1.Initialized) || (!eRef2.Initialized)) continue;
			ref EcsEntity e1 = ref eRef1.Entity;
			ref EcsEntity e2 = ref eRef2.Entity;
			processCollision(go1, getCT(e1), go2, getCT(e2));
		}
	}

	private ColliderType getCT(EcsEntity e){
		if (e.Has<CPlayer>())
			return ColliderType.Player;
		if (e.Has<CEnemy>())
			return ColliderType.Enemy;
		if (e.Has<CShot>())
			return ColliderType.Shot;
		return ColliderType.None;
	}

	private void processCollision(GameObject go1, ColliderType ct1, GameObject go2, ColliderType ct2){
		if (ct1 == ColliderType.Player && ct2 == ColliderType.Enemy)
			collisionPlayerEnemy(go1, go2);
		if (ct2 == ColliderType.Player && ct1 == ColliderType.Enemy)
			collisionPlayerEnemy(go2, go1);
		if (ct1 == ColliderType.Shot && ct2 == ColliderType.Enemy)
			collisionShotEnemy(go1, go2);
		if (ct2 == ColliderType.Shot && ct1 == ColliderType.Enemy)
			collisionShotEnemy(go2, go1);
	}

	private void collisionPlayerEnemy(GameObject player, GameObject enemy){
		UnityEventGenerator.Generate(UEvent.GameOver);
	}

	private void collisionShotEnemy(GameObject shot, GameObject enemy){
		ref EcsEntity eShot = ref shot.GetEntity();
		ref EcsEntity eEnemy = ref enemy.GetEntity();
		
		if (eShot.Has<CWeaponPowerful>()){//лазер
			Object.Destroy(enemy);
			eEnemy.Destroy();
			return;
		}
		
		Object.Destroy(shot);
		eShot.Destroy();
		if (eEnemy.Has<CDeathSegmentation>()){//астероид
			/*
				возможно эту логику надо было вынести в отдельную систему, а тут оставлять после себя пустышку флаг
				лишняя привязка получается
			*/
			ref var segmentation = ref eEnemy.Get<CDeathSegmentation>();
			for (int i=0;i<segmentation.SegmentsCount;i++)
				Object.Instantiate(
					segmentation.Segment,
					segmentation.Parent.transform.position,
					Quaternion.Euler(0, 0, i*(360/segmentation.SegmentsCount))
				);
		}
		Object.Destroy(enemy);
		eEnemy.Destroy();
	}
}