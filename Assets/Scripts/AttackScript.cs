using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackScript : MonoBehaviour
{
    [SerializeField] public bool attacking = false;
    [SerializeField] private Vector3 dir;
    [SerializeField] private RigidbodyMovement movementScript;

    private void Start() {
        DOTween.Init();
    }

    // Update is called once per frame
    void Update()
    {   
        dir = movementScript.moveVector;

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            attacking = true;
            transform.DOMove(new Vector3(dir.x, transform.position.y, dir.z), 0.5f);
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            attacking = false;
        }
    }
}
