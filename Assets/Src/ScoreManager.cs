using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Canvas gui;

    public GameObject playerYin;
    public Vector2 yinFinalPosition;

    public GameObject playerYang;
    public Vector2 yangFinalPosition;

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
        this.playerYin.transform.localPosition = this.yinFinalPosition;
        this.yinOk = true;
        this.tryWonGame();
    }

    public void setYangOk()
    {
        Debug.Log("Yang Ok");
        this.playerYang.GetComponent<PlayerController>().setCannotMove();
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
