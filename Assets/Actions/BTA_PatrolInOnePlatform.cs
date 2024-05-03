using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using System;
using static UnityEngine.RuleTile.TilingRuleOutput;
using System.Diagnostics.CodeAnalysis;

[System.Serializable]
public class BTA_PatrolInOnePlatform : ActionNode
{
    public enum PatrolDirection
    {
        Random,
        Right,
        Left
    }
    public NodeProperty<PatrolDirection> InitialDirection;
    public NodeProperty<float> HorizontalSpeed;

    private GameObject owner;
    private MonsterDatabase database;
    private PatrolDirection currentPatrolDirection;

    protected override void OnStart() 
    {
        owner = blackboard.Find<GameObject>("Owner").value;
        database = blackboard.Find<MonsterDatabase>("Database").value;
        setDirectionBySetting();
    }

    protected override void OnStop() {}

    protected override State OnUpdate() 
    {
        //���򵥨츨�a�~�|�}�l�p����ɼƾڨö}�l����
        if(database.RB.velocity.y==0)
        {
            doPatrol();
        }
        return State.Running;
    }

    //��l�Ʋ��ʤ�V
    private void setDirectionBySetting()
    {
        switch (currentPatrolDirection)
        {
            case PatrolDirection.Random:
                currentPatrolDirection = getRandomDirection();
                break;
            default:
                currentPatrolDirection = InitialDirection.Value;
                break;
        }
    }

    //���o�H����V
    private PatrolDirection getRandomDirection()
    {
        int randomDirection = UnityEngine.Random.Range(0, 2);
        if (randomDirection == 0)
        {
            return PatrolDirection.Right;
        }
        else
        {
            return PatrolDirection.Left;
        }
    }

    //���޲���
    private void doPatrol()
    {
        if (isReachedMargin())
        {
            database.RB.velocity = new Vector2(0, database.RB.velocity.y);
            turnPatrolDirection();
        }

        database.RB.velocity = (currentPatrolDirection == PatrolDirection.Right ? new Vector2(HorizontalSpeed.Value, 0) : new Vector2(-HorizontalSpeed.Value, 0));
        maintainActorDirection();
    }

    //�˴��O�_��F���x���
    private bool isReachedMargin()
    {
        RaycastHit2D hit = Physics2D.Raycast(owner.transform.position, database.RB.velocity.x > 0 ? Vector2.right: Vector2.left, 1f, LayerMask.GetMask("MapMargin"));

        if(hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    //�ܧ��ޤ�V
    private void turnPatrolDirection()
    {
        if(currentPatrolDirection == PatrolDirection.Right)
        {
            currentPatrolDirection = PatrolDirection.Left;
            Debug.Log("Turn right");

        }
        else
        {
            currentPatrolDirection = PatrolDirection.Right;
            Debug.Log("Turn left");

        }
    }

    //���@���Ⲿ�ʤ�V
    private void maintainActorDirection()
    {
        //�����V
        if (database.RB.velocity.x > 0)
        {
            owner.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (database.RB.velocity.x < 0)
        {
            owner.transform.localScale = new Vector3(-1, 1, 1);
        }
    }


}
