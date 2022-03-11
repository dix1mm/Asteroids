using UnityEngine;
using Leopotam.Ecs;

public class SPortal : IEcsRunSystem{
	private const float border = 0.5f, minX = -9, maxX = 9, minY = -5, maxY = 5;

	private EcsFilter<CAffectedByPortal> f = null;

	public void Run(){
		foreach (var i in f){
			ref var c = ref f.Get1(i);
			Vector3 pos = c.Target.position;
			if (pos.x < minX)
				pos.x = maxX - border;
			if (pos.x > maxX)
				pos.x = minX + border;
			if (pos.y < minY)
				pos.y = maxY - border;
			if (pos.y > maxY)
				pos.y = minY + border;
			c.Target.position = pos;
		}
	}
}