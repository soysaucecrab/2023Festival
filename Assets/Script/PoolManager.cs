using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //프리펩 보관 변수
    public GameObject[] prefabs;
    //풀 담당 리스트
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++) pools[i] = new List<GameObject>();

    }
    
    public GameObject Get(int index)
    {
        GameObject select = null;

        //다른 스크립트에서 사용 -> 놀고있는 오브젝트 접근 -> 발견되면 할당
        foreach (GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        //전부 사용중 -> 새로 생성해서 select에 할당
        if (!select)
        {
            select  = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
