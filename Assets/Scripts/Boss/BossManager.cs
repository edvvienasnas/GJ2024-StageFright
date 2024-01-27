using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] private float projectileMoveSpeed = 1;
    [SerializeField] private List<Projectile> projectiles;
    [SerializeField] private Transform attackRange;

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
