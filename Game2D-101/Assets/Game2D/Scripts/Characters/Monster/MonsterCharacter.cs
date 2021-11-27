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
        monsterAttribute.Init(this);
        characterModel.Init(this);
        attribute.Init();
    }

    public override string GetCharacterModelId()
    {
        return "Unit_Skeleton_Jabban";
    }

   
}
