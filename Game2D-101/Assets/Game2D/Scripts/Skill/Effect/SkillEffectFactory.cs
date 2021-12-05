using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillEffectFactory 
{
    private const string EFFECT_PATH = "Prefabs/Skills/Effects/";

    public static T GenerateEffect<T>(SkillEffectData effectData, Character character) where T : BaseEffect
    {
        var effectPrefab = GetEffectPrefab<T>(effectData.skillName);
        if (effectPrefab == null)
        {
            Debug.LogError($"Effect: {effectData.skillName} null");
            return null;
        }
        var effectParent = character.characterAnimator.transform;
        var spawnedEffect = ObjectPooling.instance.GetObject(effectData.skillName, effectPrefab);
        spawnedEffect.transform.position = effectParent.position;
        spawnedEffect.transform.rotation = effectParent.rotation;
        spawnedEffect.transform.SetParent(effectParent);
        spawnedEffect.transform.localScale = Vector3.one;
        return spawnedEffect;
    }
    public static T GetEffectPrefab<T>(string effectName) where T : BaseEffect
    {
        Debug.Log(EFFECT_PATH + effectName);
        var effectPrefab = Resources.Load<T>(EFFECT_PATH + effectName);
        return effectPrefab;
    }

    public static void ReturnObject(BaseEffect effect)
    {
        ObjectPooling.instance.ReturnObject(effect.effectData.skillName, effect.gameObject);
    }
}
