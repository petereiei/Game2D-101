using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCharacter : Character
{
    public MonsterAttribute monsterAttribute;

    private CharacterMonsterHP monsterHP;

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

        GenerateHPBar();

        onDie += characterAnimator.OnDie;
        onDie += OnDie;
    }

    private void GenerateHPBar()
    {
        monsterHP = ObjectPooling.instance.GetObject("HPBarMonster", Resources.Load<CharacterMonsterHP>("Prefabs/UI/HP/HP_Monster"));
        monsterHP.transform.SetParent(GameManager.instance.characterHPBar.parentMonsterHp);
        monsterHP.transform.position = characterPoint.hpPoint.position;
        monsterHP.transform.localScale = Vector3.one;

        monsterHP.SetData(this);

    }

    private void OnDie(Character character)
    {
        ObjectPooling.instance.ReturnObject("MonsterCharacter", gameObject, 2.5f);
        ObjectPooling.instance.ReturnObject("HPBarMonster", monsterHP.gameObject);
    }

    public override string GetCharacterModelId()
    {
        return "Monster_0001";
    }

   
}
