using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "ExplosiveBall")
        {
            Spawner.Instance.balls[coll.gameObject].Explode();
        }
        // Score when the ball hits the hammer
        if(coll.gameObject.tag == "BasicBall")
        {
            Spawner.Instance.balls[coll.gameObject].Score(1);
        }
    }
}
