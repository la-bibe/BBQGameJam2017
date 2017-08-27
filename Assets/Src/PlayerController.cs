using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed = 10;

    private Rigidbody2D rigidBody;

    private bool canMove = false;
    
    public void setCanMove()
    {
        this.canMove = true;
    }

    public void setCannotMove()
    {
        this.canMove = false;
        this.rigidBody.velocity = new Vector2();
    }

    public bool getCanMove()
    {
        return this.canMove;
    }

	void Start ()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
	}
    
    void Update()
    {
        if (this.canMove)
        {
            this.rigidBody.velocity = new Vector2(
                Input.GetAxis("Horizontal") * this.playerSpeed * Time.deltaTime,
                Input.GetAxis("Vertical") * this.playerSpeed * Time.deltaTime
                );
        }
    }
}
