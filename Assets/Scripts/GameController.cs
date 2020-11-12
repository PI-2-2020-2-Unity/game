﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Time timer;

    public int maxEnemies = 15;

    public GameObject enemyPointer;
    public float enemyPointerRadius = 1f;
    private float enemyPointerAngle = 0f;
    private RectTransform enemyPointerTransform;

    public List<Enemy1> enemies;
    public GameObject player;
    public GameObject objectToSpawn;
    public texto text;
    public int randomRange = 30;
    public float spawnTime;

    int Difficulty;

    Camera mainCamera;

    //public Enemy2[] enemies2;
    //public Enemy3[] enemies3;
    //public Boss[] bosses;

    // Start is called before the first frame update
    void Start()
    {
        enemyPointerTransform = enemyPointer.GetComponent<RectTransform>();

        this.Difficulty = 0;
        this.mainCamera = Camera.main;

        setDifficulty(0);
        StartCoroutine(EnemySpawn());
    }

    void Update()
    {
        if(enemyPointer.activeSelf)
        {
            enemyPointerTransform.anchoredPosition = new Vector2(
                Mathf.Cos(enemyPointerAngle),
                Mathf.Sin(enemyPointerAngle)
            )*enemyPointerRadius;

            enemyPointerTransform.eulerAngles = new Vector3(
                0f,
                0f,
                enemyPointerAngle
            );
        }
    }

    void Win()
    {

    }

    public void Lose()
    {
        foreach(Enemy1 e in enemies)
        {
            if(e != null)
                Destroy(e.gameObject);
        }

        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void setDifficulty(int d)
    {
        // Do something with the difficulty
        this.Difficulty = d;

        // TODO
        mainCamera.backgroundColor = Color.black;
    }

    IEnumerator EnemySpawn()
    {
        while (enemies.Count < maxEnemies)
        {
            Vector3 spawnPos = new Vector3(
                player.transform.position.x + Random.Range(-randomRange, randomRange),
                player.transform.position.y + Random.Range(-randomRange, randomRange),
                0f
            );
            GameObject enemy = Instantiate(objectToSpawn, spawnPos, player.transform.rotation);

            Enemy1 enemy1 = enemy.GetComponent<Enemy1>();

            enemy1.player = player.transform;
            enemy1.target = player;
            enemy1.controller = this;

            enemies.Add(enemy1);
            spawnTime = Random.Range(0, 10);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
// vim: set expandtab:
