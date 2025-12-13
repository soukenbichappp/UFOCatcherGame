using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            // 光線がターゲットに当たったときの処理
            other.gameObject.GetComponent<TargetObj>().HitLaser();
            Debug.Log("Hit Target!");
        }
    }
}
