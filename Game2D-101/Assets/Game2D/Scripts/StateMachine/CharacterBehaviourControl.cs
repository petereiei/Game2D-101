using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviourControl : MonoBehaviour
{
    protected Character character;

    private CharacterBaseState currentState;
    private CharacterStateFactory states;

    public bool isAttacking = false;
    public bool IsAttacking { get { return isAttacking; } set { isAttacking = value; } }
    public CharacterBaseState CurrentState { get { return currentState; } set { currentState = value; } }
    public Character Character { get { return character; } }
    public CharacterStateFactory States { get { return states; } set { states = value; } }

    public virtual void Init(Character character)
    {
        Debug.Log("Init CharacterBehaviourControl");
        this.character = character;
    }

    protected virtual void FixedUpdate()
    {
        if (currentState != null)
            currentState.UpdateState();
    }
}
