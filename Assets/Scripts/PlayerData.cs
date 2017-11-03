using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {

    public static PlayerData Instance;

    public int health;
    public GameObject restart;

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
        // Save high school to txt file
        int highestScore;

        using (StreamReader reader = new StreamReader("Files/score.txt"))
        {
            highestScore = int.Parse(reader.ReadLine());
        }

        // Only write to score.txt if current score is higher than past
        if (highestScore < GameManager.Instance.score)
        {
            using (StreamWriter writer = new StreamWriter("Files/score.txt"))
            {
                // Set new score text
                restart.GetComponentsInChildren<Text>()[1].text = "Old Score: " + highestScore + "\tNew High School: " + GameManager.Instance.score;
                writer.WriteLine(GameManager.Instance.score);
            }
        } else
        {
            restart.GetComponentsInChildren<Text>()[1].text = "High School: " + highestScore + "\tScore: " + GameManager.Instance.score;
        }
        // Activate restart button
        restart.SetActive(true);
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
