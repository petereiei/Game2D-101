using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttribute : CharacterAttribute
{
    public override float BaseMoveSpeed => 0.25f; // mackup data speed;

    public override float BaseMaxHP => 100f;

    public override float BasePAtk => 10f;

    public void Init(Character character)
    {
        this.character = character;
    }
}
