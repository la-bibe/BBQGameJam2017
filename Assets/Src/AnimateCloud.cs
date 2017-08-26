using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Resources;

public class AnimateCloud : MonoBehaviour {

	public Vector2 begin;
	public float end;
	public Vector2 scale;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	public Sprite[] cloudArray = new Sprite[5];
	public float speed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		this.transform.localScale = getScale();
		rb.velocity = new Vector2 (this.speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x >= this.end) {
			int index = (int)Random.Range (0, 4);
			this.sr.sprite = this.cloudArray [index];
			this.transform.position = getBegin();
			this.transform.localScale = getScale();
		}
	}

	Vector3 getBegin(){
		return new Vector3 (Random.Range (this.begin.x - 3, this.begin.x + 2),
			Random.Range (this.begin.y - 6, this.begin.y + 2),
			0);
	}

	Vector3 getScale(){
		float ratio = Random.Range (0.5f, 0.8f);
		return new Vector3 ( this.scale.x * ratio,
			 this.scale.y * ratio,
			1f);
	}
}
