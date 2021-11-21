using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : IdleState
{
    private Vector2 input = Vector2.zero;

    public InputState(CharacterBehaviourControl characterBehaviourControl, CharacterStateFactory characterStateFactory) : base(characterBehaviourControl, characterStateFactory) { }

    public override void CheckSwitchStates()
    {

    }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {
    }

    public override void InitializeSubState()
    {

    }

    public override void UpdateState()
    {
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
