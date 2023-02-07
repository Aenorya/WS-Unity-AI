using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkState : BaseState
{
    bool reachedWS = false;

    public override void OnStart(WorkerStateMachine stateMachine)
    {
        label = "Work";
        fsm = stateMachine;
        destination = fsm.MoveTo(Waypoints.Workstation);
    }

    public override void OnUpdate()
    {
        fsm.stats.AddHunger();
        if (!reachedWS && Vector3.Distance(fsm.GetAgentPosition(), destination) < fsm.stoppingDistance)
        {
            //
            reachedWS = true;
        }
        else if (reachedWS)
        {
            fsm.stats.DoWork();
            if (fsm.stats.hunger >= 0.85f)
            {
                OnEnd();
            }
            else if (fsm.stats.work >= 1)
            {
                OnEnd();
            }
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
            fsm.OnStateEnd(new WatchTvState());
        }
        
    }
}
