using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class StartScene : MonoBehaviour {


	public PlayerName playerNameScript;
	public string playerName;
	public Button button;
	public Text text;




	void Start() {

		playerNameScript = GameObject.Find("PlayerName").GetComponent<PlayerName>();

		button = gameObject.GetComponent<Button>();
		button.interactable = false;
		text.color = Color.gray;
	}


	void OnGUI() {

		playerName = GUI.TextField(new Rect(500, 275, 200, 40), playerName, 10);
	}


	void Update() {

		if (playerName == "") {
			return;
		}
	
		button.interactable = true;
		text.color = Color.white;
	}


	public void OnClick() {

		playerNameScript.definitivePlayerName = playerName;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
