using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private List<Projectile> projectiles;
    [SerializeField] private int maxHp = 100;
    [SerializeField] private float projectileMoveSpeed = 1;
    [SerializeField] private Transform attackRange;

    private int currentHp;

    private void Awake()
    {
        healthBar.maxValue = maxHp;
        healthBar.value = maxHp;
    }

    private void Update()
    {
        // Boss Attack
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


}
