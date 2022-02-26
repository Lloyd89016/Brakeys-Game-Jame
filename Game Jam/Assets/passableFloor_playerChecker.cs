using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passableFloor_playerChecker : MonoBehaviour
{
    public BoxCollider2D parentCollider;
    public bool makeSolid = false;
    // Start is called before the first frame update
    void Start()
    {
        parentCollider = GetComponentInParent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            makeSolid = true;
        }
    }
}
