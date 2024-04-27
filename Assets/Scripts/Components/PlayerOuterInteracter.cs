using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerOuterInteracter : MonoBehaviour
{
    [SerializeField]
    public PlayerBehavior PlayerBehavior;

    private void Start()
    {
        checkSerializeField();
    }

    //�T�{SerializeField�ŭ�
    void checkSerializeField()
    {
        if (PlayerBehavior == null)
        {
            Debug.LogError("PlayerBehavior == null");
        }
    }

    //�H���G���X�Q����欰
    public void NotifyReduceHP(float reduceValue)
    {
        PlayerBehavior.DoReduceHP(reduceValue);
    }

    //�H���G���X���H��欰
    public void NotifyApplyDamage(float reduceValue)
    {
        PlayerBehavior.DoApplyDamage(reduceValue);
    }
}
