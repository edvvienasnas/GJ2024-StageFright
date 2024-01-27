using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] private float projectileMoveSpeed = 1;
    [SerializeField] private List<Transform> projectiles;
    [SerializeField] private Transform attackRange;

    private List<Vector3> projectileStartingPos = new List<Vector3>();

    private void Awake()
    {
        for(int i = 0; i < projectiles.Count; i++)
        {
            projectileStartingPos.Add(new Vector3());
            projectileStartingPos[i] = projectiles[i].position;
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        for(int i = 0; i < projectiles.Count; i++)
        {
            if(projectiles[i].position.z >= attackRange.position.z)
            {
                projectiles[i].position = new Vector3(
                    projectiles[i].position.x, 
                    projectiles[i].position.y, 
                    projectiles[i].position.z - projectileMoveSpeed * Time.deltaTime);
            }
            else
            {
                projectiles[i].position = projectileStartingPos[i];
            }
        }
    }


}
