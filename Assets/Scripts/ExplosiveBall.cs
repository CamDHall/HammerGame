using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBall : Ball
{
    float startTime;

    private float RotateSpeed = 5f;
    private float Radius = 0.5f;

    private Vector2 _centre;
    private float _angle;

    public ExplosiveBall(GameObject prefab_obj) : base(prefab_obj)
    {
        startTime = Time.time;

        _centre = p_Obj.transform.position;
        
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
        // Rotate
        _angle += RotateSpeed * Time.deltaTime;

        float stepAmount = (1f - Mathf.Cos(Time.time - startTime * Mathf.PI * 0.5f)) * (GameManager.Instance.ballSpeed * 0.25f);

        // Move centre closer to player
        _centre = Vector2.Lerp(_centre, PlayerMovement.Instance.transform.position, stepAmount);

        // Move the ball in a circle
        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        p_Obj.transform.position = _centre + offset;
    }
}
