using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timekeeper : MonoBehaviour {

    //ゲーム開始から終了までの長さ
    public float gameLength;

    //経過時間
    float elapsed;
	
	
	// Update is called once per frame
	void Update () {
        elapsed += Time.deltaTime;
        if(elapsed>=gameLength){
            //このゲームオブジェクトとカメラにタイムアップメッセージを送信して停止する
            BroadcastMessage("TimeUp");
            GameObject.FindWithTag("MainCamera").SendMessage("TimeUp");

            enabled = false;
        }
	}
}
