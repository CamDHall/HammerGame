using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public static Spawner Instance;

    public Dictionary<GameObject, Piece> pieces = new Dictionary<GameObject, Piece>();

    public GameObject basic_block, explosive_block, bouncy_block;

    float Timer;

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
                    Piece basic = new Piece(basic_block);
                    pieces.Add(basic.Obj, basic);
                    break;
                case 1:
                    Piece explosive = new Piece(explosive_block);
                    pieces.Add(explosive.Obj, explosive);
                    break;
                case 2:
                    Piece bouncy = new Piece(bouncy_block);
                    pieces.Add(bouncy.Obj, bouncy);
                    break;
            }

            Timer = Time.time + Random.Range(3f, 5f);
        }
	}
}
