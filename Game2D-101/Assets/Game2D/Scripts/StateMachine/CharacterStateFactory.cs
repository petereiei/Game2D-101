using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateFactory : MonoBehaviour
{
    private CharacterBehaviourControl behaviourControl;

    public CharacterStateFactory(CharacterBehaviourControl behaviourControl)
    {
        this.behaviourControl = behaviourControl;
    }

    public CharacterBaseState InputState()
    {
        return new InputState(behaviourControl, this);
    }

    public CharacterBaseState Idle()
    {
        Debug.Log("CharacterBaseState Idle");
        return new IdleState(behaviourControl, this);
    }

    public CharacterBaseState Move()
    {
        Debug.Log("CharacterBaseState Move");
        return new MoveState(behaviourControl, this);
    }

    public CharacterBaseState Attacking()
    {
        return new AttackingState(behaviourControl, this);
    }
}
