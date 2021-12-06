using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public RawSkillData rawSkillData;
    public CharacterHPBar characterHPBar;

    public Transform player;
    public Transform monster;

    private void Start()
    {
        PlayerCharacter playerCharacter = Instantiate(Resources.Load<PlayerCharacter>("Prefabs/Characters/Base/Player"));
        playerCharacter.transform.SetParent(player);
        playerCharacter.transform.position = player.position;
        playerCharacter.transform.localScale = Vector3.one;

        playerCharacter.Init();
        characterHPBar.playerHp.SetData(playerCharacter);

        MonsterCharacter monsterCharacter = Instantiate(Resources.Load<MonsterCharacter>("Prefabs/Characters/Base/Monster"));
        monsterCharacter.transform.SetParent(monster);
        monsterCharacter.transform.position = monster.position;
        monsterCharacter.transform.localScale = Vector3.one;

        monsterCharacter.Init();
    }

    public void ReturnObject(string path, GameObject gameObject, float delay = 0f)
    {
        StartCoroutine(PoolingReturnObject(path, gameObject, delay));
    }

    private IEnumerator PoolingReturnObject(string path, GameObject gameObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        ObjectPooling.instance.ReturnObject(path, gameObject);
    }
}