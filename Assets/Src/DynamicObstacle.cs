using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacle : MonoBehaviour {

    public float speed;
    public Vector2 originalPosition;
    public Vector2 movedPosition;

    public bool moved = false;

    private void Start()
    {
        this.transform.position = this.originalPosition;
    }

    void Update () {
        if (this.moved)
        {
            this.transform.position = this.movedPosition;
        } else
        {
            this.transform.position = this.originalPosition;
        }
    }
}
