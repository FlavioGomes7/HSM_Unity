using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachineManagement : MonoBehaviour
{

    public Animator animator;

    public StateMachine machine;
    public State state => machine.state;
    private Vector3 position = new Vector3 (0,1,0);

    protected void Set(State newState, bool forceReset = false)
    {
        machine.Set(newState, forceReset);
    }

    // With this, the states will be instantiated; however, there will be a constraint that the states of a GameObject must be contained within its hierarchy.
    public void SetupInstances()
    {
        machine = new StateMachine();

        State[] allChildStates = GetComponentsInChildren<State>();
        foreach (State state in allChildStates)
        {
            state.SetManager(this);
        }
    }

    // Displays states and substates in a hierarchy within the editor; in the future, implement something more visually digestible.
    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        if(Application.isPlaying)
        {
            List<State> states = machine.GetActiveStateBranch();
            UnityEditor.Handles.Label(transform.position + position, "Active States: " + string.Join(" > ", states));
        }
#endif
    }
}
