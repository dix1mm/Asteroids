using UnityEngine;

[System.Serializable] public struct CRotation{
	public Transform Moving;
	public float Speed;
}

public sealed class PCRotation : Voody.UniLeo.MonoProvider<CRotation>{}