using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkill 
{
    public SkillData skillData;

    public CharacterSkill(Character character, string skillId)
    {
        skillData = GameData.instance.GetSkillDataById(skillId);
    }

    public void SetSkill()
    {

    }
}
