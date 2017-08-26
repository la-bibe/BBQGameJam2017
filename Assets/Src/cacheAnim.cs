using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cacheAnim : MonoBehaviour {

	private Vector3 targetScale;
	public bool animate = false;
	public GameObject button;
	public float animSpeed = 0.5f;
	// Use this for initialization

	bool Vector3Cmp(Vector3 a, Vector3 b){
		return (a.x > b.x && a.y > b.y);
	}

	void Start () {
		this.targetScale = new Vector3(1, 1, 1);
	}

	// Update is called once per frame
	void Update () {
		bool tmp;

		tmp = this.button.GetComponent<lauchScript>().animate;
		if (tmp) {
			if (this.Vector3Cmp (this.transform.localScale, this.targetScale)) {
				this.transform.localScale = new Vector3 (this.transform.localScale.x - this.animSpeed * Time.deltaTime,
					this.transform.localScale.y - this.animSpeed * Time.deltaTime,
					this.transform.localScale.z - this.animSpeed * Time.deltaTime
				);
			}
			else
				SceneManager.LoadScene("Scenes/Scene01");
		}
	}
}
