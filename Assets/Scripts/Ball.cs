using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ball {

    protected GameObject p_Obj;
    protected bool detonate;
    protected float delayTimer;

	public Ball (GameObject prefab_obj)
    {
        Vector3 Pos = new Vector3(PlayerData.Instance.transform.position.x + Random.Range(3, 8),
            PlayerMovement.Instance.transform.position.y + Random.Range(1, 4), 0);
        GameObject ball = UnityEngine.GameObject.Instantiate(prefab_obj);
        p_Obj = ball;
        p_Obj.transform.position = Pos;
        p_Obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 5, ForceMode2D.Impulse);
    }

    public GameObject Obj
    {
        get
        {
            return p_Obj;
        }
    }

    public bool Detonate
    {
        get { return detonate; }
        set { detonate = value; }
    }

    public float DelayTimer
    {
        set { delayTimer = value;  }
    }

    public abstract void Explode();

    public abstract void DoDamage(int amount);

    public abstract void BounceBuff();

    public abstract void Move();

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
