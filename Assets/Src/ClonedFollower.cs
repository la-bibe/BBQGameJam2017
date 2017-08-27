using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonedFollower : MonoBehaviour {

    public GameObject originalPlayer;
    public GameObject hostPlayer;

    private PlayerController playerController;

    private bool follow = true;

    private void Start()
    {
        this.playerController = this.originalPlayer.GetComponent<PlayerController>();
    }

    public void doNotFollow()
    {
        this.follow = false;
    }

    void Update () {
        if (this.follow)
        {
            this.transform.localPosition = new Vector3(
                this.originalPlayer.transform.localPosition.x,
                this.hostPlayer.transform.localPosition.y,
                -1
                );
        }
    }
}
