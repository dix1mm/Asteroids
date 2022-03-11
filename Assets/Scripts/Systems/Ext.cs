using UnityEngine;
using System;
using Leopotam.Ecs;

public static class GameObjectExt{
	public static EntityReference GetEntityReference(this GameObject go) => go.GetComponent<EntityReference>();
	public static ref EcsEntity GetEntity(this GameObject go) => ref go.GetComponent<EntityReference>().Entity;
}