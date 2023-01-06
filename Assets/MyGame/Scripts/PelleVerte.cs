using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PelleVerte : MonoBehaviour
{
    [SerializeField] GameObject pelle;

    //public void OnSenBatsLesCouilles(){}
    

    // Start is called before the first frame update
    void Start()
    {
        pelle.GetComponent<MeshRenderer>().material.DOFade(0.8f, 1).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
