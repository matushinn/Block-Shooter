using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    //箱の色の名前
    public string colorName = "Red";

    //爆発エフェクト
    public GameObject explosionPrefab;

    //ダメージ受けた
    bool damaged;

    //消滅までの時間
    float killTimer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!damaged){
            return;
        }
        killTimer -= Time.deltaTime;
        if(killTimer<= 0.0){

            //破壊をGame Controllerに通知
            GameObject gameController = GameObject.FindWithTag("GameController");
            gameController.SendMessage("OnDestroyBox", colorName);
            //エフェクトを出しつつ、自身のゲームオブジェクトを破棄
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
	}

    void ApplyDamage()
    {
        if(!damaged){
            damaged = true;
            killTimer = 0.4f;
            //上方向に衝撃を与える
            //impulse 力積
            GetComponent<Rigidbody>().AddForce(Vector3.up * 15.0f, ForceMode.Impulse);
        }

    }
}
