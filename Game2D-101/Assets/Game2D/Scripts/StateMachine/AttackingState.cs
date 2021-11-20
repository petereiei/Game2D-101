using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : CharacterBaseState
{
    const float minAnimTime = 0.2f;
    protected float currentTime = 0;

    public AttackingState(CharacterBehaviourControl characterBehaviourControl, CharacterStateFactory characterStateFactory) : base(characterBehaviourControl, characterStateFactory)
    {
        IsRootState = true;
        InitializeSubState();
    }

    public override void CheckSwitchStates()
    {
        SwitchState(StateFactory.InputState());
    }

    public override void EnterState()
    {
        Debug.Log("EnterState AttackingState");
        CurrentBehaviourControl.Character.characterControl.Attack();
        CurrentBehaviourControl.Character.characterControl.MoveToDirection(Vector2.zero);
    }

    public override void ExitState()
    {
        CurrentBehaviourControl.isAttacking = false;
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
