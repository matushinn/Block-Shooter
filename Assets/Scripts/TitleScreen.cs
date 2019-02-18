using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    //表示に使うスキン
    public GUISkin skin;
    
    
    // Update is called once per frame
    void Update () {
        if(Input.GetKeyDown("space")){
            SceneManager.LoadScene("Main");
        }
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        var sw = Screen.width;
        var sh = Screen.height;

        GUI.Label(new Rect(0, 0, sw, sh ), "BLOCK SHOOTER", "message");
        GUI.Label(new Rect(0, sh/2, sw , sh / 2), "Click To Start", "message");

    }

}