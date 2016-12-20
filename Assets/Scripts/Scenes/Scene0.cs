using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene0 : TextBoxManager {





	//==============================================================================================

	//==============================================================================================


	void Update () {

		if (Input.GetKeyDown(KeyCode.Return)) {
			if (!isKeyEnabled) {
				return;
			}
			lineCode += 1;
		}

		// if playerTextInputScript.currentSilence = playerTextInputScript.maxSilence and linecode btw x and y, do that

		//==============================================================================================

		//==============================================================================================


		if (lineCode == 0) {
			//if not reading this first line, or the names: check that the text boxes are big enough!
			TextBoxManager.Instance.isMainCharTalking = true;
			storyText.text = "'...'";
		}

		if (lineCode == 1) {
			storyText.text = "...";
		}

		if (lineCode == 2) {
			storyText.text = "'I really wish today was any other day. Even the day I got my tooth pulled out would be fine.'";
		}

		if (lineCode == 3) {
			storyText.text = "'Let's see... Coffee machine, broken. Beer, gone with my roommate.'";
		}

		if (lineCode == 4) {
			storyText.text = "'Oh, that's just great. That's just fucking grand.'";
		}

		if (lineCode == 5) {
			storyText.text = "...";
		}

		if (lineCode == 6) {
			lineCode = 10;
			storyText.text = "";
		}

		if (lineCode == 7) {
			storyText.text = "";
		}
			
		if (lineCode == 8) {
			storyText.text = "";
		}

		if (lineCode == 9) {
			storyText.text = "";
		}

		if (lineCode == 10) {
			storyText.text = "Someone's calling.";
		}

		if (lineCode ==11) {
			storyText.text = "... Ah, it's Mom.";
		}

		if (lineCode == 12) {
			DialogueChoices(18, "I am well.", "...", "", "I am well.", "...", "....");

			if (playerTextInputScript.thePlayerHasNotOvercome) {
				ResetEverything();
				lineCode = 13; //more like goto or linecode = x

			} else if (playerTextInputScript.thePlayerHasOvercome) {
				ResetEverything();
				lineCode = 13;
			} //add a fail-safe in case the choice ends end in neither of those situations?
		}

		if (lineCode == 13) {
			storyText.text = "";
		}

		if (lineCode == 14) {
			storyText.text = "e";
		}

		if (lineCode == 15) {
			storyText.text = "";
		}

		if (lineCode == 16) {
			storyText.text = "";
		}

		if (lineCode == 17) {
			storyText.text = "";
		}

		if (lineCode == 18) {
			storyText.text = "";
			//Debug.Log("Stress: " + playerTextInputScript.stressScript.currentStress);
		}

		if (lineCode == 100) {
			
			bool storyDone = false;

			if (!storyDone) {
				TextBoxManager.Instance.ToggleAll();
				storyDone = true;
			}
		}
	}
}