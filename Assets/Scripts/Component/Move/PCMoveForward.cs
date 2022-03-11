using UnityEngine;

[System.Serializable] public struct CMoveForward{
	public Transform Moving;
	public float Speed;
}

public sealed class PCMoveForward : Voody.UniLeo.MonoProvider<CMoveForward>{}