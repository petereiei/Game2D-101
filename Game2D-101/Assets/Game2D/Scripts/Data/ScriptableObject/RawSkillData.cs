using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RawSkillData")]
public class RawSkillData : ScriptableObject
{
    public List<SkillData> skillDatas;
    public List<SkillEffectData> skillEffectDatas;
    public List<RawSkillBulletData> skillBulletData;
}
