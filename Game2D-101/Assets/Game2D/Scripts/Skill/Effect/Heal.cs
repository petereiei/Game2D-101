using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : BaseEffect
{
    public override void Apply(Character target)
    {
        target.attribute.Heal(effectData.value);
        Remove();
    }

    public override void Remove()
    {
        Destroy(gameObject);
    }
}
