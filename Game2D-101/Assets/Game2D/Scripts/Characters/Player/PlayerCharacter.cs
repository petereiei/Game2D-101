using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public PlayerAttribute playerAttribute;

    private void Awake()
    {
        playerAttribute = gameObject.AddComponent<PlayerAttribute>();
        attribute = playerAttribute;
        characterControl = gameObject.GetComponent<PlayerControl>();
    }

    public void Init()
    {
        playerAttribute.Init(this);
        characterControl.Init(this);
    }

    public override string GetAnimatorId()
    {
        return "Player";
    }
}
