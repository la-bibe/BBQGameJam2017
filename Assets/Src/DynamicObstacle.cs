using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacle : MonoBehaviour {

    public bool activated = false;

    public bool movingObstacle = false;
    public float movingSpeed = 100;
    public Vector2 originalPosition;
    public Vector2 activatedPosition;

    public bool rotatingObstacle = false;
    public float rotatingSpeed = 100;
    public Vector2 originalRotation;
    public Vector2 activatedRotation;

    public bool hiddenObstacle = false;
    public bool originalHidden = false;
    public bool activatedHidden = false;

    public Collider2D objCollider;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D objRigidbody;

    private float allowedPrecisionLoss = 0.01f;

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

    private void actualisePosition()
    {
        if (this.movingObstacle)
        {
            Vector2 velocity = new Vector2(
                this.movingSpeed * Time.deltaTime,
                this.movingSpeed * Time.deltaTime
                );

            if (this.activated)
            {
                velocity.x *= (Mathf.Abs(this.transform.position.x - this.activatedPosition.x) < this.allowedPrecisionLoss ?
                    0 :
                    (this.transform.position.x < this.activatedPosition.x ?
                    1 :
                    -1
                    ));
                velocity.y *= (Mathf.Abs(this.transform.position.y - this.activatedPosition.y) < this.allowedPrecisionLoss ?
                    0 :
                    (this.transform.position.y < this.activatedPosition.y ?
                    1 :
                    -1
                    ));
            }
            else
            {
                velocity.x *= (Mathf.Abs(this.transform.position.x - this.originalPosition.x) < this.allowedPrecisionLoss ?
                    0 :
                    (this.transform.position.x < this.originalPosition.x ?
                    1 :
                    -1
                    ));
                velocity.y *= (Mathf.Abs(this.transform.position.y - this.originalPosition.y) < this.allowedPrecisionLoss ?
                    0 :
                    (this.transform.position.y < this.originalPosition.y ?
                    1 :
                    -1
                    ));
            }
            this.objRigidbody.velocity = velocity;
        }
    }

    public void setActivated(bool activated)
    {
        this.activated = activated;
        this.actualiseHidden();
    }

    void Update()
    {
        this.actualisePosition();
    }
}
