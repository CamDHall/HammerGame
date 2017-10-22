using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour {

    Queue<GameObject> detonatedBalls = new Queue<GameObject>();
    Queue<GameObject> basicBalls = new Queue<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void InvokeExplode()
    {
        Spawner.Instance.balls[detonatedBalls.Dequeue()].Explode();
    }

    void InvokeDestroy()
    {
        Spawner.Instance.balls[basicBalls.Dequeue()].DestroyBall();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "ExplosiveBall")
        {
            // Push ball back before detonating
            coll.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5, ForceMode2D.Impulse);

            // Use a queue to detonate balls in order in case there are multiple waiting to explode
            detonatedBalls.Enqueue(coll.gameObject);
            Invoke("InvokeExplode", 1);
        }
        // Score when the ball hits the hammer
        if(coll.gameObject.tag == "BasicBall")
        {
            Spawner.Instance.balls[coll.gameObject].Score(1);
            basicBalls.Enqueue(coll.gameObject);
            Invoke("InvokeDestroy", 1);
        }
    }
}
