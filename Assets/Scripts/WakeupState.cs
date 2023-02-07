using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeupState : BaseState
{
    public override void OnStart(WorkerStateMachine stateMachine)
    {
        label = "Wake up";
        fsm = stateMachine;
        destination = fsm.MoveTo(Waypoints.Bed);
        //Do wake up animation
        
    }

    public override void OnUpdate()
    {
        fsm.stats.AddHunger();
        if (Vector3.Distance(fsm.GetAgentPosition(), destination) < fsm.stoppingDistance)
        {
            OnEnd();
        }
    } 
    
    public override void OnEnd()
    {
        if(fsm.stats.hunger > 0.5f)
        {
            fsm.OnStateEnd(new CookState());
        }
        else
        {
            fsm.OnStateEnd(new WorkState());
        }
    }

}
