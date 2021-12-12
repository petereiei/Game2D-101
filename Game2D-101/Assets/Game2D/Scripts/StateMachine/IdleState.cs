using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterBaseState
{
    private const float timeDuration = 5f;
    private float currentTime = 0;

    public IdleState(CharacterBehaviourControl characterBehaviourControl, CharacterStateFactory characterStateFactory) : base(characterBehaviourControl, characterStateFactory)
    {
        IsRootState = true;
        InitializeSubState();
    }

    public override void CheckSwitchStates()
    {
        if (CurrentBehaviourControl.IsAttacking)
            SwitchState(StateFactory.Attacking());

        if (BehaviourControl.Character.IsMonster)
        {
            Debug.Log("SwitchState(StateFactory.Move());");
            currentTime += Time.deltaTime;

            if (currentTime > timeDuration)
            {
                SwitchState(StateFactory.Move());
            }
            
        }
    }

    public override void EnterState()
    {
        if (BehaviourControl.Character.IsMonster)
            Debug.Log("EnterState");

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
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

}
