using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggerController : MonoBehaviour {

    public GameObject objectToMove;
    public bool invertedAction = false;
    public bool multipleUse = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            objectToMove.GetComponent<DynamicObstacle>().moved = !this.invertedAction;
            if (!multipleUse)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
