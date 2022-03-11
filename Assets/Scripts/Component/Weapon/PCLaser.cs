using UnityEngine;

[System.Serializable] public struct CLaser{
	public Transform User;
	public GameObject Shot;
	public int MaxCharges;
	public float RechargeTime;//время получения заряда
	public float Cd;//время между использованием зарядов
	[HideInInspector] public int CurrCharge;
	[HideInInspector] public float CurrChargeTime;
	[HideInInspector] public float CurrCd;
}

public sealed class PCLaser : Voody.UniLeo.MonoProvider<CLaser>{}