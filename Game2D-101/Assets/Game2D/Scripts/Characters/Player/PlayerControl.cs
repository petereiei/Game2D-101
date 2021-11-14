using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : CharacterControl
{
    public override void Init(Character character)
    {
        base.Init(character);

        Debug.Log("Init Player Control");
    }
}
