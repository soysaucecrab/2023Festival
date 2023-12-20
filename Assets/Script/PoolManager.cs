using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //������ ���� ����
    public GameObject[] prefabs;
    //Ǯ ��� ����Ʈ
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++) pools[i] = new List<GameObject>();

    }
    
    public GameObject Get(int index)
    {
        GameObject select = null;

        //�ٸ� ��ũ��Ʈ���� ��� -> ����ִ� ������Ʈ ���� -> �߰ߵǸ� �Ҵ�
        foreach (GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        //���� ����� -> ���� �����ؼ� select�� �Ҵ�
        if (!select)
        {
            select  = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
