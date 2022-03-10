using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

public static class ECSEventGenerator{
	public static void Generate<T>(in T ecsEvent) where T : struct{
		var world = WorldHandler.GetWorld();
		var entity = world.NewEntity();
		entity.Get<T>() = ecsEvent;
	}
}