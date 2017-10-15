using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour {

    List<GameObject> pieces_on_hammer = new List<GameObject>();

    private void FixedUpdate()
    {
        // If hammer has a child
        if(transform.childCount > 1)
        {
            // Call Drop function for piece
            if(Input.GetMouseButtonDown(0))
            {
                // Drop all childern besides hammer
                for(int i = 1; i < transform.childCount; i++)
                {
                    GameObject child = transform.GetChild(i).gameObject;
                    pieces_on_hammer.Remove(child);
                    Spawner.Instance.pieces[child].Drop();
                }
            }         
        }

        Debug.Log(Spawner.Instance.pieces.Keys.Count)
;
        // Destory surrounding pieces
        if(Input.GetMouseButtonDown(1))
        {
            List<GameObject> old_pieces = pieces_on_hammer;

            Debug.Log(old_pieces.Count);
            foreach (GameObject piece in old_pieces)
            {
                Spawner.Instance.pieces[piece].Destory();
            }

            pieces_on_hammer.Clear();
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Piece")
        {
            Spawner.Instance.pieces[coll.gameObject].Pickup(transform.gameObject);
            pieces_on_hammer.Add(coll.gameObject);
        }
    }
}
