using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetObj : MonoBehaviour
{
    [SerializeField, Header("‰½•b‚Å¬‚³‚­‚È‚é‚©")] private float _reductionTime = 0.5f;
    [SerializeField, Header("‰½•b‚Å¸‚Á‚Ä‚¢‚­‚©")] private float _risingTime = 0.5f;
    [SerializeField, Header("ƒ^[ƒQƒbƒg")] private GameObject _targetObj;

    

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
        Vector3 ReductionScale = Vector3.one * 2;
        if (gameObject.name == "BigTargetObj")
        {
            ReductionScale = new Vector3(transform.localScale.x / 8, transform.localScale.y / 8, transform.localScale.z / 8);
        }
        transform.DOScale(ReductionScale, _reductionTime).OnComplete(async () =>
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
            transform.DOMove(_targetObj.transform.position, _risingTime).OnComplete(() =>
            {
                //_targetObj.GetComponent<PlayerController>().AbsorbedCount++;
                Destroy(gameObject);
            });
        });

        await UniTask.Yield();
    }
}
