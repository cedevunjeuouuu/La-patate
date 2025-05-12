using System;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject playerWinText;

    private void Awake()
    {
        playerWinText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            endScreen.SetActive(true);
            playerWinText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
