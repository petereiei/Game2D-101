using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    public Transform player;
    public Transform monster;

    private void Start()
    {
        PlayerCharacter playerCharacter = Instantiate(Resources.Load<PlayerCharacter>("Prefabs/Characters/Base/Player"));
        playerCharacter.transform.SetParent(player);
        playerCharacter.transform.position = player.position;
        playerCharacter.transform.localScale = Vector3.one;

        playerCharacter.Init();

        MonsterCharacter monsterCharacter = Instantiate(Resources.Load<MonsterCharacter>("Prefabs/Characters/Base/Monster"));
        monsterCharacter.transform.SetParent(monster);
        monsterCharacter.transform.position = monster.position;
        monsterCharacter.transform.localScale = Vector3.one;

        monsterCharacter.Init();
    }
}
