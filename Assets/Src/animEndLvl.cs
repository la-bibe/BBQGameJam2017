using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animEndLvl : MonoBehaviour {

	public Vector3 targetScale;
	public float animSpeed = 0.5f;
	// Use this for initialization

	bool Vector3Cmp(Vector3 a, Vector3 b){
		return (a.x > b.x && a.y > b.y);
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool tmp = GameObject.Find("CameraYang").GetComponent<ScoreManager>().hasWon && GameObject.Find("CameraYin").GetComponent<ScoreManager>().hasWon;
		if (tmp) {
			Debug.Log (tmp);
			if (this.Vector3Cmp (this.transform.localScale, this.targetScale)) {
					this.transform.localScale = new Vector3 (this.transform.localScale.x - this.animSpeed * Time.deltaTime,
						this.transform.localScale.y - this.animSpeed * Time.deltaTime,
						this.transform.localScale.z - this.animSpeed * Time.deltaTime
					);
				}
			else {
				Debug.Log ("Met des actions ici Julian");	
			}
		}
	}
}