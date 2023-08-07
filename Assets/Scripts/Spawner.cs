using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject astroid;
    public GameObject satalite;
    private Vector2 spawnPos1;
    private Vector2 spawnPos2;
    private Vector2 spawnPos3;
    private Vector2 spawnPos4;
    private Vector2 spawnPos5;


    private void Start()
    {
        //ABSRACTION
        StartCoroutine(SpawnCycle());
    }

    IEnumerator SpawnCycle()
    {
        spawnPos1 = new Vector2(Random.Range(-7.0f, -4.5f), 6);
        SpawnNewObject(spawnPos1);
        spawnPos2 = new Vector2(Random.Range(-5.0f, -2.5f), 6);
        SpawnNewObject(spawnPos2);
        spawnPos3 = new Vector2(Random.Range(-3.0f, -0.5f), 6);
        SpawnNewObject(spawnPos3);
        spawnPos4 = new Vector2(Random.Range(0.0f, 2.5f), 6);
        SpawnNewObject(spawnPos4);
        spawnPos5 = new Vector2(Random.Range(5.0f, 7.0f), 6);
        SpawnNewObject(spawnPos5);

        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnCycle());
    }

    public void SpawnNewObject(Vector2 spawnPos)
    {
        if (Random.Range(0, 10) > GameManager.Instance.spawnChance)
        {
            if(Random.Range(0, 10) < 8)
            {
                Instantiate(astroid, spawnPos, Quaternion.identity);
            }
            else
            {
                Instantiate(satalite, spawnPos, Quaternion.identity);
            }

        }

    }

}
