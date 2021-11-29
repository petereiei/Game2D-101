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

    public List<SkillEffectData> GetSkillEffectDataById(string skillId)
    {
        return rawSkillData.skillEffectDatas.FindAll(s => s.skillId == skillId);
    }

    public List<RawSkillBulletData> GetSkillBulletDataBySkillId(string skillId)
    {
        return rawSkillData.skillBulletData.FindAll(s => s.skillId == skillId);
    }
}
