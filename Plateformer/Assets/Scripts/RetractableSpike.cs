using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class RetractableSpike : MonoBehaviour
{
    [SerializeField] private float waitTime = 2f;
    bool isOut;
    private void Awake()
    {
        StartCoroutine(SpikeRetract());
    }

    IEnumerator SpikeRetract()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            isOut = !isOut;
            if (isOut)
            {
                transform.DOMove(new Vector3(transform.position.x, transform.position.y + 0.8f, 0), 0.3f);
            }
            else
            {
                transform.DOMove(new Vector3(transform.position.x, transform.position.y - 0.8f, 0), 0.3f);
            }
        }
    }
}
