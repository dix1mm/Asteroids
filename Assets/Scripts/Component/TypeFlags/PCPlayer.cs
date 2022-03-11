/*
	не уверен как тут принято делать
	так норм (просто флаг игрока), или надо разбивать на более мелкие сущности?
	например чтобы можно было создать entity с коллайдером от снаряда, типом передвижения врага и управлением от инпута
*/
[System.Serializable] public struct CPlayer{
	public UnityEngine.Transform PlayerTransform;
}

public sealed class PCPlayer : Voody.UniLeo.MonoProvider<CPlayer>{}