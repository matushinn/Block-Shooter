using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScreen : MonoBehaviour {

    //表示に使うスキン
    public GUISkin skin;

    //Scorekeeperコンポーネントへの参照
    Scorekeeper scorekeeper;
    //現在の状態を表す文字列
    string state;


	// Use this for initialization
	void Start () {
        //Scorekeeperコンポーネントへの参照を取得する
        scorekeeper = GetComponent<Scorekeeper>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //タイムアップメッセージの表示
    public void TimeUp()
    {
        //TimeUpテキストの表示
        state = "Time Up";
        yield return new WaitForSeconds(3.0f);

        //ちょっと非表示期間を置く
        state = "";
        yield return new WaitForSeconds(0.5f);

        //スコアを表示しボタン押したをまつ
        state = "Show Score";
        // while (!Input.GetButtonDown("space")) yield;

        //ゲームを再起動する
        SceneManager.LoadScene("Main");

    }

    public void OnGUI()
    {
        var sw = Screen.width;
        var sh = Screen.height;
        GUI.skin = skin;

        //現在の状態によって表示を切り替える
        if(state == "Time Up"){
            //"Time Up"テキストの表示
            GUI.Label(new Rect(0, 0, sw, sh), "Time Up!!", "message");

        }else if(state == "Show Score"){
            //スコア表示
            string scoreText = "Your score is " + scorekeeper.score.ToString();
            GUI.Label(new Rect(0, sh/4, sw, sh/4), scoreText, "message");
            GUI.Label(new Rect(0, sh/2, sw, sh/4), "Click to Exit", "message");
        }
    }
}
