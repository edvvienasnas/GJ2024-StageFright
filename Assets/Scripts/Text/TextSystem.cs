using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextSystem : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject selectionBox;
    [SerializeField] private Text nextIndicator;
    private bool indicatorIsAnimating;

    private void Update()
    {
        if(nextIndicator.gameObject.activeSelf && !indicatorIsAnimating)
        {
            StartCoroutine(NextIndicatorAnimation());
        }

        else if(!nextIndicator.gameObject.activeSelf && indicatorIsAnimating)
        {
            indicatorIsAnimating = false;
        }
    }

    private IEnumerator NextIndicatorAnimation()
    {
        indicatorIsAnimating = true;

        while(nextIndicator.gameObject.activeSelf)
        {
            nextIndicator.text = ">";
            yield return new WaitForSecondsRealtime(0.5f);

            nextIndicator.text = "> ";
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }

    public void SelectionYes()
    {
        Debug.Log("yes");

        textBox.SetActive(false);
        selectionBox.SetActive(false);
    }

    public void SelectionNo()
    {
        Debug.Log("no");

        textBox.SetActive(false);
        selectionBox.SetActive(false);
    }
}
