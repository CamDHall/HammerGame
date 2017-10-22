using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public int score = 0;

	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(score);
	}
}
