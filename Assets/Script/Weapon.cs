using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count; //set n
    public int speed; //rotation

    void Start()
    {
        Init();
    }

    public void Init()
    {
        switch(id)
        {
            case 0:
                speed = 150;
                Batch();
                break;

            default: break;
        }
    }

    void Batch()
    {
        for(int i = 0; i < count; i++)
        {
            Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
            bullet.parent = transform;
            bullet.GetComponent<Bullet>().Init(damage, -1); //infinity per ; sword
        }
    }

    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime); //clock
                break;

            default: break;
        }
    }
}
