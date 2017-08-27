using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacle : MonoBehaviour {

    public bool activated = false;

    public bool triggeredMovingObstacle = false;
    public float movingSpeed = 100;
    public Vector2 originalPosition;
    public Vector2 activatedPosition;

    public bool triggeredRotatingObstacle = false;
    public float rotatingSpeed = 10;
    public float originalRotation;
    public float activatedRotation;

    public bool triggeredHiddenObstacle = false;
    public bool originalHidden = false;
    public bool activatedHidden = false;

    public Collider2D objCollider;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D objRigidbody;

    private float allowedPositionPrecisionLoss = 0.05f;
    private float allowedRotationPrecisionLoss = 0.5f;

    private void Start()
    {
        if (this.triggeredMovingObstacle)
        {
            this.transform.localPosition = this.originalPosition;
        }
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.objRigidbody = GetComponent<Rigidbody2D>();
    }

    private void actualiseHidden()
    {
        if (this.triggeredHiddenObstacle)
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
        if (this.triggeredMovingObstacle)
        {
            Vector2 velocity = new Vector2(
                this.movingSpeed * Time.deltaTime,
                this.movingSpeed * Time.deltaTime
                );

            if (this.activated)
            {
                velocity.x *= (Mathf.Abs(this.transform.localPosition.x - this.activatedPosition.x) < this.allowedPositionPrecisionLoss ?
                    0 :
                    (this.transform.localPosition.x < this.activatedPosition.x ?
                    1 :
                    -1
                    ));
                velocity.y *= (Mathf.Abs(this.transform.localPosition.y - this.activatedPosition.y) < this.allowedPositionPrecisionLoss ?
                    0 :
                    (this.transform.localPosition.y < this.activatedPosition.y ?
                    1 :
                    -1
                    ));
            }
            else
            {
                velocity.x *= (Mathf.Abs(this.transform.localPosition.x - this.originalPosition.x) < this.allowedPositionPrecisionLoss ?
                    0 :
                    (this.transform.localPosition.x < this.originalPosition.x ?
                    1 :
                    -1
                    ));
                velocity.y *= (Mathf.Abs(this.transform.localPosition.y - this.originalPosition.y) < this.allowedPositionPrecisionLoss ?
                    0 :
                    (this.transform.localPosition.y < this.originalPosition.y ?
                    1 :
                    -1
                    ));
            }
            this.objRigidbody.velocity = velocity;
        }
    }

    private void actualiseRotation()
    {
        if (this.triggeredRotatingObstacle)
        {
            float angularVelocity = this.rotatingSpeed * Time.deltaTime;
            float actualRotation = this.transform.rotation.eulerAngles.z;
            actualRotation = (actualRotation > 180 ? actualRotation - 360 : actualRotation);

            if (this.activated)
            {
                angularVelocity *= (Mathf.Abs(actualRotation - this.activatedRotation) < this.allowedRotationPrecisionLoss ?
                    0 :
                    (actualRotation < this.activatedRotation ?
                    1 :
                    -1
                    ));
            }
            else
            {
                angularVelocity *= (Mathf.Abs(actualRotation - this.originalRotation) < this.allowedRotationPrecisionLoss ?
                    0 :
                    (actualRotation < this.originalRotation ?
                    1 :
                    -1
                    ));
            }
            this.objRigidbody.angularVelocity = angularVelocity;
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
        this.actualiseRotation();
    }
}
