using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourControl : CharacterBehaviourControl
{
    public override void Init(Character character)
    {
       
        base.Init(character);

        States = new CharacterStateFactory(this);
        CurrentState = States.InputState();
        CurrentState.EnterState();

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
