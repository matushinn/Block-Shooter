using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Box"){
            //ダメージメッセージを送信する
            collision.gameObject.SendMessage("ApplyDamage");
        }

        Destroy(this.gameObject);
    }


}
