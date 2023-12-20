using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;
    public float[] speedness;

    float[] timer;
    int level;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        timer = new float[spawnData.Length];
        Debug.Log(spawnData.Length);
    }
    void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length-1);

        for (int i = 0; i <level+1;i++)
        {
            timer[i] += Time.deltaTime;
        }
        for(int i = 0;i < level+1; i++)
        {
            if (timer[i] > spawnData[i].spawnTime * (speedness[Mathf.Min(speedness.Length, level)]))
            {
                timer[i] = 0;
                Spawn(i);
            }
        }
        
    }

    void Spawn(int num)
    {
        GameObject enemy = GameManager.instance.pool.Get(0); //range는 enemy 개수임
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[num]);
    }
}

[System.Serializable] //속성화
public class SpawnData
{
    public float spawnTime;

    public int spriteType;
    public int health;
    public float speed;

    [Header("속성값")]
    public bool isMouse;
    public bool isQu;
}