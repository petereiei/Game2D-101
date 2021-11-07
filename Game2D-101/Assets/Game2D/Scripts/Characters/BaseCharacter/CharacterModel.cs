using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : MonoBehaviour
{
    private const string CHARACTER_MODEL = "Prefabs/Characters/Models/";

    protected Character character;

    private Animator animator;
    private GameObject model;
    private Vector2 tempDirection;

    public void Init(Character character)
    {
        this.character = character;

        GetCharacterModel();
    }

    private void GetCharacterModel()
    {
        model = Instantiate(Resources.Load<GameObject>(CHARACTER_MODEL + character.GetCharacterModelId()), transform);
        model.transform.position = transform.position;
        model.transform.localScale = Vector3.one;

        this.animator = model.GetComponentInChildren<Animator>();
    }

    public void OnMove(Vector2 direction)
    {
        if (direction != tempDirection)
        {
            animator.SetBool("Run", direction.magnitude != 0);
            Flip(direction.x);
            tempDirection = direction;
        }
    }

    public void OnAttack()
    {
        animator.Play("Attack");
    }

    private void Flip(float directionX)
    {
        if (directionX != 0)
            transform.localScale = new Vector3(Mathf.Sign(directionX), 1, 1);
    }
}
