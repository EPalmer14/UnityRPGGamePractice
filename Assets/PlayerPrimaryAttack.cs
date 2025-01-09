using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerPrimaryAttack : PlayerState
{
    private int comboCounter;
    private float lastTimeAttacked;
    private float comboWindow = 1;
    public PlayerPrimaryAttack(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow)
        {
            comboCounter = 0;
        }

        player.anim.SetInteger("ComboCounter", comboCounter);
        //player.anim.speed = 1.5f;

        player.SetVelocity(player.attackMovement[comboCounter].x * player.facingDir, player.attackMovement[comboCounter].y);

        stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();
        //player.anim.speed = 1;
        player.StartCoroutine("BusyFor", .2f);
        comboCounter++;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
        {
            player.ZeroVelocity();
        }

        if (triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }

    }
}
