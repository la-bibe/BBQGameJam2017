using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacle : MonoBehaviour {
    public float speed;

    public bool movingObstacle = false;
    public Vector2 originalPosition;
    public Vector2 activatedPosition;

    public bool hiddenObstacle = false;
    public bool originalHidden = false;
    public bool activatedHidden = false;


    public Collider2D objCollider;

    public bool activated = false;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D objRigidbody;

    private void Start()
    {
        if (this.movingObstacle)
        {
            this.transform.position = this.originalPosition;
        }
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.objRigidbody = GetComponent<Rigidbody2D>();
    }

    private void actualiseHidden()
    {
        if (this.hiddenObstacle)
        {
            if (this.activated)
            {
                this.spriteRenderer.enabled = !this.activatedHidden;
                this.objCollider.enabled = !this.activatedHidden;
            }
            else
            {
                this.spriteRenderer.enabled = !this.originalHidden;
                this.objCollider.enabled = !this.originalHidden;
            }
        }
    }

    public void setActivated(bool activated)
    {
        this.activated = activated;
        this.actualiseHidden();
    }

    void Update () {
        if (this.movingObstacle)
        {
            Vector2 velocity = new Vector2(
                this.speed * Time.deltaTime,
                this.speed * Time.deltaTime
                );
            if (this.activated)
            {
                this.spriteRenderer.enabled = !this.activatedHidden;
                this.objCollider.enabled = !this.activatedHidden;
                velocity.x *= (this.transform.position.x == this.activatedPosition.x ?
                    0 :
                    (this.transform.position.x < this.activatedPosition.x ?
                    1 :
                    -1
                    ));
                velocity.y *= (this.transform.position.y == this.activatedPosition.y ?
                    0 :
                    (this.transform.position.y < this.activatedPosition.y ?
                    1 :
                    -1
                    ));

                this.objRigidbody.velocity = velocity;
            }
            else
            {
                this.spriteRenderer.enabled = !this.originalHidden;
                this.objCollider.enabled = !this.originalHidden;
                velocity.x *= (this.transform.position.x == this.originalPosition.x ?
                    0 :
                    (this.transform.position.x < this.originalPosition.x ?
                    1 :
                    -1
                    ));
                velocity.y *= (this.transform.position.y == this.originalPosition.y ?
                    0 :
                    (this.transform.position.y < this.originalPosition.y ?
                    1 :
                    -1
                    ));

                this.objRigidbody.velocity = velocity;
            }
        }
    }
}
