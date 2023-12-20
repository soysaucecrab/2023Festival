using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("#Player Information")]
    public float health;
    public float maxHealth;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = {10,30,60,100,250,210,280,360,450,600 };

    [Header("#Game Control")]
    public bool isLive;
    public float gameTime;
    public float maxGameTime = 2 * 10f;

    [Header("#Game Object")]
    public PoolManager pool;
    public Player player;
    public LevelUp uiLevelUp;
    public Result uiResult;
    public Object enemyCleaner;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void GameStart()
    {
        maxHealth = 100;
        health = maxHealth;

        //임시 스크립트
        uiLevelUp.Select(0);

        isLive= true;
    }

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        isLive= false;
        yield return new WaitForSeconds(0.5f);
        uiResult.gameObject.SetActive(true);
        uiResult.Lose();
        Stop();
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if(!isLive)
        {
            return;
        }

        gameTime += Time.deltaTime;
        
        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    public void GetExp(int n)
    {
        exp = exp + n;
        if(exp >= nextExp[Mathf.Min(level, nextExp.Length-1)])
        {
            exp = exp - nextExp[Mathf.Min(level, nextExp.Length - 1)];
            level++;
            uiLevelUp.Show();
        }
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}
