using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBall : Ball
{
    float startTime;
    float journeyLength;
    Transform startingPos;
    Vector2 endingPos;

    public BasicBall(GameObject prefab_obj) : base(prefab_obj)
    {
        startTime = Time.time;

        startingPos = p_Obj.transform;
        // Set y so it doesn't change when the player jumps
        endingPos = new Vector2(PlayerMovement.Instance.transform.position.y, PlayerMovement.Instance.transform.position.y - 0.2f);

        // Get distance from spawn point and player
        journeyLength = Vector3.Distance(startingPos.position, endingPos);	//store total required distance of Lerp

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
        float distCovered = (Time.time - startTime) * GameManager.Instance.ballSpeed;
        float fracJourney = distCovered / journeyLength;
        fracJourney = Mathf.Sin(fracJourney * Mathf.PI * 0.5f);

        p_Obj.transform.position = Vector3.Lerp(startingPos.position, endingPos, fracJourney);
    }
}
