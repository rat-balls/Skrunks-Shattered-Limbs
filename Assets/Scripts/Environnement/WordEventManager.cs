using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WordEventManager : MonoBehaviour {
    
    // Fog Wall
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
    }

    public void BossHasBeenDefeated() {
        bossHasBeenDefeated = true;
        bossFightIsActive = false;
        // Désactive le mur
    }
}
