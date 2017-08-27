using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOverScreen : MonoBehaviour {
    public int score;
    public long time;
    public Sprite activeBowl;

    private int numberRice;
	// Use this for initialization
	void Start () {
        this.numberRice = 4;
        for (int i = 1; i <= this.numberRice; i++)
        {
            GameObject.FindGameObjectWithTag("RiceBowl" + i).GetComponent<SpriteRenderer>().sprite = this.activeBowl;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
