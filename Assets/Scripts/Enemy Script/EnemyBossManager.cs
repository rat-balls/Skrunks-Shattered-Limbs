using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossManager : MonoBehaviour
{
    public string bossName;

    UIBossHealthBar bossHealthBar;
    Boss boss;

    private void Awake()
    {
        bossHealthBar = FindObjectOfType<UIBossHealthBar>();
        boss = GetComponent<Boss>();
    }

    private void Start()
    {
        bossHealthBar.SetBossName(bossName);
        bossHealthBar.SetBossMaxHealth(Mathf.RoundToInt(boss.MaxHealth));
        bossHealthBar.SetBossCurrentHealth(Mathf.RoundToInt(boss.CurrentHealth));
    }
}
