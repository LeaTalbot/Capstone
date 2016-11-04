using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestForTextBoxManager : MonoBehaviour {


	public GameObject textBox;
	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;


	void Start () {

		if (textFile != null) {

			//Look at the text and split everytime it breaks into a new line
			textLines = (textFile.text.Split('\n')); 
		}

		if (endAtLine == 0) {

			endAtLine = textLines.Length - 1;
		}
	}


	void Update() {

		theText.text = textLines[currentLine];

		if (Input.GetKeyDown(KeyCode.Return)) {
			currentLine += 1;
		}

		//Bigger so that you have to hit enter an extra time to close
		if (currentLine > endAtLine) {
			textBox.SetActive(false);
		}
	}
}