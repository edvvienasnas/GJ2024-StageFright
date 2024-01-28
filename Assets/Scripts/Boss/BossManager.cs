using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Mathematics;

public class BossManager : MonoBehaviour
{
    [SerializeField] private Transform bossAttackProxy;
    [SerializeField] private Slider healthBar;
    [SerializeField] private List<Projectile> projectiles;
    [SerializeField] private int maxHp = 100;
    //[SerializeField] private float projectileMoveSpeed = 1;
    [SerializeField] private Transform attackRange;
    [SerializeField] private ParticleSystem attack1, attack2;
    [SerializeField] private float attackFrequency = 2;
    private ParticleSystem lastUsedAttack;
    private float baseAttackFrequency;

    private PlayerStats playerStats;
    private int currentHp;
    private bool isDead;

    private void Awake()
    {
        baseAttackFrequency = attackFrequency;
        attackFrequency = 0.5f;
        lastUsedAttack = attack2;

        playerStats = FindObjectOfType<PlayerStats>();

        // Init boss HP
        healthBar.maxValue = maxHp;
        healthBar.value = maxHp;

        currentHp = maxHp;
    }

    private void Update()
    {
        // Boss animating
        if(!isDead)
        {
            var targetPostition = new Vector3( playerStats.transform.position.x, 
                                       this.transform.position.y, 
                                       playerStats.transform.position.z ) ;
            transform.LookAt(targetPostition);
        }

        // Boss Attack
        if(!isDead)
        {
            // Attacks using particles
            attackFrequency -= Time.deltaTime;

            if(attackFrequency <= 0)
            {
                if(lastUsedAttack == attack2)
                {
                    attack1.transform.parent = bossAttackProxy;
                    var playerDirection = new Vector3( playerStats.transform.position.x, 
                                       this.transform.position.y, 
                                       playerStats.transform.position.z ) ;
                    bossAttackProxy.transform.LookAt(playerDirection);

                    attack1.Play();
                    lastUsedAttack = attack1;
                }
                else if(lastUsedAttack == attack1)
                {
                    attack2.transform.parent = bossAttackProxy;
                    attack2.Play();
                    lastUsedAttack = attack2;
                }

                attackFrequency = baseAttackFrequency;
            }


            // Old attack system
            // for(int i = 0; i < projectiles.Count; i++)
            // {
            //     if(projectiles[i].transform.position.z >= attackRange.position.z)
            //     {
            //         projectiles[i].transform.position = new Vector3(
            //             projectiles[i].transform.position.x, 
            //             projectiles[i].transform.position.y, 
            //             projectiles[i].transform.position.z - projectileMoveSpeed * Time.deltaTime);
            //     }
            //     else
            //     {
            //         projectiles[i].transform.position = projectiles[i].startingPos;
            //     }
            // }
        }

        // Boss Death
        if(currentHp <= 0 && !isDead)
        {
            isDead = true;

            foreach(var p in projectiles)
            {
                Destroy(p);
            }

            SceneManager.LoadScene("End");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something in enemy trigger");
        if(other.tag == "Player Weapon")
        {
            Debug.Log("Player Weapon in enemy trigger");
            currentHp -= playerStats.strength;
            healthBar.value = currentHp;
        }
    }
}
