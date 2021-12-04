using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BulletFactory
{
    private const string BULLET_PATH = "Prefabs/Skills/Bullets/";
    private const string SHAPE_BULLET = "Bullet";
    private const string SHAPE_BURST = "BurstInfront";

    public static void GenerateBullets(CharacterSkill characterUseSkill, List<SkillEffectData> bulletEffectsData)
    {
        characterUseSkill.characterUse.StartCoroutine(DelaySpawnBullet(characterUseSkill, bulletEffectsData));
    }

    private static IEnumerator DelaySpawnBullet(CharacterSkill characterSkill, List<SkillEffectData> bulletEffectsData)
    {
        var skillId = characterSkill.skillData.id;
        var casterPivot = characterSkill.characterUse;
        List<RawSkillBulletData> bulletsData = GameData.instance.GetSkillBulletDataBySkillId(characterSkill.skillData.id);
        for (int i = 0; i < bulletsData.Count; i++)
        {
            if (bulletsData[i].delaySpawn > 0)
            {
                yield return new WaitForSeconds(bulletsData[i].delaySpawn);
            }

            Debug.Log($"{casterPivot.gameObject.transform.name}");
            var bullet = GetBulletObject(bulletsData[i], casterPivot.transform);

            bullet.Init(characterSkill, bulletsData[i], bulletEffectsData);

            //SpawnParticle(characterSkill, bulletsData[i], bullet);
        }
    }

    private static Bullet GetBulletObject(RawSkillBulletData bulletData, Transform positionTransform)
    {
        Debug.Log($"{positionTransform.name}");
        var path = GetBulletPath(bulletData);
        var bulletObject = GameManager.instance.InstantiateBullet(path);
        bulletObject.transform.position = positionTransform.position;
        bulletObject.transform.rotation = positionTransform.rotation;
        bulletObject.transform.SetParent(GameManager.instance.transform);
        return bulletObject;
    }

    private static void SpawnParticle(CharacterSkill characterSkill, RawSkillBulletData bulletsData, Bullet bullet)
    {
        var particle = GameManager.instance.GenerateParticle("", bulletsData, bullet.transform);
        if (particle)
            particle.Init(characterSkill, bullet, bulletsData);
    }

    private static string GetBulletPath(RawSkillBulletData bulletData)
    {
        var path = BULLET_PATH;
        switch (bulletData.shape)
        {
            case BulletShape.Bullet:
                path += SHAPE_BULLET;
                break;
            case BulletShape.BurstInfront:
                path += SHAPE_BURST;
                break;
        }
        return path;
    }

    public static void ReturnBullet(Bullet bullet, float delay)
    {
        GameManager.instance.DestroyObject(bullet.gameObject, delay);
    }
}
