using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonedFollower : MonoBehaviour {

    public GameObject originalPlayer;
    public GameObject hostPlayer;

    private PlayerController playerController;

    private void Start()
    {
        this.playerController = this.originalPlayer.GetComponent<PlayerController>();
    }

    void Update () {
        this.transform.localPosition = new Vector3(
            this.originalPlayer.transform.localPosition.x,
            this.hostPlayer.transform.localPosition.y,
            -1
            );
	}
}
