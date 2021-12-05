using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoSingleton<ObjectPooling>
{
    public Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();
    public Dictionary<string, GameObject> groupObject = new Dictionary<string, GameObject>();

    public T GetObject<T>(string poolName, T prefab) where T : Component
    {
        return GetObject(poolName, prefab.gameObject).GetComponent<T>();
    }

    public GameObject GetObject(string groupObjectNmae, GameObject objectPrefab)
    {
        if (!objectPool.ContainsKey(groupObjectNmae))
        {
            objectPool[groupObjectNmae] = new Queue<GameObject>();

            CreateGroupObject(groupObjectNmae);

            return Instantiate(objectPrefab);
        }
        else
        {
            if (objectPool[groupObjectNmae].Count > 0)
            {
                GameObject gameObject = objectPool[groupObjectNmae].Dequeue();
                gameObject.SetActive(true);

                objectPool[groupObjectNmae].Enqueue(gameObject);
                return gameObject;
            }
            else
            {
                return Instantiate(objectPrefab);
            }
        }
    }

    private void CreateGroupObject(string poolName)
    {
        if (!groupObject.ContainsKey(poolName))
        {
            GameObject typeParent = new GameObject(poolName);
            typeParent.transform.SetParent(gameObject.transform);
            groupObject.Add(poolName, typeParent);
        }
    }

    public void ReturnObject(string poolName, GameObject obj)
    {
        if (obj == null)
        {
            Debug.Log($"Object {poolName} null");
            return;
        }

        obj.SetActive(false);
        obj.transform.SetParent(groupObject[poolName].transform);

        if (!objectPool.ContainsKey(poolName))
            objectPool[poolName] = new Queue<GameObject>();

        objectPool[poolName].Enqueue(obj);
    }
}
