using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleObstacleFollower : MonoBehaviour {

    public GameObject player;
    public GameObject oppositeHost;

    private PlayerController playerController;

    private void followPosition()
    {
        float offset = this.oppositeHost.transform.localPosition.y - this.player.transform.localPosition.y;
        this.transform.localPosition = new Vector2(
            this.transform.localPosition.x,
            -offset
            );
    }

	void Start () {
        this.playerController = this.player.GetComponent<PlayerController>();
	}
	
	void Update () {
        this.followPosition();
	}
}
