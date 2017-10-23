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

        Timer = Time.time + 2f;
    }
	
	// Update is called once per frame
	void Update () {
		if(Time.time > Timer)
        {
            int choice = Random.Range(0, 3);

            Vector3 Pos = new Vector3(PlayerData.Instance.transform.position.x + Random.Range(2, 5),
                PlayerMovement.Instance.transform.position.y + Random.Range(1, 4), 0);

            Debug.Log(Pos + " \t" + PlayerMovement.Instance.transform.position.x);

            switch (choice)
            {
                case 0:
                    Ball basic = new BasicBall(basic_ball);
                    basic.Obj.transform.position = Pos;
                    balls.Add(basic.Obj, basic);
                    break;
                case 1:
                    Ball bouncy = new BouncyBall(bouncy_ball);
                    bouncy.Obj.transform.position = Pos;
                    balls.Add(bouncy.Obj, bouncy);
                    break;
                case 2:
                    Ball explosive = new ExplosiveBall(explosive_ball);
                    explosive.Obj.transform.position = Pos;
                    balls.Add(explosive.Obj, explosive);
                    break;
            }

            Timer = Time.time + Random.Range(2f, 4f);
        }
	}
}
