using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerTextInput : MonoBehaviour {


	public bool choicePossible = false;

	public string whatThePlayerTypes = "";
	public float countdown = -1;
	public bool hasPlayerAnswered = false;

	public string value1;
	public string value2;
	public string value3;

	public bool thePlayerHasOvercome = false;
	public bool thePlayerHasNotOvercome = false;



	//MAKE THE FUTURE DIALOGUE OPTIONS AN ARRAY OF STRINGS? IN ANOTHER SCRIPT?


	void OnGUI() {

		if (!choicePossible) {
			return;
		}

		// BASIC TEXT INPUT WINDOW
		whatThePlayerTypes = GUI.TextField(new Rect(10, 10, 200, 20), whatThePlayerTypes, 25);
	}


	void Update() {

		if (!choicePossible) {
			return;
		}

		// AS LONG AS THE TIMER IS RUNNING AND PLAYER HAS NOT YET TYPED THE CORRECT ANSWER, DO THAT:
		if (countdown > 1 && hasPlayerAnswered == false) {

			if (whatThePlayerTypes == value1 || whatThePlayerTypes == value2 || whatThePlayerTypes == value3) {
				hasPlayerAnswered = true;
			}
				
			countdown -= Time.deltaTime;
		} 


		// IF THE PLAYER FAILS TO ANSWER BEFORE THE TIMER RUNS OUT:
		else if (countdown < 1 && countdown > 0 && hasPlayerAnswered == false) {

			Debug.Log("YOU FAIL.");
			thePlayerHasNotOvercome = true;
			
		}

		// IF THE PLAYER HAS ANSWERED, LET US PROCEED WITH THE GAME AND RESET BOOL AND TIMER:
		if (hasPlayerAnswered) {
			
			Debug.Log("YOU'VE SUCCEEDED! FOR NOW.");
			thePlayerHasOvercome = true;
		}
	}
}