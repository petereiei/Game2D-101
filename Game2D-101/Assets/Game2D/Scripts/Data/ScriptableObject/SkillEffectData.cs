using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillEffectData 
{
    public string skillId;
    public string skillName;
    public float duration;
    public float value;
    public EffectType effectType;
}

public enum EffectType
{
    Attack,
    Buff,
    Debuff
}
