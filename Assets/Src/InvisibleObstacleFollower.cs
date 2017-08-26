using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleObstacleFollower : MonoBehaviour {

    public GameObject player;
    public GameObject oppositeHost;

    private void followPosition()
    {
        float offset = this.oppositeHost.transform.localPosition.y - this.player.transform.localPosition.y;
        this.transform.localPosition = new Vector2(
            this.transform.localPosition.x,
            -offset
            );
    }

	void Start () {
		
	}
	
	void Update () {
        this.followPosition();
	}
}
