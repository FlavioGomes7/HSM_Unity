using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected StateMachineManagement manager;

    public bool isCompleted { get; protected set; }
    public bool isStarted { get; protected set;}
    protected float startTime;
    public float time => Time.time - startTime;
    protected Animator animator => manager.animator;

    public StateMachine machine;

    protected StateMachine parent;

    public State state => machine.state;
    protected void Set(State newstate, bool forceReset = false)
    {
        machine.Set(newstate, forceReset);
    }
    public void SetManager(StateMachineManagement _manager)
    {
        machine = new StateMachine();
        manager = _manager;
    }
    public virtual void Enter()
    {

    }
    public virtual void Do() 
    {

    }
    public virtual void FixedDo()
    {

    }
    public virtual void Exit()
    {

    }
    public void DoBranch()
    {
        Do();
        state?.DoBranch();
    }

    public void FixedDoBranch()
    {
        FixedDo();
        state?.FixedDoBranch();
    }
   
    public void Inicialize(StateMachine _parent)
    {
        parent = _parent;
        isCompleted = false;
        isStarted = true;
        startTime = Time.time;
    }
}
