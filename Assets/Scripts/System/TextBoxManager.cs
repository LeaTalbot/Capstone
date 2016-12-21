

//==============================================================================================

// TOGGLE TEXTBOXES + CUSTOM METHODS FOR FUTURE SCENES

//==============================================================================================




using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextBoxManager : MonoBehaviour {




	//==============================================================================================

	// VARIABLES

	//==============================================================================================


	public static TextBoxManager Instance;
	public PlayerTextInput playerTextInputScript;
	public PlayerName playerNameScript;

	public GameObject storyBox;
	public GameObject nameBox; 
	public GameObject clickBox;

	public Text nameText;
	public Text storyText;
	public Text clickText;
	public int lineCode = 0;

	private bool m_showAnyTextbox = false;
	private bool m_showingMain = true;

	public bool isMainCharTalking;
	// public bool isCharXtalking = false; ...


	public bool isKeyEnabled = true;
	public bool hasSetCountdown = false;

	public bool hasWaited = true;



	//==============================================================================================

	//==============================================================================================


	// Singleton pattern so that there is only one text manager in the scene
	void Awake() {
		
		Instance = this;
	}


	void Start() {

		isMainCharTalking = true;
		playerTextInputScript = GameObject.Find("Main Camera").GetComponent<PlayerTextInput>();
		playerNameScript = GameObject.Find("PlayerName").GetComponent<PlayerName>();

		StartCoroutine(FadeIn());

		_updateTextBoxes();
	}

	IEnumerator FadeIn() {

		yield return new WaitForSeconds(2f);
		lineCode = 0;
		ToggleTextBoxes();
		ToggleAll();
		yield break;
	}


	//==============================================================================================

	//==============================================================================================



	// Update call for the textboxes
	private void _updateTextBoxes() {

		storyBox.SetActive(m_showingMain && m_showAnyTextbox);
		clickBox.SetActive(!m_showingMain && m_showAnyTextbox);
	}


	// Alternates between Main and Other textbox
	public void ToggleTextBoxes() {

		m_showingMain = !m_showingMain;
		_updateTextBoxes();
	}


	// Alternates between having any textbox shown or none
	public void ToggleAll() {

		m_showAnyTextbox = !m_showAnyTextbox;
		_updateTextBoxes();
	}



	//==============================================================================================

	//==============================================================================================


	public void ResetEverything() {

		hasSetCountdown = false;
		isKeyEnabled = true;
		playerTextInputScript.choicePossible = false;
		playerTextInputScript.activateGUI = false;
		playerTextInputScript.thePlayerHasOvercome = false;
		playerTextInputScript.thePlayerHasNotOvercome = false;
		playerTextInputScript.hasPlayerAnswered = false;
		playerTextInputScript.countdown = -1f;
		playerTextInputScript.whatThePlayerTypes = "";
		playerTextInputScript.hasCoroutineStarted = true;
		playerTextInputScript.timerBarGameObject.SetActive(false);
	}


	//IN THIS SCRIPT, NO DISTINCTION BETWEEN STORYTEXT AND CLICK TEXT. ALSO WE CAN'T REALLY DO THAT BECAUSE WE WANT TO USE DIALOGUE CHOICES FOR BOTH?

	//ALTERNATE NOT VERY SEXY SOLUTION: CREATE ANOTHER IDENTICAL METHOD "DIALOGUECHOICESCLICK" OR SOMETHING?

	public void DialogueChoices(int timer, string text1, string text2, string text3, string value1, string value2, string value3) {

		isKeyEnabled = false;
		playerTextInputScript.choicePossible = true;
		//playerTextInputScript.choicePossible = !playerTextInputScript.choicePossible;

		storyText.text = text1 + "\n" + text2 + "\n" + text3;
		playerTextInputScript.value1 = value1;
		playerTextInputScript.value2 = value2;
		playerTextInputScript.value3 = value3;

		if (!hasSetCountdown) {
			playerTextInputScript.countdown = timer;
			hasSetCountdown = true;
		}
	}



	//==============================================================================================

	//==============================================================================================


	void Update() {

		//Debug.Log ("Silence: " + playerTextInputScript.currentSilence);

		if (storyBox.activeInHierarchy == false) {
			nameBox.SetActive(false);
		} else if (storyBox.activeInHierarchy == true) {
			nameBox.SetActive(true);
		}

		if (isMainCharTalking) {
			nameText.text = playerNameScript.definitivePlayerName;
		}

		//if none of the names are activated -----> disable text box
	}



	public void GoToNextScene() { 

		ToggleAll();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

		//If we need to change other scenes than the next in the index, scrap this and instead:

		//In Scene0, write: StartCoroutine(ChangeScene("scene1"));

	    //In here:

		//IEnumerator ChangeScene (int sceneNumber) {

		//yield return new WaitForSeconds(1);

		//SceneManager.LoadScene(sceneNumber);

		//}
	}





//	public void StartScene() {

//		ToggleAll();
//	}

	/*JUICE AT THE END OF THE SCENE?
		SceneManager.LoadScene(nameScene); or perhaps: SceneManager.LoadScene("\""+ nameScene +"\"");
		Wait half a second then fade to next scene
		At the beginning of each scene including this one, little fade in
		Wait half a second to make the box active
		Make all of that one or two method here to be called super easily in each scene
		*/

	//Invoke("ChangeScene", 1);
	//use this method, but wait a second before playing it


}
