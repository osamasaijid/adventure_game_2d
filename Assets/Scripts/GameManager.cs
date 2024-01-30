using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public EnemySpawner enemySpawner;
    public PlayerController player;

    public Action<bool> GameEnded;

    private Vector3 startingPos;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        startingPos = transform.position;
        StartGame();
    }


    public void StopGame()
    {
        enemySpawner.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        enemySpawner.gameObject.SetActive(true);
        player.transform.position = startingPos;
        player.ResetGameSettings();
        EnemyController[] enemyControllers = FindObjectsOfType<EnemyController>();
        if (enemyControllers.Length > 0)
        {
            for (int i = 0; i < enemyControllers.Length; i++)
            {
                Destroy(enemyControllers[i].gameObject);
            }
        }
    }
}
