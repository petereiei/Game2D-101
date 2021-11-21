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
        characterModel = gameObject.GetComponentInChildren<CharacterModel>();
        characterControl = gameObject.GetComponent<PlayerControl>();
    }

    public void Init()
    {
        playerAttribute.Init(this);
        characterModel.Init(this);
        characterControl.Init(this);
        behaviourControl.Init(this);

        onMove += characterModel.OnMove;
        onAttack += characterModel.OnAttack;
    }

    public override string GetCharacterModelId()
    {
        return "Unit_Knight_Jarek";
    }
}
