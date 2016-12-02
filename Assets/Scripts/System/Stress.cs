using UnityEngine;
using System.Collections;

public class Stress : MonoBehaviour {




	//==============================================================================================

	// VARIABLES

	//==============================================================================================


	public float maxStress;
	public float currentStress;
	public GameObject stressBar;
	public GameObject backgroundStressBar;





	//==============================================================================================

	//==============================================================================================


	void Start () {

		maxStress = 100f;
		currentStress = 0f;
		//InvokeRepeating("IncreaseStress", 1f, 1f); //For testing purposes!
	}



	void Update () {
	
		if (currentStress == 0f) {
			stressBar.SetActive(false);
			backgroundStressBar.SetActive(false);
		} else {
			stressBar.SetActive(true);
			backgroundStressBar.SetActive(true);
		}
	}


	public void IncreaseStress() {

		currentStress += 2f;

		float calculatedStress = currentStress / maxStress;
		Debug.Log (currentStress);
		VisualizeStressBar(calculatedStress);
	}



	public void VisualizeStressBar(float stressAmount) {

		//stressAmount needs to be between 0 and 1
		stressBar.transform.localScale = new Vector3 (Mathf.Clamp(stressAmount, 0f, 1f), stressBar.transform.localScale.y, stressBar.transform.localScale.z);
	}
}
