using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private List<Projectile> projectiles;
    [SerializeField] private int maxHp = 100;
    [SerializeField] private float projectileMoveSpeed = 1;
    [SerializeField] private Transform attackRange;

    private PlayerStats playerStats;
    private int currentHp;
    private bool isDead;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();

        // Init boss HP
        healthBar.maxValue = maxHp;
        healthBar.value = maxHp;

        currentHp = maxHp;
    }

    private void Update()
    {
        // Boss Attack
        if(!isDead)
        {
            for(int i = 0; i < projectiles.Count; i++)
        {
            if(projectiles[i].transform.position.z >= attackRange.position.z)
            {
                projectiles[i].transform.position = new Vector3(
                    projectiles[i].transform.position.x, 
                    projectiles[i].transform.position.y, 
                    projectiles[i].transform.position.z - projectileMoveSpeed * Time.deltaTime);
            }
            else
            {
                projectiles[i].transform.position = projectiles[i].startingPos;
            }
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
        Debug.Log("Something in enemy trigger");
        if(other.tag == "Player Weapon")
        {
            Debug.Log("Player Weapon in enemy trigger");
            currentHp -= playerStats.strength;
            healthBar.value = currentHp;
        }
    }
}
