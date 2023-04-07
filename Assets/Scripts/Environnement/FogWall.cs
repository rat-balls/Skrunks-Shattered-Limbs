using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogWall : MonoBehaviour {

    private Collider wallCollider; // Ajout d'une variable pour stocker le collider

    void Start() {
        // Récupérer le collider attaché à l'objet
        wallCollider = GetComponent<Collider>();
        // Désactiver le rendu et le collider au début
        SetFogWallActive(false);
    }

    public void ActivateFogWall() {
        SetFogWallActive(true);
        // Désactiver le collider
        wallCollider.enabled = false;
    }

    public void DeactivateFogWall() {
        SetFogWallActive(false);
        // Réactiver le collider
        wallCollider.enabled = true;
    }

    private void SetFogWallActive(bool active) {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(active);
        }
    }
}

