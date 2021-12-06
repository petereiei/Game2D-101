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
    public CharacterAnimator characterAnimator;
    public CharacterControl characterControl;
    public CharacterPoint characterPoint;


    //event
    public UnityAction onAttack;
    public UnityAction<Vector2> onMove;
    public UnityAction<Character> onDie;
    public UnityAction<CharacterSkill> onCastFinish;
    public UnityAction onAttributeChange;

    public bool IsDeath { get; set; }
    public bool IsPlayer { get { return this.tag == "Player"; } }
    public bool IsMonster { get { return this.tag == "Monster"; } }


    //method
    public abstract string GetCharacterModelId();


    protected virtual void Awake()
    {
        behaviourControl = GetComponent<CharacterBehaviourControl>();
    }
}
