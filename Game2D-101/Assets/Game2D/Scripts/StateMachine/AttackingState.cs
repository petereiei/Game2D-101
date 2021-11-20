using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : CharacterBaseState
{
    const float minAnimTime = 1.05f;
    protected float currentTime = 0;

    public AttackingState(CharacterBehaviourControl characterBehaviourControl, CharacterStateFactory characterStateFactory) : base(characterBehaviourControl, characterStateFactory)
    {
        IsRootState = true;
    }

    public override void CheckSwitchStates()
    {
        if (CurrentBehaviourControl.Character.IsPlayer)
            SwitchState(StateFactory.InputState());
        else
            SwitchState(StateFactory.Idle());
    }

    public override void EnterState()
    {
        CurrentBehaviourControl.Character.characterControl.Attack();
        CurrentBehaviourControl.Character.characterControl.MoveToDirection(Vector2.zero);
    }

    public override void ExitState()
    {
        CurrentBehaviourControl.IsAttacking = false;
    }

    public override void InitializeSubState()
    {

    }

    public override void UpdateState()
    {
        currentTime += Time.deltaTime;

        if (currentTime > minAnimTime)
        {
            CheckSwitchStates();
        }
    }
}
