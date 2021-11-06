using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    public Transform c;

    private void Start()
    {
        PlayerCharacter playerCharacter = Instantiate(Resources.Load<PlayerCharacter>("Prefabs/Characters/BasePlayer/Player"));
        playerCharacter.transform.SetParent(c);
        playerCharacter.transform.localScale = Vector3.one;

        playerCharacter.Init();
    }
}
