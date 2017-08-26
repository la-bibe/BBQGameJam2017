using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVerticalFollower : MonoBehaviour {

    public GameObject playerA;
	public GameObject playerB;
	private GameObject onFocus;
    public Color colorYin;
    public Color colorYang;

    private GameObject[] obstacles;

	void Start ()
    {
        this.obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
		this.onFocus = playerA;
        foreach (GameObject obstacle in this.obstacles)
        {
            obstacle.GetComponent<SpriteRenderer>().color = this.colorYin;
        }

        playerA.GetComponent<SpriteRenderer>().color = this.colorYin;

        this.GetComponent<Camera>().backgroundColor = this.colorYang;
    }
	
	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
			this.onFocus = (this.onFocus == this.playerA) ? this.playerB : this.playerA;
        this.transform.position = new Vector3(
            this.transform.position.x,
			this.onFocus.transform.position.y,
            this.transform.position.z
            );
    }
}
