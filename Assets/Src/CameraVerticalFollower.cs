using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVerticalFollower : MonoBehaviour {

    public GameObject player;

    public Color colorYin;
    public Color colorYang;

    private GameObject[] obstacles;

	void Start ()
    {
        this.obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject obstacle in this.obstacles)
        {
            obstacle.GetComponent<SpriteRenderer>().color = this.colorYin;
        }

        player.GetComponent<SpriteRenderer>().color = this.colorYin;

        this.GetComponent<Camera>().backgroundColor = this.colorYang;
    }
	
	void Update ()
    {
        this.transform.position = new Vector3(
            this.transform.position.x,
            this.player.transform.position.y,
            this.transform.position.z
            );
    }
}
