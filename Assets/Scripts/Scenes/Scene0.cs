using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene0 : TextBoxManager {



	void Update () {

		if (Input.GetKeyDown(KeyCode.Return)) {
			if (!isKeyEnabled) {
				return;
			}
			lineCode += 1;
		}

		if (lineCode == 0) {
			nameBoxManager.isMainCharTalking = true;
			theText.text = "...I don't want to go.";
		}

		if (lineCode == 1) {
			theText.text = "Maybe I should stay.";
		}

		if (lineCode == 2) {
			theText.text = "After all, I still have a lot of work to do. Shit to write and stuff.";
		}

		if (lineCode == 3) {
			theText.text = "Yeah. I should stay.";
		}

		if (lineCode == 4) {
			theText.text = "...";
		}

		if (lineCode == 5) {
			theText.text = "But I have to go. ";
		}

		if (lineCode == 6) {
			theText.text = "I managed to get myself invited over somehow, so really I should not pass it up.";
		}

		if (lineCode == 7) {
			theText.text = "... My social life's been a desert, so... Yeah, no choice really.";
		}
			
		if (lineCode == 8) {
			theText.text = "Can't make friends without putting some effort into it.";
		}

		if (lineCode == 9) {
			theText.text = "But god, I really don't want to go.";
		}

		if (lineCode == 10) {
			theText.text = "...";
		}

		if (lineCode ==11) {
			theText.text = "... ...";
		}

		if (lineCode == 12) {
			theText.text = "... ... ...";
		}

		if (lineCode == 13) {
			theText.text = "Okay, time's up. Been fifteen minutes of debating whether I should go, well I'll go, godammit.";
		}

		if (lineCode == 14) {
			theText.text = "Let's get this over with.";
		}

		if (lineCode == 15) {
			theText.text = "I should see this as community service to myself.";
		}

		if (lineCode == 16) {
			theText.text = "Mom'll like it too. Win-win situation. Just a few hours of discomfort.";
		}

		if (lineCode == 17) {
			theText.text = "Tripping on every goddamn word again, making a fool of my little self. Who cares.";
		}

		if (lineCode == 18) {
			theText.text = "I'll probably enjoy it in the end.";
		}

		if (lineCode == 19) {
			//SceneManager.LoadScene("Scene1");
			textBox.SetActive(false);
		}
	}
}
