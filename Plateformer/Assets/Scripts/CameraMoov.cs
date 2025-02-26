using System;
using UnityEngine;

public class CameraMoov : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] private Vector3 offSett;

    private void Update()
    {
        if (target)
        {
            transform.position = target.position + offSett;
        }
    }
}
