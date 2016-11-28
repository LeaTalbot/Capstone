using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene0 : TextBoxManager {

	//public GameObject textBoxManagerInstance; 
	bool storyDone = false;


	void Update () {

		//if (TextBoxManager.Instance.startTheStory = true) {}
		if (Input.GetKeyDown(KeyCode.Return)) {
			if (!isKeyEnabled) {
				return;
			}
			lineCode += 1;
		}

		if (lineCode == 0) {
			//if not reading this first line, or the names: check that the text boxes are big enough!
			TextBoxManager.Instance.isMainCharTalking = true;
			storyText.text = "...I don't want to go.";
		}

		if (lineCode == 1) {
			storyText.text = "Maybe I should stay.";
		}

		if (lineCode == 2) {
			storyText.text = "After all, I still have a lot of work to do. Shit to write and stuff.";
		}

		if (lineCode == 3) {
			storyText.text = "Yeah. I should stay.";
		}

		if (lineCode == 4) {
			storyText.text = "...";
		}

		if (lineCode == 5) {
			storyText.text = "But I have to go. ";
		}

		if (lineCode == 6) {
			storyText.text = "I managed to get myself invited over somehow, so really I should not pass it up.";
		}

		if (lineCode == 7) {
			storyText.text = "... My social life's been a desert, so... Yeah, no choice really.";
		}
			
		if (lineCode == 8) {
			storyText.text = "Can't make friends without putting some effort into it.";
		}

		if (lineCode == 9) {
			storyText.text = "But god, I really don't want to go.";
		}

		if (lineCode == 10) {
			storyText.text = "...";
		}

		if (lineCode ==11) {
			storyText.text = "... ...";
		}

		if (lineCode == 12) {
			storyText.text = "... ... ...";
		}

		if (lineCode == 13) {
			storyText.text = "Okay, time's up. Been fifteen minutes of debating whether I should go, well I'll go, godammit.";
		}

		if (lineCode == 14) {
			storyText.text = "Let's get this over with.";
		}

		if (lineCode == 15) {
			storyText.text = "I should see this as community service to myself.";
		}

		if (lineCode == 16) {
			storyText.text = "Mom'll like it too. Win-win situation. Just a few hours of discomfort.";
		}

		if (lineCode == 17) {
			storyText.text = "Tripping on every goddamn word again, making a fool of my little self. Who cares.";
		}

		if (lineCode == 18) {
			storyText.text = "I'll probably enjoy it in the end.";
			Debug.Log("Stress: " + playerTextInputScript.stressScript.currentStress);
		}

		if (lineCode == 19) {

			if (!storyDone) {
				TextBoxManager.Instance.ToggleAll();
				storyDone = true;
			}
		}
	}
}
