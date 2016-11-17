using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {


	//==============================================================================================

	// TOGGLE TEXTBOXES + CUSTOM METHODS FOR FUTURE SCENES

	//==============================================================================================


	//==============================================================================================

	// VARIABLES

	//==============================================================================================


	public static TextBoxManager Instance;

	//public NameBoxManager nameBoxManager;
	public PlayerTextInput playerTextInput;



	public GameObject textBox;
	public GameObject nameBox; 
	public GameObject clickBox;

	public Text nameText;
	public Text theText;
	public int lineCode = 0;
	/*
	A note to myself on "lineCode": assign segments for each scenes. Ex 0-100 for the first scene. 
	100-200 for the second... So that if we have modifications to make, we don't have to move EVERYTHING
	back and forth a few lines.
	*/



	//public bool isStoryTextBoxActive;
	private bool m_showAnyTextbox = true;
	private bool m_showingMain = true;

	public bool isMainCharTalking;
	// public bool isCharXtalking = false;
	// public bool isCharYtalking = false;
	//...



	public bool isKeyEnabled = true;
	public bool hasSetCountdown = false;

	public bool hasWaited = true;

	// Add visible timer


	//==============================================================================================

	//==============================================================================================



	// Singleton pattern so that there is only one text manager in the scene
	void Awake() {
		
		Instance = this;
	}


	void Start() {

		isMainCharTalking = false;
		playerTextInput = GameObject.Find("Main Camera").GetComponent<PlayerTextInput>();
		//nameBoxManager = GameObject.Find("Panel Name - nameBox").GetComponent<NameBoxManager>();

		_updateTextBoxes();
	}


	//==============================================================================================

	//==============================================================================================



	// Update call for the textboxes
	private void _updateTextBoxes() {

		textBox.SetActive(m_showingMain && m_showAnyTextbox);
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


	public void DialogueChoices(int timer, string text1, string text2, string text3, string value1, string value2, string value3) {

		theText.text = text1 + "\n" + text2 + "\n" + text3;
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


		if (textBox.activeInHierarchy == false) {
			nameBox.SetActive(false);
//			isStoryTextBoxActive = false;
		} else if (textBox.activeInHierarchy == true) {
			nameBox.SetActive(true);
//			isStoryTextBoxActive = true;
		}

		if (isMainCharTalking) {
			nameText.text = "Me";
		}

		//if none of the names are activated -----> disable text box
	}



//	public void ChangeScene() { 

		//textBox.SetActive(false);
		//nameBox.SetActive(false);
		//Debug.Log("About to wait...");
		//StartCoroutine(WaitFunction(10));
		//Debug.Log("We waited.");

		/*JUICE AT THE END OF THE SCENE?
		SceneManager.LoadScene(targetScene); or perhaps: SceneManager.LoadScene("\""+ targetScene +"\"");
		Wait half a second then fade to next scene
		At the beginning of each scene including this one, little fade in
		Wait half a second to make the box active
		Make all of that one or two method here to be called super easily in each scene
		*/
//	}

//	private IEnumerator WaitFunction(int timetoWait) {
//		if (hasWaited == false) {
//			yield return new WaitForSeconds (timetoWait);
//			hasWaited = true;
//		}
//	}
}
