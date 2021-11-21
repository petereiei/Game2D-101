using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : CharacterBaseState
{
    public MoveState(CharacterBehaviourControl characterBehaviourControl, CharacterStateFactory characterStateFactory): base (characterBehaviourControl, characterStateFactory) { }

    public override void CheckSwitchStates()
    {

    }

    public override void EnterState()
    {
        Debug.Log("EnterState MoveState...");
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void InitializeSubState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}
