using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTran : MonoBehaviour
{
    public void Scene0()
    {
        SceneManager.LoadScene(0);
    }

    public void Scene1()
    {
        SceneManager.LoadScene(1);
    }
}
