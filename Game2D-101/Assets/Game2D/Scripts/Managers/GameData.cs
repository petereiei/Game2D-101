using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoSingleton<GameData>
{
    [SerializeField] private RawSkillData rawSkillData;

    public SkillData GetSkillDataById(string skillId)
    {
        return rawSkillData.skillDatas.Find(skill => skill.id == skillId);
    }
}
