using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Canvas gui;

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
        this.yinOk = true;
    }

    public void setYinNotOk()
    {
        this.yinOk = false;
    }

    public void setYangOk()
    {
        this.yangOk = true;
    }

    public void setYangNotOk()
    {
        this.yangOk = false;
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
