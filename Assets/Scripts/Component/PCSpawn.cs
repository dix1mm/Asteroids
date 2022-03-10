using UnityEngine;

[System.Serializable] public struct CSpawn{
	public Transform SpawnPlace;
	public GameObject Unit;
	public float Cd;
	[HideInInspector] public float CurrCd;
}

public sealed class PCSpawn : Voody.UniLeo.MonoProvider<CSpawn>{}