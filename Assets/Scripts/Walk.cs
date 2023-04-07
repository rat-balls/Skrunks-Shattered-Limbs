using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Walk : MonoBehaviour
{
    [SerializeField] private Transform rayTarget;
    [SerializeField] private float distance;
    [SerializeField] private float duration;
    [Space]
    [SerializeField] private Walk thisFoot;
    [SerializeField] private Walk otherFoot;
    [SerializeField] private GroundCheck otherFootGrounded;

    // Update is called once per frame
    

    private void Start() {
        DOTween.Init();
    }
    void Update()
    {   
        if(!otherFootGrounded.isGrounded){
            StartCoroutine(wait());
        } 

        if(Vector3.Distance(transform.position, rayTarget.position) > distance)
        {
            transform.DOMove(rayTarget.position, duration);
            transform.DOLocalMoveY(1, 0.25f);
            StartCoroutine(walkHeight());
        }
    }

    private IEnumerator walkHeight()
    {
        yield return new WaitForSeconds(0.25f);
        transform.DOLocalMoveY(0, 0.25f);
    }

    private IEnumerator wait()
    {
        thisFoot.enabled = false;
        yield return new WaitForSeconds(0.25f);
        thisFoot.enabled = true;
    }

}
