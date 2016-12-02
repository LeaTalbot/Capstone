using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scene1 : TextBoxManager {


	bool stressIncreased;


	void Update () {

		if (Input.GetKeyDown(KeyCode.Return)) {
			if (!isKeyEnabled) {
				return;
			}
			lineCode += 1;
		}

		if (lineCode == 0) {
			storyText.text = "Hu";
		}

		if (lineCode == 1) {
			storyText.text = "Uh";
			lineCode = 30;
		}

		if (lineCode == 2) {
			storyText.text = "";
		}

		if (lineCode == 3) {
			storyText.text = "";
		}

		if (lineCode == 4) {
			storyText.text = "";
		}

		if (lineCode == 5) {
			storyText.text = "";
		}

		if (lineCode == 6) {
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
			storyText.text = "";
		}

		if (lineCode ==11) {
			storyText.text = "";
		}

		if (lineCode == 12) {
			storyText.text = "";
		}

		if (lineCode == 13) {
			storyText.text = "";
		}

		if (lineCode == 14) {
			storyText.text = "";
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
		}


		//if (stressIncreased == false) {
		//	playerTextInputScript.stressScript.IncreaseStress();
		//	stressIncreased = true;
		//}


		//=================================================================================================
		// A TEMPLATE FOR CHOICES!
		//=================================================================================================

		if (lineCode == 30) {

			//don't forget the isKeyEnabled = false;

			DialogueChoices(18, "I am well.", "...", "", "I am well.", "...", "....");

			if (playerTextInputScript.thePlayerHasNotOvercome) {
				ResetEverything();
				lineCode += 1; //more like goto or linecode = x

			} else if (playerTextInputScript.thePlayerHasOvercome) {
				ResetEverything();
				lineCode += 2;
			} //add a fail-safe in case the choice ends end in neither of those situations?
		}
	}
}



//PUBLIC
// RECEPTIONIST
// WAITER / WAITRESS

//Good cop bad cop