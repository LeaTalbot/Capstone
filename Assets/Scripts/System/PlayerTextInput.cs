

//==============================================================================================

// HOW THE PLAYER PROGRESSES: TYPING ANSWERS

//==============================================================================================




using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerTextInput : MonoBehaviour {




	//==============================================================================================

	// VARIABLES

	//==============================================================================================


	public bool choicePossible = false;

	public string whatThePlayerTypes = "";
	public float countdown = -1;
	public bool hasPlayerAnswered = false;

	public string value1;
	public string value2;
	public string value3;

	public bool thePlayerHasOvercome = false;
	public bool thePlayerHasNotOvercome = false;

	public Transform timerBarTransform;
	public GameObject timerBarGameObject;

	public int stress = 0;




	//==============================================================================================

	//==============================================================================================


	void Start() {

		timerBarGameObject = GameObject.FindGameObjectWithTag("Timer");
		timerBarTransform = GameObject.FindGameObjectWithTag("Timer").transform;
		timerBarGameObject.SetActive(false);
	}


	//==============================================================================================

	//==============================================================================================


	void OnGUI() {

		if (!choicePossible) {
			return;
		}

		// BASIC TEXT INPUT WINDOW
		whatThePlayerTypes = GUI.TextField(new Rect(10, 10, 200, 20), whatThePlayerTypes, 25);
	}



	//==============================================================================================

	//==============================================================================================


	void Update() {

		if (!choicePossible) {
			return;
		}

		//VISUALIZING THE TIMER
		StartCoroutine(ShrinkTimer(countdown));


		//INFINITE ANSWER TIME
		if (countdown == -1 && !hasPlayerAnswered) {

			if (whatThePlayerTypes == value1 || whatThePlayerTypes == value2 || whatThePlayerTypes == value3) {
				hasPlayerAnswered = true;
			}

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
		if (countdown < 1 && countdown > 0 && hasPlayerAnswered == false) {
			thePlayerHasNotOvercome = true;
			stress += 1;
			StopCoroutine(ShrinkTimer(countdown)); //??? do i need that?
			timerBarGameObject.SetActive(false);
			
		}

		// IF THE PLAYER HAS ANSWERED, LET US PROCEED WITH THE GAME AND RESET BOOL AND TIMER:
		if (hasPlayerAnswered) {
			thePlayerHasOvercome = true;
			StopCoroutine(ShrinkTimer(countdown)); //???
			timerBarGameObject.SetActive(false);
		}
	}



	//==============================================================================================

	//==============================================================================================


	IEnumerator ShrinkTimer(float countdownInCoroutine) {

		timerBarGameObject.SetActive(true);

		Vector3 originalScale = timerBarTransform.transform.localScale;
		Vector3 destinationScale = new Vector3(0.1f, 0, 0);

		float currentTime = 0.0f;

		do {
			timerBarTransform.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / countdownInCoroutine);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= countdownInCoroutine);

		timerBarGameObject.SetActive(false);

		//if time runs out: disable the timer bar

		//if the player has overcome before time runs out: disable timer bar as well

		//also: reset size?
	}


	//==============================================================================================

	//==============================================================================================


	//public void AddStress() {

	//visual effect for stress under here:

	//add an if statement in update for the game over state
	//}

	//add lower stress as well, even though we might only need it in the long run

}