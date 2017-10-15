using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball {

    private GameObject p_Obj;

	public Ball (GameObject prefab_obj)
    {
        GameObject ball = UnityEngine.GameObject.Instantiate(prefab_obj);
        p_Obj = ball;
        p_Obj.transform.position = new Vector3(4, -3.5f, 0);
        p_Obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 5, ForceMode2D.Impulse);
    }

    public GameObject Obj
    {
        get
        {
            return p_Obj;
        }
    }
}
