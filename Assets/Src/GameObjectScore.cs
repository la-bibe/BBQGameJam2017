using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectScore : MonoBehaviour {
    public string nextScene;
    public string currentScene;
    public float time1;
    public float time2;
    public float time3;
    public float time4;
    public float time5;
    private float timer;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    public float getTimer()
    {
        return this.timer;
    }

    void Update()
    {
        this.timer += Time.deltaTime;
    }
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
