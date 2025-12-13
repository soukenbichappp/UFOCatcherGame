using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObj : MonoBehaviour
{
    [SerializeField, Header("‰½•b‚Å¬‚³‚­‚È‚é‚©")] private float _reductionTime = 0.5f;
    [SerializeField, Header("‰½•b‚Å¸‚Á‚Ä‚¢‚­‚©")] private float _risingTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void HitLaser()
    {
        Vector3 ReductionScale = new Vector3(transform.localScale.x / 10, transform.localScale.y / 10, transform.localScale.z / 10);
        transform.DOScale(ReductionScale, _reductionTime).OnComplete(async () =>
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
            transform.DOMoveY(100, _risingTime).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        });
    }
}
