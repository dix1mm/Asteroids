using UnityEngine;

[System.Serializable] public struct CGun{
	public Transform User;
	public GameObject Shot;
	public float Cd;
	[HideInInspector] public float CurrCd;
}

public sealed class PCGun : Voody.UniLeo.MonoProvider<CGun>{}