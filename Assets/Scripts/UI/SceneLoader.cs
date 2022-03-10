using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour{
	public GameObject StartgameBtn;

	public void LoadGame() => SceneManager.LoadScene("Game");

	private void loadMenu(object o){
		SceneManager.LoadScene("Menu");
		StartgameBtn.SetActive(true);
	}

	private void Start() => UnityEventGenerator.Subscribe(UEvent.GameEnded, loadMenu);
}