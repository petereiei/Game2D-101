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
        characterAnimator = gameObject.GetComponentInChildren<CharacterAnimator>();
    }

    public void Init()
    {
        IsDeath = false;

        monsterAttribute.Init(this);
        characterAnimator.Init(this);
        attribute.Init();

        onDie += characterAnimator.OnDie;
    }

    public override string GetCharacterModelId()
    {
        return "Monster_0001";
    }

   
}
