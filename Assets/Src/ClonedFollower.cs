using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonedFollower : MonoBehaviour {

    public GameObject originalPlayer;
    public GameObject hostPlayer;

    void Update () {
        this.transform.localPosition = new Vector2(
            this.originalPlayer.transform.localPosition.x,
            this.hostPlayer.transform.localPosition.y
            );
	}
}
