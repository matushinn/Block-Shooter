using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorekeeper : MonoBehaviour {

    public int score;

    public GUISkin skin;
    

     public void OnGUI()
    {
        GUI.skin = skin;
        var sw = Screen.width;
        var sh = Screen.height;

        var scoreText = "SCORE: " + score.ToString();
        GUI.Label(new Rect(0, 0, sw / 2,sh / 4), scoreText,"score");

    }
}
