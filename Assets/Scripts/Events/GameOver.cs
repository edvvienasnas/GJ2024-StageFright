using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
    [SerializeField] private Text text;
    [SerializeField] private Text nextIndicator;
    [SerializeField] private GameObject fadeout;

    private IEnumerator PrintText(string txt, float textSpeed = 0.05f)
    {
        // Clear current textbox
        text.text = "";

        for(int i = 0; i < txt.Length; i++)
        {
            text.text = text.text + txt[i];
            //yield return null;
            yield return new WaitForSecondsRealtime(textSpeed);
        }

        nextIndicator.gameObject.SetActive(true);
    }

    public IEnumerator PlayGameOver()
    {
        textBox.SetActive(true);

        yield return PrintText("Is that the best you can do?");
        while(!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }
        nextIndicator.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();

        fadeout.SetActive(true);

        yield return PrintText("YOU WILL NEVER BE A STANDUP COMEDIAN!", 0.1f);
        while(!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }
        nextIndicator.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
