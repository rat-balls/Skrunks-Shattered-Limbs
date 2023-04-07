using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{   
    private bool CD = false;

    [SerializeField] private Transform check;
    public AudioSource Source; //Player Audio Source
    public AudioClip swordHit; //Sound clips
    
    void Update()
    {
        RaycastHit hit = new RaycastHit();
        
        if(Physics.Raycast(check.position, check.forward, out hit, 1) && !CD){
            if(hit.collider.CompareTag("Enemy")){
                Source.PlayOneShot(swordHit);
                Debug.Log("Hit");
                HealthScript HPscript = hit.collider.gameObject.GetComponent<HealthScript>();
                HPscript.HP -= 25f;
                StartCoroutine(attackCD(0.75f));
            }
        }
    }

    IEnumerator attackCD(float time)
    {   
        CD = true;
        yield return new WaitForSeconds(time);
        CD = false;
    }
}
