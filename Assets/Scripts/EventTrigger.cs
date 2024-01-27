using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private GameObject textBox, selectionBox;
    [SerializeField] private string text;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Something is in trigger");
        if(other.gameObject.name == "Player")
        {
            //Debug.Log("Player is in trigger");
            textBox.SetActive(true);
            textBox.GetComponentInChildren<Text>().text = text;
            if(selectionBox != null)
            {
                selectionBox.SetActive(true);
            }
        }
    }
}
