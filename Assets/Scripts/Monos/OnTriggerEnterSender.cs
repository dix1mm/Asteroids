using UnityEngine;

public class OnTriggerEnterSender : MonoBehaviour{

	private void OnTriggerEnter2D(Collider2D collider) =>
		ECSEventGenerator.Generate<ETriggerEnter>(new ETriggerEnter(){
			GO1 = gameObject,
			GO2 = collider.gameObject
		});
}