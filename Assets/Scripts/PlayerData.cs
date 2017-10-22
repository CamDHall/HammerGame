using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public static PlayerData Instance;

    public int health;

	void Start () {
        Instance = this;
	}
	
	void Update () {
	}

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Debug.Log("YOU DIED");
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ExplosiveBall")
        {
            Spawner.Instance.balls[coll.gameObject].Explode();
        }
        
        if(coll.gameObject.tag == "BasicBall")
        {
            Spawner.Instance.balls[coll.gameObject].DoDamage(5);
            Spawner.Instance.balls[coll.gameObject].DestroyBall();
        }

        if(coll.gameObject.tag == "BouncyBall")
        {
            Spawner.Instance.balls[coll.gameObject].BounceBuff();
            Spawner.Instance.balls[coll.gameObject].DestroyBall();
        }
    }
}
