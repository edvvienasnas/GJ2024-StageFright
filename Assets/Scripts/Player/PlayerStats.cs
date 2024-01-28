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
    public int strength = 1;
    [SerializeField] private List<Image> hpIndicator;

    private Animator anim;
    private bool isDead;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(hp <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("You died");
            anim.SetTrigger("hasDied");

            GetComponent<PlayerController>().enabled = false;

            StartCoroutine(FindObjectOfType<GameOver>().PlayGameOver());
        }
    }

    private void OnParticleCollision()
    {
        hp--;
        if(hp == 2) hpIndicator[2].enabled = false;
        else if(hp == 1) hpIndicator[1].enabled = false;
        else if(hp <= 0) hpIndicator[0].enabled = false;

        Debug.Log("You got hit");
    }
}
