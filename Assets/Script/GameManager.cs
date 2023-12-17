using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("#Player Information")]
    public int health;
    public int maxHealth;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = {10,30,60,100,250,210,280,360,450,600 };

    [Header("#Game Control")]
    public float gameTime;
    public float maxGameTime = 2 * 10f;

    [Header("#Game Object")]
    public PoolManager pool;
    public Player player;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        maxHealth = 100;
        health = maxHealth;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    public void GetExp(int n)
    {
        exp = exp + n;
        if(exp >= nextExp[level])
        {
            exp = exp - nextExp[level];
            level++;
        }
    }
}
