using UnityEngine;

[System.Serializable] public struct CDeathSegmentation{
	public GameObject Parent;
	public GameObject Segment;
	public int SegmentsCount;
}

public sealed class PCDeathSegmentation : Voody.UniLeo.MonoProvider<CDeathSegmentation>{}