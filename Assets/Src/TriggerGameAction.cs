using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerGameAction : MonoBehaviour
{
    public GameObject expectedPlayer = null;

    public UnityEvent toCallOnTriggerEnter = null;
    public UnityEvent toCallOnTriggerExit = null;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (this.toCallOnTriggerEnter != null && collider.gameObject.tag == "Player")
        {
            if (this.expectedPlayer == null || collider.gameObject == this.expectedPlayer)
            {
                toCallOnTriggerEnter.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (this.toCallOnTriggerExit != null && collider.gameObject.tag == "Player")
        {
            if (this.expectedPlayer == null || collider.gameObject == this.expectedPlayer)
            {
                toCallOnTriggerExit.Invoke();
            }
        }
    }
}
