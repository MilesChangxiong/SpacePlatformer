using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText; 
    public GameObject gameWinText;  

    private void Start()
    {
        gameOverText.SetActive(false);
        gameWinText.SetActive(false);
    }

 /*   public void StopAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemyGameObject in enemies)
        {
            EnemyFollow enemy = enemyGameObject.GetComponent<EnemyFollow>();
            Rigidbody2D rb = enemyGameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
            if (enemy != null) 
            {
                Debug.Log("StopAllEnemies called!");
                enemy.enabled = false;
            }

        }
    }
*/
    public void OnPlayerDefeated()
    {
        //StopAllEnemies();
        gameOverText.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnPlayerWin()
    {
        //StopAllEnemies();
        gameWinText.SetActive(true);
        Time.timeScale = 0;
    }
}
