using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public RawSkillData rawSkillData;

    public Bullet InstantiateBullet(string path)
    {
        return Instantiate(Resources.Load<Bullet>(path));
    }

    public T InstantiateObject<T>(T GameObject) where T : Component
    {
        return Instantiate(GameObject.gameObject).GetComponent<T>(); ;
    }

    public BulletParticle GenerateParticle(string path, RawSkillBulletData bulletData, Transform bulletTransform)
    {
        Debug.Log(path + "/" + bulletData.skillId);
        var particle = Instantiate(Resources.Load<GameObject>(path + "/" + bulletData.skillId));
        particle.transform.position = bulletTransform.position;
        particle.transform.rotation = bulletTransform.rotation;
        particle.transform.localScale = Vector3.one;

        return particle.GetComponent<BulletParticle>();
    }

    public void DestroyObject(GameObject gameObject, float delay = 0f)
    {
        StartCoroutine(DelayDestroy(gameObject, delay));
    }

    private IEnumerator DelayDestroy(GameObject gameObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}