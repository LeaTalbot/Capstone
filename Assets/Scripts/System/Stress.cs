using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stress : MonoBehaviour {




	//==============================================================================================

	// VARIABLES

	//==============================================================================================


	public float maxStress;
	public float currentStress;

	public GameObject stressBar;
	public GameObject backgroundStressBar;

	private float maxBpm;
	private float currentBpm;
	public Text BpmText;




	//==============================================================================================

	//==============================================================================================


	void Start () {

		maxStress = 100f;
		currentStress = 0f;

		maxBpm = 110f;
		currentBpm = 90f;

		//InvokeRepeating("IncreaseStress", 1f, 1f); //For testing purposes!
	}



	void Update () {
	
		if (currentStress == 0f) {
			stressBar.SetActive(false);
			backgroundStressBar.SetActive(false);
			BpmText.enabled = false;
		} else {
			stressBar.SetActive(true);
			backgroundStressBar.SetActive(true);
			BpmText.enabled = true;
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
		currentBpm = (maxBpm * currentStress) / maxStress;
		BpmText.text = currentBpm + 90 + "bpm";
	}
}
