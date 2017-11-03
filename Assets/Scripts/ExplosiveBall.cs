using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBall : Ball
{
    float startTime;
    float journeyLength;
    float initialY;

    public ExplosiveBall(GameObject prefab_obj) : base(prefab_obj)
    {
        startTime = Time.time;
        journeyLength = Vector2.Distance(prefab_obj.transform.position, PlayerMovement.Instance.transform.position);
        initialY = PlayerMovement.Instance.transform.position.y;
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

    public override void Move()
    {
        float timeElapsed = Time.time - startTime;
        float fracJourney = timeElapsed / journeyLength;

        // Set different steps for x and y
        float yStep = Mathf.Cos(fracJourney * Mathf.PI * GameManager.Instance.ballSpeed * Time.deltaTime);
        float xStep = Mathf.Sin(fracJourney * Mathf.PI * GameManager.Instance.ballSpeed);

        float y = 0;
        float x = 0;

        // Lerp y to just below player's head, don't move back up
        y = Mathf.Lerp(p_Obj.transform.position.y, initialY, yStep);

        // X should circle
        x = Mathf.Lerp(p_Obj.transform.position.x, PlayerMovement.Instance.transform.position.x, xStep);

        p_Obj.transform.position = new Vector2(x, y);
    }
}
