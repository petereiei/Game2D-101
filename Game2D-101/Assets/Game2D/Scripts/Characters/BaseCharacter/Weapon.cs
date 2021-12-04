using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Character character;

    private BoxCollider2D boxCollider;

    public void Init(Character character)
    {
        this.character = character;

        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void OpenHitBox()
    {
        boxCollider.enabled = true;
    }

    public void CloseHitBox()
    {
        boxCollider.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Character target = other.GetComponentInParent<Character>();
        if (target != null)
        {
            target.attribute.TakeDamage(character.attribute.pAtk);
        }
    }
}
