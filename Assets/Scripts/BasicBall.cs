using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBall : Ball
{
    float startTime;
    float journeyLength;
    bool missed = false; // X went pass the player
    Vector3 destination;

    public BasicBall(GameObject prefab_obj) : base(prefab_obj)
    {
        startTime = Time.time;

        destination = PlayerMovement.Instance.transform.position;
        journeyLength = Vector2.Distance(prefab_obj.transform.position, PlayerMovement.Instance.transform.position);
    }

    public override void BounceBuff()
    {
        throw new NotImplementedException();
    }

    public override void DoDamage(int amount)
    {
        Score(-1);
        PlayerData.Instance.TakeDamage(amount);
    }

    public override void Explode()
    {
        throw new NotImplementedException();
    }

    public override void Move()
    {
        if (!missed)
        {
            float timeElapsed = Time.time - startTime;
            float fracJourney = timeElapsed / journeyLength;

            // apply sin
            fracJourney = Mathf.Sin(fracJourney * Mathf.PI * GameManager.Instance.ballSpeed);

            float y;

            float x = Mathf.Lerp(p_Obj.transform.position.x, destination.x, fracJourney);
            // Set y lower, so it doesn't hit the top of the player
            if (Mathf.Abs(PlayerMovement.Instance.transform.position.x - x) > 2.25f)
            {
                y = Mathf.Lerp(p_Obj.transform.position.y, destination.y - 0.2f, fracJourney);
            }
            else
            {
                y = Mathf.Lerp(p_Obj.transform.position.y, destination.y - 0.2f, fracJourney * 3);
            }

            // Transform
            p_Obj.transform.position = new Vector2(x, y);

            Debug.Log(y);
        }

        // If it missed the player, drop and bounce
        if(p_Obj.transform.position.x < destination.x)
        {
            missed = true;
        }
        
    }
}
