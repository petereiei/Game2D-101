using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class CharacterControl : MonoBehaviour
{
    protected Rigidbody2D rigidBody2D;
    protected Character character;

    private NavMeshAgent meshAgent;
    private Vector2 tempTarget;
    public int currentWaypoint;

    private void OnDrawGizmosSelected()
    {
        if (tempTarget != null)
        {
            Handles.color = Color.red;
            Handles.DrawLine(rigidBody2D.position, tempTarget);
            Handles.DrawLine(rigidBody2D.position + new Vector2(0, 2), tempTarget);

            Handles.Label(Vector3.Lerp(rigidBody2D.position + new Vector2(0, 2), tempTarget, 0.5f), "" + Vector3.Distance(rigidBody2D.position, tempTarget));
        }
    }

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        meshAgent = GetComponent<NavMeshAgent>();
        meshAgent.updateRotation = false;
        meshAgent.updateUpAxis = false;
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

    public void CastSkill(CharacterSkill characterSkill)
    {
        if (!character.IsDeath)
        {
            character.characterAnimator.PlayerAnimation(characterSkill);
        }
    }

    public void MoveToNextWaypoint()
    {
        if (meshAgent == null)
            return;
        

        if (DistanceToWaypoint() < 6.5f)
        {
            currentWaypoint++;
            meshAgent.isStopped = true;
        }
        else
        {
            MoveToDirection(GetDirectionToNextWaypoint());
        }
    }

    private float DistanceToWaypoint()
    {
        if (meshAgent.path.corners.Length > currentWaypoint)
            return Vector2.Distance(rigidBody2D.position, meshAgent.path.corners[currentWaypoint]);
        else
            return 0;
    }

    private Vector2 GetDirectionToNextWaypoint()
    {
        if (meshAgent != null && meshAgent.path.corners.Length > currentWaypoint)
            return ((Vector2)meshAgent.path.corners[currentWaypoint] - rigidBody2D.position).normalized;
        else
            return Vector2.zero;
    }

    private bool CheckPathLastPoint()
    {
        if (meshAgent != null)
            return currentWaypoint >= meshAgent.path.corners.Length;
        else
            return false;
    }

    public void MoveToTarget(Vector2 target)
    {
        if (tempTarget != target)
            tempTarget = target;

        meshAgent.destination = target;
        meshAgent.isStopped = false;
    }

    public bool ReachTheLastTarget()
    {
        if (meshAgent != null)
            return currentWaypoint >= meshAgent.path.corners.Length;
        else
            return false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            character.behaviourControl.CurrentState = character.behaviourControl.States.Attacking();
            character.behaviourControl.CurrentState.EnterState();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            CastSkill(new CharacterSkill(character, "skill_0001"));
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            var effectData = new SkillEffectData()
            {
                skillName = "Heal",
                value = 10,
                effectType = EffectType.Buff
            };

            var spawnEffect = SkillEffectFactory.GenerateEffect<BaseEffect>(effectData, character);
            spawnEffect.InitializeEffectData(null, null, effectData);
            spawnEffect.Apply(character);
        }
    }
}
