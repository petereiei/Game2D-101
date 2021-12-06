using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMonsterHP : BaseCharacterHP
{
    public override void SetData(Character character)
    {
        base.SetData(character);
    }

    private void FixedUpdate()
    {
        if (currentCharacter.transform)
        {
            transform.position = new Vector2(currentCharacter.characterPoint.hpPoint.position.x, currentCharacter.characterPoint.hpPoint.position.y);
        }
    }
}
