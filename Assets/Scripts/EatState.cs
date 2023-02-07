using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatState : BaseState
{
    bool reachedTable = false;
    //float timer = 4;
    public override void OnStart(WorkerStateMachine stateMachine)
    {
        label = "Eat";
        fsm = stateMachine;
        destination = fsm.MoveTo(Waypoints.Table);
    }

    public override void OnUpdate()
    {
        if (!reachedTable && Vector3.Distance(fsm.GetAgentPosition(), destination) < fsm.stoppingDistance)
        {
            reachedTable = true;
        }
        else if (reachedTable)
        {
            fsm.stats.hunger -= Time.deltaTime;
            if (fsm.stats.hunger <= 0)
            {
                OnEnd();
            }
        }
    }

    public override void OnEnd()
    {
        if(fsm.stats.work < 1.0f)
        {
            fsm.OnStateEnd(new WorkState());
        }
        else
        {
            fsm.OnStateEnd(new WatchTvState());
        }
    }

}
