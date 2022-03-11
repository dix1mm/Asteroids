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
			ref var c = ref f.Get1(i);
			GameObject go1 = c.Target1;
			GameObject go2 = c.Target2;
			if ((go1 == null) || (go2 == null)) continue;
			processCollision(go1, getCT(go1), go2, getCT(go2));
		}
	}

	private ColliderType getCT(GameObject go){
		/*
			выглядит не очень оптимально
			если подойти к задаче серьезнее, надо бы посмотреть на какие еще инструменты ведут ссылки со страницы гита LeoECS
			мне бы сростить GameObject и Entity, чтобы первый всегда содержал закешированную ссылку на второго и наоборот
			но пока не хочу слишком сильно в это углубляться, пока не будет уверенности что буду с этим серьезно работать
		*/
		if (go.GetComponent<PCPlayer>() != null)
			return ColliderType.Player;
		if (go.GetComponent<PCEnemy>() != null)
			return ColliderType.Enemy;
		if (go.GetComponent<PCShot>() != null)
			return ColliderType.Shot;
		return ColliderType.None;
	}

	private void processCollision(GameObject go1, ColliderType ct1, GameObject go2, ColliderType ct2){
		/*
			опять же, если серьезно, то думаю что сюда нужно вставлять аналог LayerCollisionMatrix
			но делать это ради 3-х сущностей не очень хочется
			возможно подход изначально был выбран не верный и надо было передавать сюда entity а не gameobject
		*/
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
		Debug.Log(player);
		Debug.Log(enemy);
	}

	private void collisionShotEnemy(GameObject shot, GameObject enemy){
		Debug.Log(shot);
		Debug.Log(enemy);
	}
}