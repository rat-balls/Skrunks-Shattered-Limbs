using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class fixDistance : MonoBehaviour
{
    
    [SerializeField] private float dist;
    [SerializeField] private Transform shoulder;
    [SerializeField] private Transform hand;

    void Start()
    {
        DOTween.Init();
    }

    // Update is called once per frame
    void Update()
    {

       if(Vector3.Distance(transform.position, shoulder.position) > dist)
       {
        transform.DOMove(hand.position, 0.5f);
       }
    }
}
