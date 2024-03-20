using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// �o�Ӹ}�������a�P�Ǫ����ʪ���������
/// </summary>
public class InteractManager : MonoBehaviour
{
    private AttributeManager attributeManager;
    private ColliderManager colliderManager;


    void Start()
    {
        //��oAttribuManager
        attributeManager = GetComponent<AttributeManager>();
        if(attributeManager == null )
        {
            Debug.LogError("attributeManager == null, please check it.");
        }

        //��oColliderManager
        colliderManager = GetComponent<ColliderManager>();
        if (colliderManager == null)
        {
            Debug.LogError("colliderManager == null, please check it.");
        }
    }

    //�y���ˮ`
    public void Damage(float damageValue, string targetDetecterName)
    {
        if (colliderManager.ColliderDetecterDictionary.ContainsKey(targetDetecterName))
        {
            var interactManagers = getInteractManagerfromObject(colliderManager.ColliderDetecterDictionary[targetDetecterName]);
            foreach(var interactManager in interactManagers)
            {
                interactManager.BeDamaged(damageValue);
            }
        }
    }

    //�NDetecter��GameObject���W���InteractManager
    private List<InteractManager> getInteractManagerfromObject(List<GameObject> gameObjects)
    {
        var interactManagers = new List<InteractManager>();
        foreach (var objectItem in gameObjects)
        {
            var interactManager = objectItem.GetComponent<InteractManager>();
            if (interactManager != null)
            {
                interactManagers.Add(interactManager);
            }
        }
        return interactManagers;
    }

    //����ˮ`
    public void BeDamaged(float damageValue)
    {
        attributeManager.ReduceHP(damageValue);
    }

    //�ϼu�}
    public void BeBounceUp()
    {

    }

    //�Ϸw�t
    public void BeDizzy()
    {

    }
}
