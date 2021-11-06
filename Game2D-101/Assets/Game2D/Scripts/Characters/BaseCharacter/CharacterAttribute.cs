using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAttribute : MonoBehaviour
{
    public float moveSpeed { get { return BaseMoveSpeed; } }


    protected Character character;

    public abstract float BaseMoveSpeed { get; }
}
