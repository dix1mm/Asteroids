using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextSubscriber : MonoBehaviour{
	public string paramName;
	public UEvent uEvent;
	private Text text;
	
	private void Start(){
		text = GetComponent<Text>();
		UnityEventGenerator.Subscribe(uEvent, 
			(object arg) => text.text = paramName + ": "+((string)arg)
		);
	}
}