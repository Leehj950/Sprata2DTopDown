using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> PoolDicetionary;

    private void Awake()
    {
        PoolDicetionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools) 
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for(int i = 0;  i < pool.size; i++) 
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }

            PoolDicetionary.Add(pool.tag,queue);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!PoolDicetionary.ContainsKey(tag))
        {
            return null; 
        }

        GameObject obj = PoolDicetionary[tag].Dequeue();
        PoolDicetionary[tag].Enqueue(obj);

        obj.SetActive(true);
        return obj;
    }

}
