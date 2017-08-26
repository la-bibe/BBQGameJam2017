using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed = 10;

    private Rigidbody2D rigidBody;
    
	void Start ()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
	}
    
    void Update()
    {
        this.rigidBody.velocity = new Vector2(
            Input.GetAxis("Horizontal") * this.playerSpeed * Time.deltaTime,
            Input.GetAxis("Vertical") * this.playerSpeed * Time.deltaTime
            );
    }
}
