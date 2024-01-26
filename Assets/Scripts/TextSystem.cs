using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSystem : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject selectionBox;

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
