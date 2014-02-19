using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

	public GUIText scoreBoardGUI;
	public float Score = 0f;
	public string scoreText = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		scoreText = Score.ToString ();
		scoreBoardGUI.text = "Buildings destroyed: " + scoreText;
	}
}
