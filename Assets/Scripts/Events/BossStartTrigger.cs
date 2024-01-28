using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossStartTrigger : MonoBehaviour
{
    [SerializeField] private Animation doorAnim;
    [SerializeField] private GameObject textBox, selectionBox;
    [SerializeField] private GameObject bossHpBar;
    [SerializeField] private string text;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            playerController.anim.SetBool("isWalking", false);
            playerController.enabled = false;

            textBox.SetActive(true);
            textBox.GetComponentInChildren<Text>().text = text;
            if(selectionBox != null)
            {
                selectionBox.SetActive(true);
            }
        }
    }

    public void EnablePlayerControl()
    {
        playerController.enabled = true;
    }

    public void OpenDoor()
    {
        doorAnim.Play();
        StartCoroutine(OpenDoorEvent());
        
    }

    public IEnumerator OpenDoorEvent()
    {
        yield return new WaitForSecondsRealtime(0.2f);

        SceneManager.LoadScene("BossFight");
    }
}
