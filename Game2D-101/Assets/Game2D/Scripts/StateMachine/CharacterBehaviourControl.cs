using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviourControl : MonoBehaviour
{
    protected Character character;

    private CharacterBaseState currentState;
    private CharacterStateFactory states;

    public bool isAttacking = false;

    public CharacterBaseState CurrentState { get { return currentState; } set { currentState = value; } }
    public Character Character { get { return character; } }

    public void Init(Character character)
    {
        this.character = character;

        states = new CharacterStateFactory(this);
        currentState = states.InputState();
        currentState.EnterState();
    }

    private void Update()
    {
        currentState.UpdateState();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttacking = true;
        }
    }
}
