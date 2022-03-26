using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level007TextManager : MonoBehaviour
{
    public Text motherText;
    public Text FatherText;

    void Start()
    {
        StartCoroutine(enemyTalk());
    }

    IEnumerator enemyTalk()
    {
        //Mother Text line
        motherText.text = "What are you doing here?";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(3);

        //Father Text Line
        FatherText.text = "What are you doing here?";
        yield return new WaitForSeconds(3);
        FatherText.text = "";
        yield return new WaitForSeconds(3);

    }
}
