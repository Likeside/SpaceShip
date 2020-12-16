using System.Collections.Generic;
using UnityEngine;

namespace Factories
{
    public class ObjectPooler
    {
        private List<PoolScriptableObject> pools;
        private Dictionary<string, Queue<GameObject>> poolDictionary;

        public ObjectPooler()
        {
            pools = new List<PoolScriptableObject>();
            Resources.LoadAll<PoolScriptableObject>("Pools");
            var poolsFromResources = Resources.FindObjectsOfTypeAll<PoolScriptableObject>();//Добавляем все пул скриптабл обджекты в массив, из массива делаем список
            foreach (var pool in poolsFromResources)
            {
               pools.Add(pool); 
            }
            poolDictionary = new Dictionary<string, Queue<GameObject>>();
            foreach (var pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>(); //Для каждого пула объектов делаем очередь

                for (int i = 0; i < pool.size; i++) //пробегаемся по пулу, создаем его объекты, отключаем их
                {
                 GameObject obj = GameObject.Instantiate(pool.gameObjPrefab);
                 obj.SetActive(false);
                 objectPool.Enqueue(obj);
                    
                }
                
                poolDictionary.Add(pool.tag, objectPool);
            }
        }

        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (poolDictionary.ContainsKey(tag))
            {
                GameObject objectToSpawn = poolDictionary[tag].Dequeue();
                objectToSpawn.SetActive(true);
                objectToSpawn.transform.position = position;
                objectToSpawn.transform.rotation = rotation;
                poolDictionary[tag].Enqueue(objectToSpawn);
                return objectToSpawn;
            }
            else
            {
                Debug.Log("Нет такого пула");
                return null;
            }
        }
    }
}