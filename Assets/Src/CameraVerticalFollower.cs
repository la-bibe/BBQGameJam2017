using UnityEngine;

public class CameraVerticalFollower : MonoBehaviour {

    public GameObject playerYin;
    public GameObject playerYang;

    public Color colorYin;
    public Color colorYang;

    private GameObject[] obstaclesYin;
    private GameObject[] obstaclesYang;
    private GameObject onFocus;

    void Start ()
    {
        this.onFocus = this.playerYin;
        this.obstaclesYin = GameObject.FindGameObjectsWithTag("ObstacleYin");
        this.obstaclesYang = GameObject.FindGameObjectsWithTag("ObstacleYang");

        foreach (GameObject obstacleYin in this.obstaclesYin)
        {
            obstacleYin.GetComponent<SpriteRenderer>().color = this.colorYin;
        }

        foreach (GameObject obstacleYang in this.obstaclesYang)
        {
            obstacleYang.GetComponent<SpriteRenderer>().color = this.colorYang;
        }

        playerYin.GetComponent<SpriteRenderer>().color = this.colorYin;
        playerYang.GetComponent<SpriteRenderer>().color = this.colorYang;

        this.GetComponent<Camera>().backgroundColor = this.colorYin;
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
            this.onFocus = (this.onFocus == this.playerYin) ? this.playerYang : this.playerYin;
        this.transform.position = new Vector3(
            this.transform.position.x,
            this.onFocus.transform.position.y,
            this.transform.position.z
            );
    }
}
