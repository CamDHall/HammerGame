using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece {

    private bool can_be_grabbed;
    private float delay_time;

    private GameObject p_pieceObj;

	public Piece(GameObject piece_model)
    {
        p_pieceObj = UnityEngine.GameObject.Instantiate(piece_model);
        can_be_grabbed = true;
    }

    // GameObject Getter
    public GameObject Obj
    {
        get
        {
            return p_pieceObj;
        }
    }

    // Drop piece
    public void Drop()
    {
        p_pieceObj.transform.SetParent(null);
        delay_time = Time.time + 3f; // Set Timer so that piece isn't picked up right after release
    }

    public void Pickup(GameObject hammer)
    {
        if(Time.time > delay_time)
        {
            p_pieceObj.transform.SetParent(hammer.transform);
        }
    }

    public void Destory()
    {
        Spawner.Instance.pieces.Remove(p_pieceObj);
        Object.Destroy(p_pieceObj);
    }
}
