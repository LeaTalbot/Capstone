using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NameBoxManager : MonoBehaviour {




	public Text nameText;

	public bool isMainCharTalking = false;
	// public bool isCharXtalking = false;
	// public bool isCharYtalking = false;
	//...


	void Update () {

		if (isMainCharTalking) {
			nameText.text = "Me";
		}

		/* if (isCharXtalking) {

		}

		if (isCharYtalking) {

		}
		...
		*/

		//if none of the names are activated -----> disable text box
	}
}
