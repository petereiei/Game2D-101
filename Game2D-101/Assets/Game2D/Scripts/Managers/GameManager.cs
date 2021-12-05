using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public RawSkillData rawSkillData;

    public void ReturnObject(string path, GameObject gameObject, float delay = 0f)
    {
        StartCoroutine(PoolingReturnObject(path, gameObject, delay));
    }

    private IEnumerator PoolingReturnObject(string path, GameObject gameObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        ObjectPooling.instance.ReturnObject(path, gameObject);
    }
}