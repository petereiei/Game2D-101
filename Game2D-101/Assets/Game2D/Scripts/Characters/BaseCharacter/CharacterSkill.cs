using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkill 
{
    public SkillData skillData;

    public Character characterUse { get; private set; }

    public CharacterSkill(Character character, string skillId)
    {
        characterUse = character;

        skillData = GameData.instance.GetSkillDataById(skillId);
    }

    public void UseSkill()
    {
        SplitEffectData(GetEffectData(), out List<SkillEffectData> bulletEffects);
    }

    private List<SkillEffectData> GetEffectData()
    {
        return GameData.instance.GetSkillEffectDataById(skillData.id);
    }

    private void SplitEffectData(List<SkillEffectData> skillEffectList, out List<SkillEffectData> bulletEffect)
    {
        bulletEffect = new List<SkillEffectData>();

        foreach (var effectData in skillEffectList)
        {
            bulletEffect.Add(effectData);
        }
    }

    private void ShootBullets(List<SkillEffectData> bulletEffects)
    {
        BulletFactory.GenerateBullets(this, bulletEffects);
    }
}
