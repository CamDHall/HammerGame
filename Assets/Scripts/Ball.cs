using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ball {

    protected GameObject p_Obj;

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

    public abstract void Explode();

    public abstract void DoDamage(int amount);

    public abstract void BounceBuff();

    public void Score(int amount)
    {
        GameManager.Instance.score += amount;
    }

    public void DestroyBall()
    {
        Spawner.Instance.balls.Remove(p_Obj);
        GameObject.Destroy(p_Obj);
    }
}
