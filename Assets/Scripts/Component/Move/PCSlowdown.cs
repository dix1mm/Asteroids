using UnityEngine;

[System.Serializable] public struct CSlowdown{
	public float Speed;
}

public sealed class PCSlowdown : Voody.UniLeo.MonoProvider<CSlowdown>{}