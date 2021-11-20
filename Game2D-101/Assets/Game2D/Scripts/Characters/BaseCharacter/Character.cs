using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    public CharacterBehaviourControl behaviourControl;

    //character data
    public CharacterAttribute attribute;

    //module
    public CharacterModel characterModel;
    public CharacterControl characterControl;


    //event
    public UnityAction onAttack;
    public UnityAction<Vector2> onMove;

    public bool IsPlayer { get { return this.tag == "Player"; } }


    //method
    public abstract string GetCharacterModelId();


    protected virtual void Awake()
    {
        behaviourControl = GetComponent<CharacterBehaviourControl>();
    }
}
