using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rb;
    BoxCollider2D bCollider;

    public float speed, jumpHeight, gravity, maxSpeed;

    bool grounded, jumped = false;

    // For Position
    Vector2 vel = new Vector2();

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        bCollider = GetComponent<BoxCollider2D>();

        speed *= Time.deltaTime;
        jumpHeight *= Time.deltaTime;
        gravity *= Time.deltaTime;
	}

    private void Update()
    {
        if (!jumped && grounded && Input.GetKeyDown(KeyCode.Space)) {
            jumped = true;
        } 
    }

    void FixedUpdate () {

        // Check for movement
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);

        if(left)
        {
            vel.x -= speed;
            Debug.Log(vel.x);
        }

        if(right)
        {
            vel.x += speed;
        }

        if(!left && !right)
        {
            vel.x = 0;
        }

        // Cap max speed
        vel.x = Mathf.Max(Mathf.Min(vel.x, maxSpeed), -maxSpeed);

        if (jumped)
        {
            vel.y = jumpHeight;
            jumped = false;
        }

        if(!grounded)
        {
            vel.y -= gravity;
        }

        // Update position
        rb.MovePosition((Vector2)transform.position + vel);


        // Check if on platfor
        Vector2 pt1 = transform.TransformPoint(bCollider.offset + new Vector2(bCollider.size.x / 2, -bCollider.size.y / 2));//(box.size / 2));
        Vector2 pt2 = transform.TransformPoint(bCollider.offset - (bCollider.size / 2) + new Vector2(0, 0));
        grounded = Physics2D.OverlapArea(pt1, pt2, LayerMask.GetMask("Platform")) != null;
    }
}
