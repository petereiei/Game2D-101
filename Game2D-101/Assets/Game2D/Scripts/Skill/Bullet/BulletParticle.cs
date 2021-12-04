using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    private Bullet bullet;
    private RawSkillBulletData rawSkillBulletData;
    private CharacterSkill skill;
    private List<ParticleSystem> particleSystems;

    public void Init(CharacterSkill skill, Bullet bullet, RawSkillBulletData rawSkillBulletData)
    {
        this.skill = skill;
        this.bullet = bullet;
        this.rawSkillBulletData = rawSkillBulletData;
        particleSystems = new List<ParticleSystem>(GetComponentsInChildren<ParticleSystem>());
        transform.localScale = Vector3.one;
    }

    void Update()
    {
        if (bullet && bullet.isActiveAndEnabled)
            transform.position = bullet.transform.position;
    }

    private bool IsParticlePlaying(ParticleSystem particle)
    {
        return particle.isPlaying && !particle.main.loop;
    }
    public bool HasBullet()
    {
        return bullet == null ? true : false;
    }
}
