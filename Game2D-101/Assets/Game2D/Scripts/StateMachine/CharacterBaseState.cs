using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseState
{
    private bool isRootState = false;
    private CharacterBehaviourControl behaviourControl;
    private CharacterStateFactory stateFactory;
    private CharacterBaseState currentSuperState;
    private CharacterBaseState currentSubState;

    protected bool IsRootState { set { isRootState = value; } }
    protected CharacterBehaviourControl BehaviourControl { get { return behaviourControl; } }
    protected CharacterStateFactory StateFactory { get { return stateFactory; } }

    public CharacterBehaviourControl CurrentBehaviourControl { get { return behaviourControl; } }

    public CharacterBaseState(CharacterBehaviourControl behaviourControl, CharacterStateFactory stateFactory)
    {
        this.behaviourControl = behaviourControl;
        this.stateFactory = stateFactory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchStates();
    public abstract void InitializeSubState();
    public void UpdateStates()
    {
        UpdateState();
        if (currentSubState != null)
        {
            currentSubState.UpdateStates();
        }
    }

    //public void ExitStates()
    //{
    //    ExitState();
    //    if (currentSubState != null)
    //    {
    //        currentSubState.ExitStates();
    //    }
    //}

    protected void SwitchState(CharacterBaseState newBaseState)
    {
        ExitState();

        newBaseState.EnterState();

        if (isRootState)
        {
            behaviourControl.CurrentState = newBaseState;
        }else if (currentSuperState != null)
        {
            currentSuperState.SetSubState(newBaseState);
        }
    }
    protected void SetSuperState(CharacterBaseState newSuperState)
    {
        currentSuperState = newSuperState;
    }
    protected void SetSubState(CharacterBaseState newSubState)
    {
        currentSubState = newSubState;
        newSubState.SetSubState(this);
    }
}
