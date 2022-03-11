using UnityEngine;

[System.Serializable] public struct CMoveInput{
	public Transform TransformLink;//для передачи в создаваемый компонент поворота, не уверен как правильно
	public float MaxSpeed;
	public float AccelerationSpeed;
	public float SlowdownSpeed;
	public float RotationSpeed;
}

public sealed class PCMoveInput : Voody.UniLeo.MonoProvider<CMoveInput>{}