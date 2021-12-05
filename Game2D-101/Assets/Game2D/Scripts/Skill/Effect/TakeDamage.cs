using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : BaseEffect
{
    public override void Apply(Character target)
    {
        target.attribute.TakeDamage(sourceSkill.skillData.damage);
        Remove();
    }

    public override void Remove()
    {
        SkillEffectFactory.ReturnObject(this);
    }
}
