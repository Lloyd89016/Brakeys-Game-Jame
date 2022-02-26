using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassableFloor : MonoBehaviour
{

    public BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        boxCollider.isTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        boxCollider.isTrigger = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        boxCollider.isTrigger = true;
    }
}
