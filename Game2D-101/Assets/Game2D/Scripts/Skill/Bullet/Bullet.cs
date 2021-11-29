using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    protected RawSkillBulletData rawSkillBulletData;
    protected List<SkillEffectData> effectData;
    protected Character characterUse;
    protected CharacterSkill characterSkill;
    protected Vector3 direction;

    public new Collider2D collider;
    public static bool activeDebugCollider = false;
    public SpriteRenderer debugCollider;
    private float bulletSpeed = 10f;
   

    public virtual void Init(CharacterSkill characterSkill, RawSkillBulletData bulletData, List<SkillEffectData> bulletEffectsData)
    {
        characterUse = characterSkill.characterUse;
        this.characterSkill = characterSkill;
        rawSkillBulletData = bulletData;
        effectData = bulletEffectsData;

        var bulletSize = GameData.instance.GetSkillDataById(characterSkill.skillData.id).areaSize;
        debugCollider.gameObject.SetActive(activeDebugCollider);
        bulletSpeed = bulletData.moveSpeed;

        direction = GetDirection();

        LookAtTargetDirection(direction);
        SetupCollider(bulletSize);
        SetupColliderOffset(bulletSize);
        BulletFactory.ReturnBullet(this, rawSkillBulletData.lifeTime);
    }

    private void LookAtTargetDirection(Vector3 direction)
    {
        if (direction == Vector3.zero)
            return;
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation.x = transform.rotation.x;
        rotation.y = transform.rotation.y;
        transform.rotation = rotation;
    }

    private void SetupCollider(float bulletSize)
    {
        var charSize = 1;
        bulletSize *= charSize;
        if (collider is CircleCollider2D)
            transform.localScale = new Vector3(bulletSize, bulletSize, bulletSize);
    }

    private void SetupColliderOffset(float size)
    {
        switch (rawSkillBulletData.shape)
        {
            case BulletShape.BurstInfront:
                string ownerDirection = GetOwnerDirection();
                if (ownerDirection == "Left")
                    collider.offset = new Vector2(-0.5f, 0);
                if (ownerDirection == "Right")
                    collider.offset = new Vector2(0.5f, 0);
                debugCollider.transform.localPosition = collider.offset;
                break;
        }
    }

    private Vector3 GetDirection()
    {
        string ownerDirection = GetOwnerDirection();
        if (ownerDirection == "Left")
            return -transform.right;
        else
            return transform.right;
    }

    private string GetOwnerDirection()
    {
        return characterSkill.characterUse.characterAnimator.GetCharacterDirection();
    }
}
