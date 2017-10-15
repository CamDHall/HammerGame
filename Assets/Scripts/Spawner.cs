using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public static Spawner Instance;

    public GameObject basic_ball, explosive_ball, bouncy_ball;

    float Timer;

    public Dictionary<GameObject, Ball> balls = new Dictionary<GameObject, Ball>();

	// Use this for initialization
	void Start () {
        Instance = this;

        Timer = Time.time + 3f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > Timer)
        {
            int choice = Random.Range(0, 3);

            switch (choice)
            {
                case 0:
                    Ball basic = new Ball(basic_ball);
                    balls.Add(basic.Obj, basic);
                    break;
                case 1:
                    Ball bouncy = new Ball(bouncy_ball);
                    balls.Add(bouncy.Obj, bouncy);
                    break;
                case 2:
                    Ball explosive = new Ball(explosive_ball);
                    balls.Add(explosive.Obj, explosive);
                    break;
            }

            Timer = Time.time + Random.Range(3f, 5f);
        }
	}
}
