[System.Serializable] public struct CLifetime{
	public UnityEngine.GameObject Target;
	public float Val;
}

public sealed class PCLifetime : Voody.UniLeo.MonoProvider<CLifetime>{}