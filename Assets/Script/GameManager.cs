using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PoolManager pool;
    public Player player;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
}
