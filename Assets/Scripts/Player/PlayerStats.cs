using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int hp = 3;
    [SerializeField] private List<Image> hpIndicator;

    private void Update()
    {
        if(hp <= 0)
        {
            Debug.Log("You died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            hp--;
            if(hp == 2) hpIndicator[2].enabled = false;
            else if(hp == 1) hpIndicator[1].enabled = false;
            else if(hp <= 0) hpIndicator[0].enabled = false;

            Debug.Log("You got hit");
        }
    }
}
