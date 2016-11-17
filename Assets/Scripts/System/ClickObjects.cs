using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickObjects : TextBoxManager {



	private bool stopTogglingYouAsshole = false;


//	public TextBoxManager textBoxManager;
	//bool clickingdone = false;

	// Reminder: different scripts = different bool values even if inheriting bool from ancestor script



	void Update () {


//		if (TextBoxManager.Instance.isStoryTextBoxActive == true) {
//			textBox.SetActive(false); // different assigned textBox than in Textmanager!
//		}

		//if (textBoxManager.isStoryTextBoxActive == false) {
		//if (!textBoxManager.textBox.activeInHierarchy) {
		//if (!TextBoxManager.Instance.textBox.activeInHierarchy) {



		if (!TextBoxManager.Instance.textBox.activeInHierarchy) {


			if (!stopTogglingYouAsshole) {
				TextBoxManager.Instance.ToggleTextBoxes();
				stopTogglingYouAsshole = true;
			} else {
			}


			if (Input.GetMouseButtonDown(0)) {

				//add private boolean to do it only once
				TextBoxManager.Instance.ToggleAll();
				
				Debug.DrawLine (Camera.main.transform.position, Input.mousePosition);
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit = new RaycastHit();

				if (Physics.Raycast(ray, out hit, 1000f)) {

					//================================================================================================

					// DOOR

					//================================================================================================

					//Debug.Log(hit.collider.tag);
					if (hit.collider.tag == "Door") {

						Debug.Log ("I've hit the door. Nice!");

						TextBoxManager.Instance.DialogueChoices (-1, "Should I go out now?", "", "", "Yes", "No", "YoUFOUNDaLOoOpHOLEinTheMATRIxCONGRATS");

						if (TextBoxManager.Instance.playerTextInput.thePlayerHasNotOvercome) {
							TextBoxManager.Instance.ResetEverything();
							Debug.Log ("This should not happen.");

						} else if (TextBoxManager.Instance.playerTextInput.thePlayerHasOvercome) {
							TextBoxManager.Instance.ResetEverything();

							if (TextBoxManager.Instance.playerTextInput.whatThePlayerTypes == "Yes") {
								Debug.Log ("Wah. It... worked?");
							}

							if (TextBoxManager.Instance.playerTextInput.whatThePlayerTypes == "No") {
								Debug.Log ("Wah. It... REALLY worked?");
							}

							else {
								Debug.Log ("I definitely should only be able to type only Yes or No. Or YoUFOUNDaLOoOpHOLEinTheMATRIxCONGRATS. What happened here?");
							}
						} 
					} else {
						return;
					}

					//================================================================================================

					//================================================================================================
				}
			}
		}
	}
}