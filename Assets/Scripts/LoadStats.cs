using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadStats : MonoBehaviour
{
    private void Awake()
    {
        var tracker = FindObjectOfType<ProgressTracker>();
        var player = FindObjectOfType<PlayerStats>();
        var boss = FindObjectOfType<BossManager>();

        player.strength = tracker.playerStrength;
        boss.currentHp = tracker.bossHp;
    }
}
