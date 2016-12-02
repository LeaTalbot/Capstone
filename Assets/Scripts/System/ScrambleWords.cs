using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;


public class ScrambleWords : MonoBehaviour {




	//==============================================================================================

	// VARIABLES

	//==============================================================================================


	public string[] wordsArray;
	public char[] characters;

	public Text theTextToScramble;

	//private string debugstring;


	//==============================================================================================

	//==============================================================================================


	void Start () {

		theTextToScramble.text = "This wonderful text is only temporary and helps me test the script for scrambling words!";
	}


	void Update() {
		
		//MessingWithWords();
		InvokeRepeating("MessingWithWords", 1f, 1f);
	}

	private void MessyUpPart(ref char[] messpart) {
		
		//index from where pick char to exchange
		int a = 0, b = 0;
		//to make sure we switch one from the bottom towards the front part of the word
		while (!(a < b))
		{
			a = UnityEngine.Random.Range(0, messpart.Length);
			b = UnityEngine.Random.Range(0, messpart.Length);
		}

		char temp = messpart[a];
		messpart[a] = messpart[b];
		messpart[b] = temp;
	}

	public void MessingWithWords() {


		//SPLIT SENTENCE INTO WORDS ; CHAR [0] = WHITESPACE
		wordsArray = theTextToScramble.text.Split(new char[0]);

		for (int i = 0; i < wordsArray.Length; i++)
		{

			//SPLIT EACH WORD INTO CHARS AND PUT EACH OF THE CHARS IN THEIR OWN LISTS
			characters = wordsArray[i].ToCharArray();

			//IF THe WORD IN THREE OR LESS CHARS LONG, DON'T CONTINUE
			if (wordsArray[i].Length <= 3)
			{
				//Instead of breaking let's see the other words
				continue;
			}

			//OPTIONAL: DO NOT CHANGE FIRST (0) AND LAST INDEX (Index.Length - 1)
			char[] subcharacters = new char[characters.Length - 2];
			Array.Copy(characters, 1, subcharacters, 0, subcharacters.Length);

			//OPTIONAL: ONLY LIMIT TO ONE CHARACTER CHANGE?
			//MESS UP THE INDEX OF THOSE CHARS.
			MessyUpPart(ref subcharacters);

			//PUT THE CHARS BACK INTO THE WORD
			Array.Copy(subcharacters, 0, characters, 1, subcharacters.Length);

			//PUT THE CHARS BACK INTO THE ORIGINAL LIST OF WORDS
			wordsArray[i] = new string(characters);

		}
			
		//reconstructing the sentence as string, checking wordsarray lenght is != 0 just to make sure
		string debugstring = wordsArray.Length != 0 ? wordsArray[0] : "" ;
		for (int i = 1; i < wordsArray.Length; i++)
		{
			debugstring += " " + wordsArray[i];
		}

		//Debug.Log(debugstring);
		theTextToScramble.text = debugstring;
		//StartCoroutine(RepeatEverySecond(1f));
	}

//	IEnumerator RepeatEverySecond (float delayTime) {
//
//		yield return new WaitForSeconds(delayTime);
//		theTextToScramble.text = debugstring;
//		yield break;
//	}
}