using UnityEngine;

public class CameraVerticalFollower : MonoBehaviour {

    public GameObject associatedPlayer;
    public GameObject clonePlayer;

    public string obstaclesTag;
    public string oppositeObstaclesTag;

    public Color associatedColor;

    void Start ()
    {
        GameObject[] obstacles;
        obstacles = GameObject.FindGameObjectsWithTag(this.obstaclesTag);

        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<SpriteRenderer>().color = this.associatedColor;
        }

        obstacles = GameObject.FindGameObjectsWithTag(this.oppositeObstaclesTag);

        foreach (GameObject obstacle in obstacles)
        {
            obstacle.AddComponent<PolygonCollider2D>();
            obstacle.AddComponent<ObstacleCollider>();
            obstacle.GetComponent<ObstacleCollider>().setPlayerIgnore(this.associatedPlayer);
        }

        associatedPlayer.GetComponent<SpriteRenderer>().color = this.associatedColor;
        clonePlayer.GetComponent<SpriteRenderer>().color = this.associatedColor;
    }
	
	void Update ()
    {
        this.transform.position = new Vector3(
            this.transform.position.x,
            this.associatedPlayer.transform.position.y,
            this.transform.position.z
            );
    }
}
