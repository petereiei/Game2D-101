using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public RawSkillData rawSkillData;
    public CharacterHPBar characterHPBar;

    public Transform player;
    public Transform monster;

    public PlayerCharacter playerCharacter;

    private void Start()
    {
        GeneratePlayer();

        GenerateMonster();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            GenerateMonster();
        }
    }

    private void GeneratePlayer()
    {
        playerCharacter = ObjectPooling.instance.GetObject("PlayerCharacter", Resources.Load<PlayerCharacter>("Prefabs/Characters/Base/Player"));
        playerCharacter.transform.SetParent(player);
        playerCharacter.transform.position = player.position;
        playerCharacter.transform.localScale = Vector3.one;

        playerCharacter.Init();
        characterHPBar.playerHp.SetData(playerCharacter);

    }

    private void GenerateMonster()
    {
        MonsterCharacter monsterCharacter = ObjectPooling.instance.GetObject("MonsterCharacter", Resources.Load<MonsterCharacter>("Prefabs/Characters/Base/Monster"));
        monsterCharacter.transform.SetParent(monster);
        monsterCharacter.transform.position = monster.position;
        monsterCharacter.transform.localScale = Vector3.one;

        monsterCharacter.Init();
    }
}