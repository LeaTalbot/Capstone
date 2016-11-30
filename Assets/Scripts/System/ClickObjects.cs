using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickObjects : TextBoxManager {


	public GameObject textBoxManagerInstance;
	private bool stopTogglingYouAsshole = false;

	private bool doorTest = false;
	private bool mcTest = false;


	// Reminder: different scripts = different bool values even if inheriting bool from ancestor script




	void Update () {

	
		if (!TextBoxManager.Instance.storyBox.activeInHierarchy) {


			if (!stopTogglingYouAsshole) {
				TextBoxManager.Instance.ToggleTextBoxes();
				stopTogglingYouAsshole = true;
			} else {
			}


			if (Input.GetMouseButtonDown(0)) {
				
				Debug.DrawLine (Camera.main.transform.position, Input.mousePosition);
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit = new RaycastHit();

				if (Physics.Raycast(ray, out hit, 1000f)) {


					//==============================================================================================

					//==============================================================================================

					if (hit.collider.tag == "Door") {

						TextBoxManager.Instance.ToggleAll();
						stopTogglingYouAsshole = false;
						doorTest = true;

					} else if (hit.collider.tag == "MC") {

						TextBoxManager.Instance.ToggleAll();
						stopTogglingYouAsshole = false;
						mcTest = true;

					} else {
						return;
					}
				}
			}
		}


		//==============================================================================================

		//==============================================================================================

		if (doorTest == true) {
			SuccessfullyGotOutTheDoorTestMethod();
		}

		if (mcTest == true) {

			storyText.text = "Yup. That's me.";

			if (Input.GetKey(KeyCode.Return)) {
				mcTest = false;
				ToggleAll();
			}
		}
	}



	//==============================================================================================

	//==============================================================================================


	private void SuccessfullyGotOutTheDoorTestMethod() {

		TextBoxManager.Instance.DialogueChoices (-1, "Should I go out now?", "", "", "Yes", "No", "YoUFOUNDaLOoOpHOLEinTheMATRIxCONGRATS");


		if (TextBoxManager.Instance.playerTextInputScript.thePlayerHasNotOvercome) {
			TextBoxManager.Instance.ResetEverything();
			Debug.Log ("thePlayerHasNotOvercome should not occur when there is not timer...");
			//If this line appears, it might be because of the corountine we added in PlayerTExtInput. Make sure it is stopped.

		} else if (TextBoxManager.Instance.playerTextInputScript.thePlayerHasOvercome) {
			//Debug.Log ("We're inside the loop! thePlayerHasOvercome= " + TextBoxManager.Instance.playerTextInput.thePlayerHasOvercome + "; whatThePlayerTypes= " + TextBoxManager.Instance.playerTextInput.whatThePlayerTypes + ".");

			if (TextBoxManager.Instance.playerTextInputScript.whatThePlayerTypes == "Yes") {
				Debug.Log ("The player typed Yes, and the story can continue.");
				TextBoxManager.Instance.ResetEverything();
				Invoke("GoToNextScene", 1);
			}

			else if (TextBoxManager.Instance.playerTextInputScript.whatThePlayerTypes == "No") {
				Debug.Log ("The player typed No. I guess they don't want to play the game.");
				TextBoxManager.Instance.ResetEverything();
				doorTest = false;
				ToggleAll();
			}

			else {
				Debug.Log ("I definitely should only be able to type only Yes or No. Why did they not fire?");
				//If this line appears, then check that the ResetEverything() function is not called BEFORE getting to the desired steps.
				TextBoxManager.Instance.ResetEverything();
			}
		}
	}


	//================================================================================================

	//================================================================================================

}