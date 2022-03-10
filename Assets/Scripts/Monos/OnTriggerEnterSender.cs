using UnityEngine;

public class OnTriggerEnterSender : MonoBehaviour{
	private void OnTriggerEnter2D(Collider2D collider) =>
		ECSEventGenerator.Generate<ETriggerEnter>(new ETriggerEnter(){
			Target1 = gameObject,
			Target2 = collider.gameObject
		});
}