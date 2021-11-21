using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    protected Rigidbody2D rigidBody2D;
    protected Character character;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public virtual void Init(Character character)
    {
        this.character = character;
    }

    public void MoveToDirection(Vector2 direction)
    {
        direction = direction.normalized;
        rigidBody2D.MovePosition(rigidBody2D.position + direction * character.attribute.moveSpeed);
        character.onMove?.Invoke(direction);
    }

    public void Attack()
    {
        character.onAttack?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            character.behaviourControl.CurrentState = character.behaviourControl.States.Attacking();
            character.behaviourControl.CurrentState.EnterState();
        }
    }
}
