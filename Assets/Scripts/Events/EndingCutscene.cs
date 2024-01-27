using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingCutscene : MonoBehaviour
{
    [SerializeField] private GameObject lights;
    [SerializeField] private GameObject textBox;
    [SerializeField] private Text text;
    [SerializeField] private Text nextIndicator;

    private void Awake()
    {
        StartCoroutine(PlayEndingCutscene());
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

    private IEnumerator PlayEndingCutscene()
    {
        textBox.SetActive(true);

        yield return PrintText("Umm... What was I so nervous about again?");
        while(!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }
        nextIndicator.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();

        yield return PrintText("Oh, they're calling my name.");
        while(!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }
        nextIndicator.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();

        lights.SetActive(false);

        yield return PrintText("Looks like it's my turn to perform.");
        while(!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }
        nextIndicator.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();

        textBox.SetActive(false);

        yield return new WaitForSecondsRealtime(5);

        //Load title screen
    }
}