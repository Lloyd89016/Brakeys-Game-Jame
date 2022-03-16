using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TypeWriterEffect : MonoBehaviour
{

    
    [SerializeField] public float typeWriterSpeed = 50f;
    [SerializeField] private float waitingTimeBeforeTyping;
    [SerializeField] private Color textColor;
    [SerializeField] private GameController GameControllerReference;
    

    // private variables
    private List<char> punctuations = new List<char>();
    public bool busy = false;

    private void Start()
    {
        punctuations = new List<char>{ '?', '.', '!', '#', };
    }

    private void Update()
    {
        Debug.Log("Busy");
    }

    public Coroutine Run(string textToType, Text textLabel, float WaitForSeconds)
    {
        return StartCoroutine(typeText(textToType, textLabel, waitingTimeBeforeTyping, textColor));
        
    }

    public Coroutine RunTMP(string textToType, TMP_Text textLabel, float WaitForSeconds)
    {
        if (!busy)
        {
            return StartCoroutine(typeTextTMP(textToType, textLabel, waitingTimeBeforeTyping, textColor));
        }
        return null;

    }

    private IEnumerator typeText(string textToType, Text textLabel, float WaitForSeconds, Color textColor)
    {
        textLabel.text = string.Empty;

        

        yield return new WaitForSeconds(WaitForSeconds);
        textLabel.color = textColor;

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            busy = true;
            t += Time.deltaTime * typeWriterSpeed;
            charIndex = Mathf.FloorToInt(t); 

            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
            textLabel.text = textToType.Substring(0, charIndex);
            yield return null;
        }
        busy = false;
                                 
        textLabel.text = textToType;

        yield return null;
    }

    private IEnumerator typeTextTMP(string textToType, TMP_Text textLabel, float WaitForSeconds, Color textColor)
    {
        textLabel.text = string.Empty;


        yield return new WaitForSeconds(WaitForSeconds);

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            busy = true;
            t += Time.deltaTime * typeWriterSpeed;
            charIndex = Mathf.FloorToInt(t);

            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
            textLabel.text = textToType.Substring(0, charIndex);
            yield return null;
        }
        busy = false;

        textLabel.text = textToType;
        
        
        yield return null;
    }
}
