using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : CharacterAttribute
{
    public override float BaseMoveSpeed => 0.25f; // mackup data speed;

    public override float BaseMaxHP => 100f;

    public override float BasePAtk => 50f;

    public void Init(Character character)
    {
        this.character = character;
    }
}
