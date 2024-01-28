using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject enemyHp;
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
        // Cutscene
        enemyHp.SetActive(false);
        textBox.SetActive(true);

        yield return PrintText("Is that the best you can do?");
        while(!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }
        nextIndicator.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();

        fadeout.SetActive(true);

        yield return PrintText("YOU WILL NEVER BE A STAND-UP COMEDIAN!", 0.1f);
        while(!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }
        nextIndicator.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();

        yield return PrintText("...");
        while(!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }
        nextIndicator.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();

        yield return PrintText("But you refused to give up.", 0.025f);
        while(!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }
        nextIndicator.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();

        yield return PrintText("Your attack power has increased!", 0.025f);
        while(!Input.GetButtonDown("Fire1"))
        {
            yield return null;
        }
        nextIndicator.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();

        // Update player stats
        var player = FindObjectOfType<PlayerStats>();
        player.strength ++;

        // Save progress to tracker
        var tracker = FindObjectOfType<ProgressTracker>();
        tracker.playerStrength = player.strength;
        tracker.bossHp = FindObjectOfType<BossManager>().currentHp;

        // Reload level scene
        SceneManager.LoadScene("level1");
    }
}
