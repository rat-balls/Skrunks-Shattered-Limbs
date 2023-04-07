using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] public float HP = 100f;
    [SerializeField] private GameObject monster;
    [SerializeField] public Slider healthBar;

    // Update is called once per frame
    void Update()
    {   
        healthBar.value = HP;

        if(HP <= 0)
        {
            Destroy(monster);
        }
    }
}
