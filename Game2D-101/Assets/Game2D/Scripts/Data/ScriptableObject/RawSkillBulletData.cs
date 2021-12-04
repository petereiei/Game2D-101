using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RawSkillBulletData 
{
    public string skillId;
    public float delaySpawn;
    public float lifeTime;
    public float moveSpeed;
    public BulletShape shape;
}

public enum BulletShape
{
    Bullet,
    BurstInfront
}
