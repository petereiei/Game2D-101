using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviourControl : CharacterBehaviourControl
{
    public override void Init(Character character)
    {
        base.Init(character);

        States = new CharacterStateFactory(this);
        CurrentState = States.Idle();
        CurrentState.EnterState();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
