using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public RawSkillData rawSkillData;

    private void Start()
    {
        Debug.Log(rawSkillData.skillDatas[0].id + " / " + rawSkillData.skillDatas[0].castTime);
        Debug.Log(rawSkillData.skillDatas[1].id + " / " + rawSkillData.skillDatas[1].castTime);
    }

    public GameObject Instantiate(GameObject prefab)
    {
        return Instantiate(prefab);
    }
}
