using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickObjects : TextBoxManager {



	void Update () {

		if (Input.GetMouseButtonDown(0)) {
			Debug.DrawLine (Camera.main.transform.position, Input.mousePosition);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(ray, out hit, 1000f)) {

//================================================================================================
//================================================================================================

				if (hit.collider.tag == "Door") {

/*					DialogueChoices (-1, "Should I go out now?", "", "", "Yes", "No", "YoUFOUNDaLOoOpHOLEinTheMATRIxCONGRATS");

					if (playerTextInput.thePlayerHasNotOvercome) {
						ResetEverything();
						Debug.Log ("This should not happen.");

					} else if (playerTextInput.thePlayerHasOvercome) {
						ResetEverything();

						if (playerTextInput.whatThePlayerTypes == "Yes") {
							Debug.Log ("Wah. It... worked?");
						}

						if (playerTextInput.whatThePlayerTypes == "No") {
							Debug.Log ("Wah. It... REALLY worked?");
						}

						else {
							Debug.Log ("I definitely should only be able to type only Yes or No. Or YoUFOUNDaLOoOpHOLEinTheMATRIxCONGRATS. What happened here?");
						}
					} 
*/

//================================================================================================
//================================================================================================

				} 
			}
		}
	}
}