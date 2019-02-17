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

            //前方向への速度ベクトルを設定する
            Vector3 direction = transform.forward;
            bullet.GetComponent<Rigidbody>().velocity = direction * initialVelocity;

        }
		
	}
}
