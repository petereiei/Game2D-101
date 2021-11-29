using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public PlayerAttribute playerAttribute;

    protected override void Awake()
    {
        base.Awake();

        playerAttribute = gameObject.AddComponent<PlayerAttribute>();
        attribute = playerAttribute;
        characterAnimator = gameObject.GetComponentInChildren<CharacterAnimator>();
        characterControl = gameObject.GetComponent<PlayerControl>();
    }

    public void Init()
    {
        IsDeath = false;

        playerAttribute.Init(this);
        characterAnimator.Init(this);
        characterControl.Init(this);
        behaviourControl.Init(this);
        attribute.Init();

        onMove += characterAnimator.OnMove;
        onAttack += characterAnimator.OnAttack;
    }

    public override string GetCharacterModelId()
    {
        return "Player";
    }
}
