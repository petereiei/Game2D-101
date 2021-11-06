using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : CharacterAttribute
{
    public override float BaseMoveSpeed => 0.25f; // mackup data speed;


    public void Init(Character character)
    {
        this.character = character;
    }
}
