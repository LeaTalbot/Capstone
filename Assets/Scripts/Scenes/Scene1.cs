using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scene1 : TextBoxManager {




	void Update () {

		if (Input.GetKeyDown(KeyCode.Return)) {
			if (!isKeyEnabled) {
				return;
			}
			lineCode += 1;
		}

		if (lineCode == 0) {
			theText.text = "Hu";
		}

		if (lineCode == 1) {
			theText.text = "Uh";
		}

		if (lineCode == 2) {
			theText.text = "";
		}

		if (lineCode == 3) {
			theText.text = "";
		}

		if (lineCode == 4) {
			theText.text = "";
		}

		if (lineCode == 5) {
			theText.text = "";
		}

		if (lineCode == 6) {
			theText.text = "";
		}

		if (lineCode == 7) {
			theText.text = "";
		}

		if (lineCode == 8) {
			theText.text = "";
		}

		if (lineCode == 9) {
			theText.text = "";
		}

		if (lineCode == 10) {
			theText.text = "";
		}

		if (lineCode ==11) {
			theText.text = "";
		}

		if (lineCode == 12) {
			theText.text = "";
		}

		if (lineCode == 13) {
			theText.text = "";
		}

		if (lineCode == 14) {
			theText.text = "";
		}

		if (lineCode == 15) {
			theText.text = "";
		}

		if (lineCode == 16) {
			theText.text = "";
		}

		if (lineCode == 17) {
			theText.text = "";
		}

		if (lineCode == 18) {
			theText.text = "";
		}




		//=================================================================================================
		// A TEMPLATE FOR CHOICES!
		//=================================================================================================

		if (lineCode == 30) {

			//don't forget the isKeyEnabled = false;

			DialogueChoices(18, "I am well.", "...", "", "I am well.", "...", "....");

			if (playerTextInput.thePlayerHasNotOvercome) {
				ResetEverything();
				lineCode += 1; //more like goto or linecode = x

			} else if (playerTextInput.thePlayerHasOvercome) {
				ResetEverything();
				lineCode += 2;
			} //add a fail-safe in case the choice ends end in neither of those situations?
		}
	}
}
