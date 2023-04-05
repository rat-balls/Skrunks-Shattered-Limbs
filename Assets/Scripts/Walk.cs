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
    [SerializeField] private Walk otherFoot;
    [SerializeField] private GroundCheck otherFootGrounded;

    // Update is called once per frame
    

    private void Start() {
        DOTween.Init();
    }
    void Update()
    {   
        if(Vector3.Distance(transform.position, rayTarget.position) > distance && otherFootGrounded.isGrounded)
        {
            transform.DOMove(rayTarget.position, duration);
            transform.DOLocalMoveY(1, 0.25f);
            StartCoroutine(walkHeight());
            StartCoroutine(wait());
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        otherFoot.enabled = true;
        this.enabled = false;
    }

    private IEnumerator walkHeight()
    {
        yield return new WaitForSeconds(0.25f);
        transform.DOLocalMoveY(0, 0.25f);
    }

}
