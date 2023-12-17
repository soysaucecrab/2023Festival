using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;
    public float fast;
    float speed;
    Vector3 dir;
    Rigidbody2D rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        speed = fast;
    }
    public void Init(float damage, int per, Vector3 dir)
    {
        this.damage = damage;
        this.per = per;
        this.dir = dir;

        if(per > -1)
        {
            rigid.velocity = dir * fast;
        }
    }

    void Update() //ÃÑ¾Ë ºø³ª°¨ ¹æÁö
    {
        Vector3 myPos = transform.position;
        Vector3 targetPos = GameManager.instance.player.transform.position;
        float curDiff = Vector3.Distance(myPos, targetPos);
        if (curDiff > 100)
        {
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || per==-1)
        {
            return;
        }
        per--;
        speed = speed * 0.9f;
        rigid.velocity = dir * speed;



        if (per < 0) {
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }
}
