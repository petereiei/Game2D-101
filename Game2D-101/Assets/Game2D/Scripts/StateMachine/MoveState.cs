using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : CharacterBaseState
{

    private const float timeDuration = 5f;
    private float currentTime = 0;

    public MoveState(CharacterBehaviourControl characterBehaviourControl, CharacterStateFactory characterStateFactory) : base(characterBehaviourControl, characterStateFactory)
    {

    }

    public override void CheckSwitchStates()
    {

    }

    public override void EnterState()
    {
        Debug.Log("MoveState EnterState");
        currentTime = 0;
        CurrentBehaviourControl.Character.characterControl.currentWaypoint = 0;
    }

    public override void ExitState()
    {

    }

    public override void InitializeSubState()
    {

    }

    public override void UpdateState()
    {
        currentTime += Time.deltaTime;

        if (currentTime > timeDuration)
        {
            CurrentBehaviourControl.Character.characterControl.MoveToTarget(GameManager.instance.playerCharacter.transform.position);
            CurrentBehaviourControl.Character.characterControl.MoveToNextWaypoint();

            if (BehaviourControl.Character.characterControl.ReachTheLastTarget())
            {
                SwitchState(StateFactory.Idle());
            }
        }

       



        //CheckSwitchStates();
    }
}
