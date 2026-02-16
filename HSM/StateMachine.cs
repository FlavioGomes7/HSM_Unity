using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State state;
    private List<State> states = new List<State>();

    public void Set(State newState, bool forceReset = false)
    {
        if (state != newState || forceReset)
        {
            state?.Exit();
            state = newState;
            if(state != null) 
            {
                state.Initialize(this);
                state.Enter();
            }
        }

    }

    public List<State> GetActiveStateBranch(List<State> list = null)
    {
        if (list == null)
        {
            states.Clear();
            list = states;
        }

        if (state == null)
        {
            return list;
        }
        else
        {
            list.Add(state);
            return state.machine.GetActiveStateBranch(list);
        }
    }

}
