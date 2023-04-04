using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Walk : MonoBehaviour
{
    [SerializeField] private Transform rayTarget;
    [SerializeField] private float distance;
    [SerializeField] private float duration;
    // Update is called once per frame

    private void Start() {
        DOTween.Init();
    }
    void Update()
    {
        if(Vector3.Distance(transform.position, rayTarget.position) > distance)
        {
            transform.DOMove(rayTarget.position, duration);
        }
    }
}
