using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterBaseState
{
    private Vector2 input = Vector2.zero;

    public IdleState(CharacterBehaviourControl characterBehaviourControl, CharacterStateFactory characterStateFactory) : base(characterBehaviourControl, characterStateFactory) {}

    public override void CheckSwitchStates()
    {

    }

    public override void EnterState()
    {
        Debug.Log("EnterState IdleState...");
    }

    public override void ExitState()
    {

    }

    public override void InitializeSubState()
    {

    }

    public override void UpdateState()
    {
        CheckSwitchStates();

        CurrentBehaviourControl.Character.characterControl.MoveToDirection(GetRawInput().normalized);
    }

    private Vector2 GetRawInput()
    {
        float rawDirectionX = Input.GetAxisRaw("Horizontal");
        float rawDirectionY = Input.GetAxisRaw("Vertical");

        input.x = rawDirectionX;
        input.y = rawDirectionY;

        return input;
    }
}
