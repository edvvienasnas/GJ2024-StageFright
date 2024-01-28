using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    public int playerStrength = 1;
    public int bossHp = 500;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


}
