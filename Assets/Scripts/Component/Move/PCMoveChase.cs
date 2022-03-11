using UnityEngine;

[System.Serializable] public struct CMoveChase{
	public Transform Moving;
	public float Speed;
	public Transform ChaseTarget;
}

public sealed class PCMoveChase : Voody.UniLeo.MonoProvider<CMoveChase>{}