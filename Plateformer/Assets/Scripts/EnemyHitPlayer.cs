using System;
using System.Collections;
using UnityEngine;

public class EnemyHitPlayer : MonoBehaviour
{
    GameManager gameManagerRef;
    [SerializeField] bool isDeathZone;
    private bool canTouchPlayer = false;
    private void Awake()
    {
        gameManagerRef = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (isDeathZone)
        {
            gameManagerRef.endScreen.SetActive(false);
            gameManagerRef.enemyText.SetActive(false);
            canTouchPlayer = true;
        }
        else
        {
            StartCoroutine(WaitForStartGame());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ça trigger");
        if (other.CompareTag("Player")&& canTouchPlayer)
        {
            Debug.Log("ça trigger le player");
            gameManagerRef.endScreen.SetActive(true);
            gameManagerRef.enemyText.SetActive(true);
            other.transform.position = new Vector3(-7, -3, 0);
            Time.timeScale = 0;
        }
        else if (other.CompareTag("Enemy"))
        {
            other.transform.position = new Vector3(-7, -3, 0);
        }
    }

    IEnumerator WaitForStartGame()
    {
        yield return new WaitForSeconds(0.2f);
        canTouchPlayer = true;
    }
}
