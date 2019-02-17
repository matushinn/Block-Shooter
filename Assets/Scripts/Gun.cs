using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    //弾丸のプレハブ
    public GameObject bulletPrefab;

    //弾丸の初速
    public float initialVelocity;

	
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("space")){
            //弾丸プレハブのインスタンス化
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            //クリックした点をワールド座標系に変換
            var screenPoint = Input.mousePosition;
            screenPoint.z = 10;
            var worldPoint = GetComponent<Camera>().ScreenToWorldPoint(screenPoint);

            //クリックした点へ向かうベクトルを速度ベクトルとして設定
            var direction = (worldPoint - transform.position).normalized;

            //前方向への速度ベクトルを設定する

            bullet.GetComponent<Rigidbody>().velocity = direction * initialVelocity;

        }
		
	}
}
