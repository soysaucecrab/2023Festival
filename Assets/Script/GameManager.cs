using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
}
