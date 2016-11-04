using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestForAnotherTextBoxManager : MonoBehaviour {



//=================================================================================================
// VARIABLES
//=================================================================================================

	public GameObject textBox;
	public Text theText;

	bool isKeyEnabled = true;

	public int lineCode = 0;
	//A note to myself on "lineCode": assign segments for each scenes. Ex 0-100 for the first scene. 
	//100-200 for the second... So that if we have modifications to make, we don't have to move EVERYTHING
	//back and forth a few lines.

	private PlayerTextInput playerTextInput;
	private bool hasSetCountdown = false;

	//TO IMPLEMENT IN THE FUTURE + HAVE A SEPARATE TEXTBOX SCRIPT THAT DISPLAYS NAMES AND TURN OFF
	//WHEN MAKING CHOICES OR WHEN THE MAIN CHAR IS THINKING
	//bool isCharaXTalking = false;
	//bool isCharaYTalking = false;
	//bool isCharaZTalking = false;



//=================================================================================================
// START + CUSTOM METHODS
//=================================================================================================

	void Start() {

		playerTextInput = GameObject.Find("Main Camera").GetComponent<PlayerTextInput>();
	}


	void ResetEverything() {

		hasSetCountdown = false;
		isKeyEnabled = true;
		playerTextInput.choicePossible = false;
		playerTextInput.thePlayerHasOvercome = false;
		playerTextInput.thePlayerHasNotOvercome = false;
		playerTextInput.hasPlayerAnswered = false;
		playerTextInput.countdown = -1f;
		playerTextInput.whatThePlayerTypes = "";
	}


	void DialogueChoices(int timer, string text1, string text2, string text3, string value1, string value2, string value3) {

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


//=================================================================================================
// WHERE THE REAL MEAN STUFF BEGINS
//=================================================================================================

	void Update () {

		//textBox.SetActive(false);
		if (Input.GetKeyDown(KeyCode.Return)) {
			if (!isKeyEnabled) {
				return;
			}
			lineCode += 1;
		}

		if (lineCode == 0) {
		theText.text = "Hello there!";
		}

		if (lineCode == 1) {
			theText.text = "Nice to meet you!";
		}

		if (lineCode == 2) {
			theText.text = "How are you?";
		}
			

//=================================================================================================
// 1st CHOICE TIME
//=================================================================================================

		if (lineCode == 3) {

			DialogueChoices(18, "I am well.", "...", "", "I am well.", "...", "....");

			if (playerTextInput.thePlayerHasNotOvercome) {
				ResetEverything();
				lineCode += 1;

			} else if (playerTextInput.thePlayerHasOvercome) {
				ResetEverything();
				lineCode += 2;
			} //add a fail-safe in case the choice ends end in neither of those situations?
		}

//=================================================================================================
//=================================================================================================


		if (lineCode == 4) {
			theText.text = "Well you suck.";
		}

		if (lineCode == 5) {
			theText.text = "Well you're awesome.";
		}

		if (lineCode == 6) {
			theText.text = "Let us continue the experiment. Shall we?";
		}

//=================================================================================================
// 2nd CHOICE TIME
//=================================================================================================

		if (lineCode == 7) {

			DialogueChoices (15, "I am not sure.", "...", "", "I am not sure.", "...", "....");

			if (playerTextInput.thePlayerHasNotOvercome) {
				ResetEverything();
				lineCode += 1;

			} else if (playerTextInput.thePlayerHasOvercome) {
				ResetEverything();
				lineCode += 1;
			}
		}
//=================================================================================================
//=================================================================================================

		if (lineCode == 8) {
			theText.text = "We're gonna do it anyway!";
			isKeyEnabled = false;
		}
	}
}
