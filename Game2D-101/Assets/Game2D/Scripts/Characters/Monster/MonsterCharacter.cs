using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCharacter : Character
{
    public MonsterAttribute monsterAttribute;

    protected override void Awake()
    {
        base.Awake();

        monsterAttribute = gameObject.AddComponent<MonsterAttribute>();
        attribute = monsterAttribute;
        characterModel = gameObject.GetComponentInChildren<CharacterModel>();
    }

    public void Init()
    {
        IsDeath = false;

        monsterAttribute.Init(this);
        characterModel.Init(this);
        attribute.Init();

        onDie += characterModel.OnDie;
    }

    public override string GetCharacterModelId()
    {
        return "Monster_0001";
    }

   
}
