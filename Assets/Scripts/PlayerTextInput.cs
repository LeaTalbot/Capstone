using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerTextInput : MonoBehaviour {



	public string stringToEdit = "";
	public float countdown = 5f;
	public bool hasPlayerAnswered = false;

	public string value1 = "Hello World!";
	public string value2 = "Ugh";
	public string value3 = "...";

	//MAKE THE FUTURE DIALOGUE OPTIONS AN ARRAY OF STRINGS? IN ANOTHER SCRIPT?



	void OnGUI() {

		// BASIC TEXT INPUT WINDOW
		stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20), stringToEdit, 25);
	}




	void Update() {


		Debug.Log(countdown);


		// AS LONG AS THE TIMER IS RUNNING AND PLAYER HAS NOT YET TYPED THE CORRECT ANSWER, DO THAT:
		if (countdown > 1 && hasPlayerAnswered == false) {

			if (stringToEdit == value1 || stringToEdit == value2 || stringToEdit == value3) {
				hasPlayerAnswered = true;
			}
				
			countdown -= Time.deltaTime;
		} 


		// IF THE PLAYER FAILS TO ANSWER BEFORE THE TIMER RUNS OUT:
		else if (countdown < 1 && hasPlayerAnswered == false) {

			Debug.Log("YOU FAIL.");
			
		}

		// IF THE PLAYER HAS ANSWERED, LET US PROCEED WITH THE GAME AND RESET BOOL AND TIMER:
		if (hasPlayerAnswered) {
			
			Debug.Log("YOU'VE SUCCEEDED! FOR NOW.");
			hasPlayerAnswered = false;
			countdown = 5f;
			// go to next set of values
			// or perhaps let that be handled by a separate, story script?
		}
	}
}