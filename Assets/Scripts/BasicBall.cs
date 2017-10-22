using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBall : Ball
{
    public BasicBall(GameObject prefab_obj) : base(prefab_obj)
    {
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
}
