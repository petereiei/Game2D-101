using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAttribute : MonoBehaviour
{
    public float hp { get; protected set; }
    public float pAtk { get { return BasePAtk; } }
    public float moveSpeed { get { return BaseMoveSpeed; } }


    public abstract float BaseMaxHP { get; }


    protected Character character;

    public abstract float BaseMoveSpeed { get; }
    public abstract float BasePAtk { get; }


    public void Init()
    {
        hp = BaseMaxHP;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"TakeDamage: {damage}");

        if (hp > 0f)
            hp -= damage;

        if (hp <= 0)
        {
            Debug.Log("Death");
            character.IsDeath = true;
            hp = 0;
            character.onDie();
        }

        Debug.Log($"hp: {hp}");
    }

    public void Heal(float healValue)
    {
        Debug.Log($"healValue: {healValue}");
        hp = Mathf.Min(hp + healValue, BaseMaxHP);
    }
}
