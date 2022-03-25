using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(goToCheckPoint());
    }

    IEnumerator goToCheckPoint()
    {
        yield return new WaitForSeconds(.1f);
        transform.position = GameObject.Find("CheckPointManager").GetComponent<CheckPointManager>().currentCheckPoint;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
