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
    [HideInInspector] public int currentHp;
    private bool isDead;

    private void Start()
    {
        baseAttackFrequency = attackFrequency;
        attackFrequency = 0.5f;
        lastUsedAttack = attack2;

        playerStats = FindObjectOfType<PlayerStats>();

        // Init boss HP
        healthBar.maxValue = maxHp;
        healthBar.value = currentHp;
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
        if(other.tag == "Player Weapon")
        {
            currentHp -= playerStats.strength;
            healthBar.value = currentHp;
        }
    }
}
