using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseState 
{
    protected CharacterBehaviourControl behaviourControl;
    protected CharacterStateFactory stateFactory;

    protected CharacterBaseState currentSuperState;
    protected CharacterBaseState currentSubState;

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
    private void UpdateStates() { }
    protected void SwitchState(CharacterBaseState newBaseState) 
    {
        ExitState();

        newBaseState.EnterState();

        behaviourControl.CurrentState = newBaseState;
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
