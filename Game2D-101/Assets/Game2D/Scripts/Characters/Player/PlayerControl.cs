using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : CharacterControl
{
    private Vector2 input = Vector2.zero;

    public override void Init(Character character)
    {
        base.Init(character);

        Debug.Log("Init Player Control");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.characterControl.Attack();
        }

        PlayerInput();
    }

    public void PlayerInput()
    {
        character.characterControl.MoveToDirection(GetRawInput().normalized);
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
