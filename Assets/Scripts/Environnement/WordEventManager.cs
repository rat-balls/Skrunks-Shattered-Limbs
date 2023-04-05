using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WordEventManager : MonoBehaviour {
    
    // Fog Wall
    public List<FogWall> fogWalls;
    public UIBossHealthBar UiBossHealthBar;
    public EnemyBossManager boss;

    // Corrected variable name
    public bool bossFightIsActive;
    public bool bossHasBeenAwakened;
    public bool bossHasBeenDefeated;

    private void Awake() {
        // Corrected variable name
        UiBossHealthBar = FindObjectOfType<UIBossHealthBar>();
    }

    public void ActivateBossfight() {
        bossFightIsActive = true;
        bossHasBeenAwakened = true;
        // Corrected variable name
        UiBossHealthBar.SetUIHealthBarToActive();
        // Active le mur
        foreach (var fogWalls in fogWalls) 
        {
            fogWalls.ActivateFogWall();
        }

    }

    public void BossHasBeenDefeated() {
        bossHasBeenDefeated = true;
        bossFightIsActive = false;
        // Désactive le mur
        foreach (var fogWalls in fogWalls) 
        {
            fogWalls.DeactivateFogWall();
        }

    }
}
