using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

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
