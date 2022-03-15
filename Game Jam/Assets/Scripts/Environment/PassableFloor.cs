using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassableFloor : MonoBehaviour
{

    public bool isTopBoxCollider;
    public bool isBottomBoxCollider;

    public BoxCollider2D topBoxCollider2D;
    public BoxCollider2D bottomBoxCollider2D;

    private void Start()
    {
        if (isTopBoxCollider)
        {
            topBoxCollider2D = GetComponent<BoxCollider2D>();
        }
        else if (isBottomBoxCollider)
        {
            bottomBoxCollider2D = GetComponent<BoxCollider2D>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTopBoxCollider)
        {
            if (collision.tag == "Player")
            {
                bottomBoxCollider2D.isTrigger = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isTopBoxCollider)
        {
            if (collision.tag == "Player")
            {
                bottomBoxCollider2D.isTrigger = true;
            }
        }
    }

}
