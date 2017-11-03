using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public int score = 0;

    public Text info;

    public float ballSpeed;

	void Start () {
        Instance = this;
	}

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "main")
            info.text = "Score: " + score + " Health: " + PlayerData.Instance.health;

        // Move balls
        foreach(GameObject ball in Spawner.Instance.balls.Keys)
        {
            Spawner.Instance.balls[ball].Move();
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("main");
    }
}
