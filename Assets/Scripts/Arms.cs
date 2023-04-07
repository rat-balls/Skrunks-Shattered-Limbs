using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Arms : MonoBehaviour
{
    [SerializeField] private Transform rayTarget;
    [SerializeField] private float distance;
    [SerializeField] private float duration;    

    private void Start() {
        DOTween.Init();
    }

    void Update()
    {  

        if(Vector3.Distance(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(rayTarget.position.x, transform.position.y, rayTarget.position.z)) > distance)
        {
            transform.DOMove(new Vector3(rayTarget.position.x, transform.position.y, rayTarget.position.z), duration);
        }
    }
}
