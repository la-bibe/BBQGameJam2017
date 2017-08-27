using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Canvas gui;

    public GameObject playerYin;
    public GameObject playerYinClone;
    public Vector3 yinFinalPosition;

    public GameObject playerYang;
    public GameObject playerYangClone;
    public Vector3 yangFinalPosition;

    private int score;

    private bool yinOk = false;
    private bool yangOk = false;

    private void winGame()
    {
        Debug.Log("Win");
    }

    private void tryWonGame()
    {
        if (this.yinOk && this.yangOk)
        {
            this.winGame();
        }
    }

    public void setYinOk()
    {
        Debug.Log("Yin Ok");
        this.playerYin.GetComponent<PlayerController>().setCannotMove();
        this.playerYin.GetComponent<Collider2D>().enabled = false;
        this.playerYin.GetComponent<SpriteRenderer>().enabled = false;

        this.playerYinClone.GetComponent<ClonedFollower>().doNotFollow();
        this.playerYinClone.transform.localPosition = this.yinFinalPosition;
        this.playerYin.transform.localPosition = this.yinFinalPosition;
        this.yinOk = true;
        this.tryWonGame();
    }

    public void setYangOk()
    {
        Debug.Log("Yang Ok");
        this.playerYang.GetComponent<PlayerController>().setCannotMove();
        this.playerYang.GetComponent<Collider2D>().enabled = false;
        this.playerYang.GetComponent<SpriteRenderer>().enabled = false;

        this.playerYangClone.GetComponent<ClonedFollower>().doNotFollow();
        this.playerYangClone.transform.localPosition = this.yangFinalPosition;
        this.playerYang.transform.localPosition = this.yangFinalPosition;
        this.yangOk = true;
        this.tryWonGame();
    }
    
    public void loseGame()
    {
        Debug.Log("Lose");
    }

    public void earnPoints(int number)
    {
        score += number;
        Debug.Log("Refresh score");
    }

	void Start () {
        //this.gui.enabled = false;
    }
	
	void Update () {
        /*
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            this.gui.enabled = true;
        } else if (Input.GetKeyUp(KeyCode.Tab))
        {
            this.gui.enabled = false;
        }
        //*/
	}
}
