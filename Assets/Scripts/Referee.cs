using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Referee : MonoBehaviour {

    public GUISkin skin;

    //色の切り替えの間隔
    public float switchInterval;
    //正しい色に対する加点
    public int rewardPoint;
    //間違った色に対する減点
    public int penaltyPoint;

    //Scorekeeperコンポーネントへの参照
    Scorekeeper scorekeeper;
    //現在のターゲットが赤の時true
    bool targetIsRed;
    //色切り替えまでの時間
    float switchTimer;

    //現在ターゲットになっている色名をえる
    string GetTargetColorName(){
        return targetIsRed ? "Red" : "Blue";
    }
	// Use this for initialization
	void Start () {
        //Scorekeeperコンポーネントへの参照を確保する
        scorekeeper = GetComponent<Scorekeeper>();

        //ターゲット色は赤から始める
        targetIsRed = true;

        //最初の色切り替えまでの時間を設定
        switchTimer = switchInterval;
	}
	
	// Update is called once per frame
	void Update () {
        switchTimer -= Time.deltaTime;
        if(switchTimer<0.0f){
            //色が反転する
            targetIsRed = !targetIsRed;
            //次の色切り替えまでの時間を設定
            switchTimer = switchInterval;
        }
		
	}


    //箱の破壊の通知の処理
    public void OnDestroyBox(string boxColorName)
    {
        //現在のターゲットしょくと同じなら加点を、異なっていれば原点を行う。
        if(boxColorName == GetTargetColorName()){
            scorekeeper.score += rewardPoint;

        }else{
            scorekeeper.score -= penaltyPoint;
        }
        
    }

    public void OnGUI()
    {
        //色切り替えが間もない場合は表示を行わない
        if (switchTimer < 1.5f) return;

        GUI.skin = skin;
        //ターゲット色の名前を、対応する色のラベルで表示する
        var sw = Screen.width;
        var sh = Screen.height;

        var message = "Shoot Boxes";
        GUI.color = targetIsRed ? Color.red : Color.blue;
        GUI.Label(new Rect(0, sh/4, sw , sh / 2), message,"message");

    }
    void TimeUp()
    {
        enabled = false;
    }

    public void StartGame(){
        enabled = true;
    }
}
