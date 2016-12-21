using UnityEngine;
using System.Collections;

public class PlayerName : MonoBehaviour {



	public string definitivePlayerName;



	void Awake() {
		DontDestroyOnLoad(this);
	}
}
