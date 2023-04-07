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
    UiBossHealthBar.SetUIHealthBarToActive();
    // Activer les murs
    foreach (var fogWall in fogWalls) {
        fogWall.ActivateFogWall();
        fogWall.GetComponent<Collider>().enabled = true; // activer le collider
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
