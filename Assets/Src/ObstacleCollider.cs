using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider: MonoBehaviour {

    public GameObject playerYin;
    public GameObject playerYang;

    // Use this for initialization
    void Start () {
        if (this.GetComponent<SpriteRenderer>().tag == "ObstacleYang")
        {
            Debug.Log(this.playerYin.GetComponent<CircleCollider2D>());
            Physics2D.IgnoreCollision(this.playerYin.GetComponent<CircleCollider2D>(), this.GetComponent<PolygonCollider2D>());
        }
        if (this.GetComponent<SpriteRenderer>().tag == "ObstacleYin")
        {
            Physics2D.IgnoreCollision(this.playerYang.GetComponent<CircleCollider2D>(), this.GetComponent<PolygonCollider2D>());
        }
    }


	// Update is called once per frame
	void Update () {
		
	}
}
