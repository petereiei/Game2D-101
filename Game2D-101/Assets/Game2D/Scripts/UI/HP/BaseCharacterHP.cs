using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseCharacterHP : MonoBehaviour
{
    public Image hp;
    private float currentHealth;

    public Character currentCharacter;

    public virtual void SetData(Character character)
    {
        currentCharacter = character;

        currentCharacter.onAttributeChange += UpdateHp;
        UpdateHp();
    }

    private void UpdateHp()
    {
        var currentHP = currentCharacter.attribute.hp / currentCharacter.attribute.BaseMaxHP;
        hp.fillAmount = Mathf.Clamp01(currentHP);
    }
}
