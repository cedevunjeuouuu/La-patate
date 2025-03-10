using System.Collections;
using UnityEngine;

public class GameManagerActivate : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;

    private void Start()
    {
        StartCoroutine(WaitForActivate());
    }

    IEnumerator WaitForActivate()
    {
        yield return new WaitForSeconds(0.2f);
        gameManager.SetActive(true);
    }
}
