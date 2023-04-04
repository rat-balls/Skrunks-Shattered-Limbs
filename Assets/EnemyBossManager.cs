using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossManager : MonoBehaviour
{

    public string bossName;

    UIBossHealthBar bossHealthBar;

    private void Awake()
    {
        bossHealthBar = FindObjectOfType<UIBossHealthBar>();
    }

    private void Start()
    {
        bossHealthBar.SetBossName(bossName);
    }
}
