using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleObstacleFollower : MonoBehaviour {

    public GameObject player;
    public GameObject oppositeHost;

    private float originalYOffset;

    private PlayerController playerController;

    private void followPosition()
    {
        float offset = this.oppositeHost.transform.localPosition.y - this.player.transform.localPosition.y;
        this.transform.localPosition = new Vector2(
            this.transform.localPosition.x,
            -offset + this.originalYOffset
            );
    }

	void Start () {
        this.playerController = this.player.GetComponent<PlayerController>();

        this.originalYOffset = this.transform.localPosition.y;
	}
	
	void Update () {
        this.followPosition();
	}
}
