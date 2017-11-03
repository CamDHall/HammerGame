using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBall : Ball
{
    public BouncyBall(GameObject prefab_obj) : base(prefab_obj)
    {
    }

    public override void BounceBuff()
    {
        PlayerData.Instance.health += 5;
        Score(10);
    }

    public override void DoDamage(int amount)
    {
        throw new NotImplementedException();
    }

    public override void Explode()
    {
        
    }

    public override void Move()
    {
        
    }
}
