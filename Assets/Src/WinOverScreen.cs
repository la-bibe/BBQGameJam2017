using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinOverScreen : MonoBehaviour {
    public long time;
    public Sprite activeBowl;
    private GameObject scoreManager;
    public Button buttonRestart;
    public Button buttonContinue;
    public GameObject text;
    public string nextScene;
    public string currentScene;

    private int numberRice;
	// Use this for initialization
	void Start () {
        this.scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        buttonRestart.onClick.AddListener(RestartTheScene);
        buttonContinue.onClick.AddListener(NextScene);
        this.nextScene = scoreManager.GetComponent<GameObjectScore>().nextScene;
        this.currentScene = scoreManager.GetComponent<GameObjectScore>().currentScene;

        if (scoreManager.GetComponent<GameObjectScore>().getTimer() <= scoreManager.GetComponent<GameObjectScore>().time5)
        {
            this.numberRice = 5;
        }
        else if (scoreManager.GetComponent<GameObjectScore>().getTimer() <= scoreManager.GetComponent<GameObjectScore>().time4)
        {
            this.numberRice = 4;
        }
        else if (scoreManager.GetComponent<GameObjectScore>().getTimer() <= scoreManager.GetComponent<GameObjectScore>().time3)
        {
            this.numberRice = 3;
        }
        else if (scoreManager.GetComponent<GameObjectScore>().getTimer() <= scoreManager.GetComponent<GameObjectScore>().time2)
        {
            this.numberRice = 2;
        }
        else if (scoreManager.GetComponent<GameObjectScore>().getTimer() <= scoreManager.GetComponent<GameObjectScore>().time1)
        {
            this.numberRice = 1;
        }
        else
        {
            this.numberRice = 0;
        }
        for (int i = 1; i <= this.numberRice; i++)
        {
            GameObject.FindGameObjectWithTag("RiceBowl" + i).GetComponent<SpriteRenderer>().sprite = this.activeBowl;
        }

        Destroy(scoreManager);
	}

    void RestartTheScene()
    {
        SceneManager.LoadScene(currentScene);
    }

    void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
