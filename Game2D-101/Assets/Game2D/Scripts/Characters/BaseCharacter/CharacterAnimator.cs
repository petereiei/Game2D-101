using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private const string CHARACTER_MODEL = "Prefabs/Characters/Models/";

    protected Character character;
    private SlotWeapon slotWeapon;

    private Animator animator;
    private GameObject model;
    private Vector2 tempDirection;

    public bool IsCasting { get; private set; }

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

        animator = model.GetComponentInChildren<Animator>();
        slotWeapon = model.GetComponentInChildren<SlotWeapon>();
        slotWeapon.Init(character);
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

    public void PlayerAnimation(CharacterSkill characterSkill)
    {
        animator.Play(characterSkill.skillData.animClip);
    }

    private IEnumerator CastingSkill(CharacterSkill skill)
    {
        IsCasting = true;

        yield return new WaitForSeconds(5f);

        IsCasting = false;
        if (!character.IsDeath)
            character.onCastFinish(skill);

    }

    public void OnDie()
    {
        animator.SetTrigger("Die");
    }

    public string GetCharacterDirection()
    {
        return (transform.localScale.x == 1) ? "Left" : "Right";
    }
}
