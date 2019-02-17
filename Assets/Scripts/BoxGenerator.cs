using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerator : MonoBehaviour {

    //箱を生成する間隔
    public float interval;

    //赤箱のプレハブ
    public GameObject redBoxPrefab;

    //青箱のプレハブ
    public GameObject blueBoxPrefab;

    //色を切り替えるための変数
    bool nextIsRed;
    //次に箱を生成するまでの時間
    float timer;


	// Use this for initialization
	void Start () {
        //最初の箱の予約
        nextIsRed = true;
        timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer<0.0f){

            //位置と姿勢にランダム成分を与えつつ、箱のプレハブをインスタンス化する
            float offsx = Random.Range(-8.0f, 8.0f);
            float offsz = Random.Range(-4.0f, 4.0f);

            var position = this.transform.position + this.transform.right * Random.Range(-8.0f, 8.0f);

            //いずれかのプレハブをインスタンス化する
            GameObject prefab = nextIsRed ? redBoxPrefab : blueBoxPrefab;
            Instantiate(prefab, position, transform.rotation);

            //次の箱の予約
            timer = interval;
            nextIsRed = !nextIsRed;
        }
		
	}
}
