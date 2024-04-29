using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OuterInteracterPlayer : OuterInteracterBase
{
    [SerializeField]
    PlayerDatabase PlayerDatabase;

    private void Start()
    {
        checkSerializeField();
    }

    //�T�{SerializeField�ŭ�
    private void checkSerializeField()
    {
        if (PlayerDatabase == null)
        {
            Debug.LogError("PlayerDatabase == null");
        }
    }

    public override void ReduceHP(GameObject causer, float value)
    {
        PlayerDatabase.playerAtt.HP = Mathf.Clamp(PlayerDatabase.playerAtt.HP - value, 0, PlayerDatabase.playerAtt.MaxHP);
    }


}
