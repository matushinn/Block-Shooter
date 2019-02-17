using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour {

    //表示に使うスキン
    public GUISkin skin;

    //カウントダウン用のタイマー
    float timer;

	// Use this for initialization
	void Start () {
        timer = 3.5f;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer<=0.0f){
            //ゲーム開始メッセージをブロードキャストして終了する
            BroadcastMessage("StartGame");
            enabled = false;
        }
	}

    private void OnGUI()
    {
        //スリーカウントの期間中でなければ表示しない
        if (timer > 3.0f || timer <= 0.0f) return;

        //スリーカウントを表示する
        //各カウントにおいてアルファブレンディングでフェードアウトする
        var sw = Screen.width;
        var sh = Screen.height;
        GUI.skin = skin;
        var text = Mathf.CeilToInt(timer).ToString();

        GUI.color = new Color(1, 1, 1, timer - Mathf.FloorToInt(timer));
        GUI.Label(new Rect(0, sh / 4, sw, sh / 2), text, "message");
    }
}
