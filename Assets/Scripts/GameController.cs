using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Time timer;
    public Enemy1[] enemies;
    public int enemiesCount;
    public GameObject player;
    public GameObject objectToSpawn;
    public int randomRange = 30;
    public float spawnTime;
    //public Enemy2[] enemies2;
    //public Enemy3[] enemies3;
    //public Boss[] bosses;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new Enemy1[15];
        enemiesCount = 0;
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Cada cierto tiempo spawnear enemigos usando Instantiate
    }

    void Win()
    {

    }

    void Loss()
    {

    }

    IEnumerator EnemySpawn()
    {
        while (enemiesCount < 15)
        {
            Vector3 spawnPos = new Vector3(player.transform.position.x + Random.Range(-randomRange, randomRange), 0, player.transform.position.z + Random.Range(-randomRange, randomRange));
            Instantiate(objectToSpawn, spawnPos, player.transform.rotation);
            enemiesCount++;
            spawnTime = Random.Range(0, 10);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
