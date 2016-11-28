

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
	public bool activateGUI = false;

	public string whatThePlayerTypes = "";
	public float countdown = -1;
	public bool hasPlayerAnswered = false;

	//THE VALUES THAT THE PLAYERS MUST TYPE
	public string value1;
	public string value2;
	public string value3;

	public bool thePlayerHasOvercome = false;
	public bool thePlayerHasNotOvercome = false;

	public bool hasCoroutineStarted = false; 
	public GameObject timerBarGameObject;
	public Transform timerBarTransform;

	public Stress stressScript;




	//==============================================================================================

	//==============================================================================================


	void Start() {

		stressScript = GameObject.FindGameObjectWithTag("Stress").GetComponent<Stress>();

		timerBarGameObject = GameObject.FindGameObjectWithTag("Timer");
		timerBarTransform = timerBarGameObject.transform;
		timerBarGameObject.SetActive(false);
	}


	//==============================================================================================

	//==============================================================================================


	void OnGUI() {

		if (!activateGUI) {
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
		} else {
			LetPlayerType();
		}
	}



	void LetPlayerType() {
		
		// VISUALIZING TIMER
		if (hasCoroutineStarted == false) {
			
			StartCoroutine(ShrinkTimer(countdown));
			hasCoroutineStarted = true;
		}

		activateGUI = true;

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
			choicePossible = false;
			countdown -= Time.deltaTime;
		} 


		// IF THE PLAYER FAILS TO ANSWER BEFORE THE TIMER RUNS OUT:
		if (countdown < 1 && countdown > 0 && hasPlayerAnswered == false) {
			Debug.Log ("The player has not answered.");
			thePlayerHasNotOvercome = true;
			stressScript.IncreaseStress();
			
		}

		// IF THE PLAYER HAS ANSWERED, LET US PROCEED WITH THE GAME AND RESET BOOL AND TIMER:
		if (hasPlayerAnswered) {
			thePlayerHasOvercome = true;
		}
	}



	//==============================================================================================

	//==============================================================================================


	IEnumerator ShrinkTimer(float countdownInCoroutine) {

		timerBarGameObject.SetActive(true);

		Vector3 originalScale = timerBarTransform.transform.localScale;
		Vector3 destinationScale = new Vector3(0, timerBarTransform.transform.localScale.y, timerBarTransform.transform.localScale.z);

		float currentTime = 0.0f;

		do {
			timerBarTransform.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / countdownInCoroutine);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= countdownInCoroutine && hasPlayerAnswered == false);

		Debug.Log ("We reached the end of the timer shrinking coroutine.");
		timerBarGameObject.SetActive(false); //reactivated right away for some reason
		timerBarTransform.transform.localScale = originalScale; 
		yield break;
	}


	//==============================================================================================

	//==============================================================================================

}