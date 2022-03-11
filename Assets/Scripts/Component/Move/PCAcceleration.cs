using UnityEngine;

[System.Serializable] public struct CAcceleration{
	public float MaxSpeed;
	public float AccelerationSpeed;
}

public sealed class PCAcceleration : Voody.UniLeo.MonoProvider<CAcceleration>{}