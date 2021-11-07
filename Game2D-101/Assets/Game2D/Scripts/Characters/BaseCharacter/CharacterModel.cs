using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : MonoBehaviour
{
    private const string CHARACTER_MODEL = "Prefabs/Characters/Models/";

    protected Character character;

    private GameObject model;

    public void Init(Character character)
    {
        this.character = character;

        GetCharacterModel();
    }

    private void GetCharacterModel()
    {
        model = Instantiate(Resources.Load<GameObject>(CHARACTER_MODEL + character.GetCharacterModelId()), transform);
    }
}
