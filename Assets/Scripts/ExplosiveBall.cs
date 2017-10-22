using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBall : Ball
{
    public ExplosiveBall(GameObject prefab_obj) : base(prefab_obj)
    {

    }

    public override void BounceBuff()
    {
        throw new NotImplementedException();
    }

    public override void DoDamage(int amount)
    {
        throw new NotImplementedException();
    }

    public override void Explode()
    {
        // Populate list of surrounding balls
        List<GameObject> balls_aoe = new List<GameObject>();

        // Deal damage to player if in range
        if(Vector2.Distance(PlayerData.Instance.transform.position, p_Obj.transform.position) < 2)
        {
            PlayerData.Instance.TakeDamage(15);
        }

        // Destory all balls inside the radius
        foreach (GameObject ball in Spawner.Instance.balls.Keys)
        {
            if(Vector2.Distance(ball.transform.position, p_Obj.transform.position) < 2)
            {
                balls_aoe.Add(ball);
            }
        }

        foreach(GameObject ball in balls_aoe)
        {
            Spawner.Instance.balls[ball].DestroyBall();
        }
    }
}
