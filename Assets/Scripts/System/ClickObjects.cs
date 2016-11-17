using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickObjects : TextBoxManager {


	public GameObject textBoxManagerInstance;
	private bool stopTogglingYouAsshole = false;
	private bool doorTest = false;


//	public TextBoxManager textBoxManager;
	//bool clickingdone = false;

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

					if (hit.collider.tag == "Door") {

						TextBoxManager.Instance.ToggleAll();
						stopTogglingYouAsshole = false;
						doorTest = true;

					} else {
						return;
					}
				}
			}
		}

		if (doorTest == true) {
			SuccessfullyGotOutTheDoorTestMethod();
		}
	}



	private void SuccessfullyGotOutTheDoorTestMethod() {

		TextBoxManager.Instance.DialogueChoices (-1, "Should I go out now?", "", "", "Yes", "No", "YoUFOUNDaLOoOpHOLEinTheMATRIxCONGRATS");

		if (TextBoxManager.Instance.playerTextInput.thePlayerHasNotOvercome) {
			TextBoxManager.Instance.ResetEverything();
			Debug.Log ("thePlayerHasNotOvercome should not occur when there is not timer...");

		} else if (TextBoxManager.Instance.playerTextInput.thePlayerHasOvercome) {
			Debug.Log ("We're inside the loop! thePlayerHasOvercome= " + TextBoxManager.Instance.playerTextInput.thePlayerHasOvercome + "; whatThePlayerTypes= " + TextBoxManager.Instance.playerTextInput.whatThePlayerTypes + ".");
			TextBoxManager.Instance.ResetEverything();


			if (TextBoxManager.Instance.playerTextInput.whatThePlayerTypes == "Yes") {
				Debug.Log ("The player typed Yes, and the story can continue.");
			}

			if (TextBoxManager.Instance.playerTextInput.whatThePlayerTypes == "No") {
				Debug.Log ("The player typed No. It's kinda stupid, but whatevs.");
			}

			else {
				Debug.Log ("I definitely should only be able to type only Yes or No. Or YoUFOUNDaLOoOpHOLEinTheMATRIxCONGRATS. What happened here?");
			}
		}
	}

			//================================================================================================

			//================================================================================================

}