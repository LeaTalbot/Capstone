using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ScrambleWords : MonoBehaviour {


	//public List <string> wordsList;
	//public List <char> lettersList;
	//public List <List <string>> wordsToScrambleList = new List <List <string>>();


	public string[] wordsArray;

	//HOW TO MAKE THIS WORK:
	//public string[][] arrayOfScrambledLetters;
	public Text theTextToScramble;




	void Start () {

		theTextToScramble.text = "This wonderful text is only temporary and helps me test the script for scrambling words!";
	}
	

	void Update () {
	

		//SPLIT SENTENCE INTO WORDS ; CHAR [0] = WHITESPACE
		wordsArray = theTextToScramble.text.Split(new char[0]);

		Debug.Log("Beginning of update runs.");

		for (int i = 0; i < wordsArray.Length; i++) {

			Debug.Log("Inside first loop.");
			//SPLIT EACH WORD INTO CHARS AND PUT EACH OF THE CHARS IN THEIR OWN LISTS.
			char[] characters = wordsArray[i].ToCharArray();

			//IF THe WORD IN THREE OR LESS CHARS LONG, DON'T CONTINUE
			if (wordsArray[i].Length <= 3) {
				return;
			}

			for (int y = 0; y < characters.Length; y++) {
			
				Debug.Log("Inside second loop.");
				y = y+1;
				//MESS UP THE INDEX OF THOSE CHARS.

				//OPTIONAL: ONLY LIMIT TO ONE CHARACTER CHANGE?

				//OPTIONAL: DO NOT CHANGE FIRST (0) AND LAST INDEX (Index.Length - 1) OR (-2) IF WE SPLIT AFTER SPACE
			}
		}

		Debug.Log ("End of update: " + wordsArray[0] + wordsArray[1] + wordsArray[2] + wordsArray[3]);
			

		//PUT THE CHARS BACK INTO THE ORIGINAL LIST OF WORDS


		//PRINT THE NEW SENTENCE! DO I ACTUALLY NEED THIS LINE?


		//REPEAT THE WHOLE PROCESS EVERY HALF SECOND OR SO

		//To clear list: wordsToScrambleList.Clear();
	}




/*
	Random Notes
	
	http://answers.unity3d.com/questions/688512/how-to-separate-parts-of-a-string.html
	http://answers.unity3d.com/questions/256751/how-can-i-split-a-word-to-individual-letters.html
	http://answers.unity3d.com/questions/672553/how-to-split-a-string-into-array.html

	//http://answers.unity3d.com/questions/556311/add-a-list-within-a-list.html

	//foreach (String thisWord in wordsList)???

	//string wordToSplit = wordsArray[i];

*/
}
