using UnityEngine;
using Leopotam.Ecs;

//[RequireComponent(typeof(PCInitEntityReference))] тут так делать нельзя, ecs удаляет в своем порядке
public class EntityReference : MonoBehaviour{
	public EcsEntity Entity;
	[HideInInspector] public bool Initialized = false;
}