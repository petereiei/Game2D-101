using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEffect : MonoBehaviour
{
    public abstract void Apply(Character target);
    public SkillEffectData effectData;
    public CharacterSkill sourceSkill;
    public Bullet bulletSkill;
    public abstract void Remove();

    public void InitializeEffectData(CharacterSkill ownerSkill, Bullet bullet, SkillEffectData rawEffectData)
    {
        sourceSkill = ownerSkill;
        effectData = rawEffectData;
        bulletSkill = bullet;
    }
}
