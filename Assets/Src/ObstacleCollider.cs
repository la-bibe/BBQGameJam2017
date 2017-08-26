using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider: MonoBehaviour {

    public void setPlayerIgnore(GameObject player)
    {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
    }
}
