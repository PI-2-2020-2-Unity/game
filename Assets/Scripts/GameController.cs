using System.Collections;
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
    private Transform targetTransform;

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

        setDifficulty(1);
        StartCoroutine(EnemySpawn());
    }

    public void updateTarget(int val1)
    {
        foreach(Enemy1 enemy in enemies)
        {
            if(enemy.getValor() == texto.respuesta[val1])
            {
                enemyPointer.SetActive(true);
                targetTransform = enemy.transform;
                return;
            }
        }
    }

    bool inScreen(Transform transform)
    {
        Vector3 position = mainCamera.WorldToViewportPoint(transform.position);

        return
            position.x >= 0.0f && position.x <= 1.0f &&
            position.y >= 0.0f && position.y <= 1.0f
        ;
    }

    void Update()
    {
        if(targetTransform)
            enemyPointer.SetActive(!inScreen(targetTransform));

        if(enemyPointer.activeSelf && targetTransform != null && player)
        {
            Vector2 dist = targetTransform.position - player.transform.position;

            enemyPointerAngle = Mathf.Atan2(dist.y, dist.x);

            enemyPointerTransform.anchoredPosition = new Vector2(
                Mathf.Cos(enemyPointerAngle),
                Mathf.Sin(enemyPointerAngle)
            )*enemyPointerRadius;

            enemyPointerTransform.eulerAngles = new Vector3(
                0f,
                0f,
                enemyPointerAngle*Mathf.Rad2Deg
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

    public int getDifficulty()
    {
        return this.Difficulty;
    }

    IEnumerator EnemySpawn()
    {
        while (enemies.Count < maxEnemies && player)
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
