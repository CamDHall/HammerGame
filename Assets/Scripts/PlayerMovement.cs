using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public static PlayerMovement Instance;

    Rigidbody2D rb;
    BoxCollider2D bCollider;

    public float speed, jumpHeight, gravity, maxSpeed;

    bool grounded, jumped = false;

    // For Position
    public Vector2 vel = new Vector2();

	void Start () {
        Instance = this;

        rb = GetComponent<Rigidbody2D>();
        bCollider = GetComponent<BoxCollider2D>();

        // Scale variables to make assignment easier
        speed *= Time.deltaTime;
        maxSpeed *= Time.deltaTime;
        jumpHeight *= Time.deltaTime;
        gravity *= Time.deltaTime;
	}

    private void Update()
    {
        // Jump
        if (!jumped && grounded && Input.GetKeyDown(KeyCode.UpArrow)) {
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

        // Gravity
        if(!grounded)
        {
            vel.y -= gravity;
        }

        // Keep gravity from pushing the player through the floor
        if(vel.y < 0 && grounded)
        {
            vel.y = 0;
        }

        // Update position
        rb.MovePosition((Vector2)transform.position + vel);

        // Check if on platform
        Vector2 pt1 = transform.TransformPoint(bCollider.offset + new Vector2(bCollider.size.x / 2, -bCollider.size.y / 2));//(box.size / 2));
        Vector2 pt2 = transform.TransformPoint(bCollider.offset - (bCollider.size / 2) + new Vector2(0, 0));
        grounded = Physics2D.OverlapArea(pt1, pt2, LayerMask.GetMask("Object")) != null;
    }
}
