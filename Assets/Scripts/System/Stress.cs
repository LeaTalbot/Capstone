using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stress : MonoBehaviour {




	//==============================================================================================

	// VARIABLES

	//==============================================================================================


	public float maxStress;
	public float currentStress;

	//public GameObject stressBar;
	//public GameObject backgroundStressBar;
	public GameObject heart;

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

		BpmText.text = 90 + "bpm";

		//InvokeRepeating("IncreaseStress", 1f, 1f); //For testing purposes!

		InvokeRepeating ("VisualizeStressBar", 1f, 1f);
	}



//	void Update () {
//	
//		if (currentStress == 0f) {
//			//stressBar.SetActive(false);
//			//backgroundStressBar.SetActive(false);
//			BpmText.enabled = false;
//		} else {
//			//stressBar.SetActive(true);
//			//backgroundStressBar.SetActive(true);
//			BpmText.enabled = true;
//		}
//	}


	public void IncreaseStress() {

		currentStress += 2f;

		//float calculatedStress = currentStress / maxStress;
		Debug.Log (currentStress);
		currentBpm = (maxBpm * currentStress) / maxStress;
		BpmText.text = currentBpm + 90 + "bpm";

		//VisualizeStressBar(calculatedStress);



		//play stress anim
	}
		

	public void VisualizeStressBar() {

		//used to take float stressAmount as parameter
		//stressAmount needs to be between 0 and 1
		//stressBar.transform.localScale = new Vector3 (Mathf.Clamp(stressAmount, 0f, 1f), stressBar.transform.localScale.y, stressBar.transform.localScale.z);
		StartCoroutine(DokiDoki());
	}

	IEnumerator DokiDoki() {
		
		Vector2 originalScale = heart.transform.localScale;
		heart.transform.localScale = new Vector2(heart.transform.localScale.x + 0.001f, heart.transform.localScale.y + 0.001f);
		yield return new WaitForSeconds(0.05f);
		heart.transform.localScale = originalScale;
		yield break;
	}
}
