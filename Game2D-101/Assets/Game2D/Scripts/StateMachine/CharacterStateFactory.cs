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

    public CharacterBaseState Idle()
    {
        return new IdleState(behaviourControl, this);
    }

    public CharacterBaseState Move()
    {
        return new MoveState(behaviourControl, this);
    }
}
