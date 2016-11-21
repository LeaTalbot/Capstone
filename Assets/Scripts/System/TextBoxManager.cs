

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
	public PlayerTextInput playerTextInput;

	public GameObject storyBox;
	public GameObject nameBox; 
	public GameObject clickBox;

	public Text nameText;
	public Text storyText;
	public Text clickText;
	public int lineCode = 0;

	private bool m_showAnyTextbox = true;
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
		playerTextInput = GameObject.Find("Main Camera").GetComponent<PlayerTextInput>();

		_updateTextBoxes();
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
		playerTextInput.choicePossible = false;
		playerTextInput.thePlayerHasOvercome = false;
		playerTextInput.thePlayerHasNotOvercome = false;
		playerTextInput.hasPlayerAnswered = false;
		playerTextInput.countdown = -1f;
		playerTextInput.whatThePlayerTypes = "";
	}


	//IN THIS SCRIPT, NO DISTINCTION BETWEEN STORYTEXT AND CLICK TEXT. ALSO WE CAN'T REALLY DO THAT BECAUSE WE WANT TO USE DIALOGUE CHOICES FOR BOTH?
	public void DialogueChoices(int timer, string text1, string text2, string text3, string value1, string value2, string value3) {

		storyText.text = text1 + "\n" + text2 + "\n" + text3;
		playerTextInput.value1 = value1;
		playerTextInput.value2 = value2;
		playerTextInput.value3 = value3;

		if (!hasSetCountdown) {
			playerTextInput.countdown = timer;
			hasSetCountdown = true;
		}

		isKeyEnabled = false;
		playerTextInput.choicePossible = true;
	}



	//==============================================================================================

	//==============================================================================================


	void Update() {


		if (storyBox.activeInHierarchy == false) {
			nameBox.SetActive(false);
		} else if (storyBox.activeInHierarchy == true) {
			nameBox.SetActive(true);
		}

		if (isMainCharTalking) {
			nameText.text = "MCName";
		}

		//if none of the names are activated -----> disable text box
	}



	//public void ChangeScene(string nameScene) { 

	//	ToggleAll();
	//	SceneManager.LoadScene(nameScene);
	//}





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
