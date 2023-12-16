using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    public float gameTime;
    public float maxGameTime = 2 * 10f;

    public PoolManager pool;
    public Player player;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
}
