using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    //character data
    public CharacterAttribute attribute;

    //module
    public CharacterControl characterControl;

    //event
    public UnityAction<Vector2> onMove;


    //method
    public abstract string GetAnimatorId();
}
