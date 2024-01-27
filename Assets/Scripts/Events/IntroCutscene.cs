using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroCutscene : MonoBehaviour
{
    [SerializeField] private GameObject lights;
    [SerializeField] private GameObject textBox;
    [SerializeField] private Text text;
    [SerializeField] private Text nextIndicator;

    private void Awake()
    {
        if(lights.activeSelf)
        {
            lights.SetActive(false);
        }

        StartCoroutine(PlayIntroCutscene());
    }

    private IEnumerator PrintText(string txt)
    {
        // Clear current textbox
        text.text = "";

        for(int i = 0; i < txt.Length; i++)
        {
            text.text = text.text + txt[i];
            //yield return null;
            yield return new WaitForSecondsRealtime(0.05f);
        }

        nextIndicator.gameObject.SetActive(true);
    }

    private IEnumerator PlayIntroCutscene()
    {
        textBox.SetActive(true);
        yield return PrintText("Comedy is the best.");
        
        while(!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }
        nextIndicator.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();

        yield return PrintText("One day, I'm going to be the best stand-up comedian ever!");

        while(!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }
        nextIndicator.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();

        lights.SetActive(true);
        textBox.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);

        textBox.SetActive(true);
        yield return PrintText("So then, why does the thought of performing on stage...");

        while(!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }
        nextIndicator.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();

        yield return PrintText("...scare me so much?");

        while(!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }
        nextIndicator.gameObject.SetActive(false);
        textBox.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);

        SceneManager.LoadScene("level1");
    }
}
