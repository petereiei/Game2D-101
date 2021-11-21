using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterBaseState
{


    public IdleState(CharacterBehaviourControl characterBehaviourControl, CharacterStateFactory characterStateFactory) : base(characterBehaviourControl, characterStateFactory)
    {
        IsRootState = true;
        InitializeSubState();
    }

    public override void CheckSwitchStates()
    {
        if (CurrentBehaviourControl.IsAttacking)
            SwitchState(StateFactory.Attacking());
    }

    public override void EnterState()
    {
        CurrentBehaviourControl.Character.characterControl.MoveToDirection(Vector2.zero);
    }

    public override void ExitState()
    {

    }

    public override void InitializeSubState()
    {
        if (BehaviourControl.Character.IsPlayer)
        {
            SetSubState(StateFactory.InputState());
        }
        if (BehaviourControl.IsAttacking)
        {
            SetSubState(StateFactory.Attacking());
        }
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

}
