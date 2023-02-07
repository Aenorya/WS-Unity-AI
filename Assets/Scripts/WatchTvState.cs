using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTvState : BaseState
{
    bool watchTv = false;
    float tvTimer = 4;
    public override void OnStart(WorkerStateMachine stateMachine)
    {
        label = "Watch TV";
        fsm = stateMachine;
        destination = fsm.MoveTo(Waypoints.Tv);
    }

    public override void OnUpdate()
    {
        if (!watchTv && Vector3.Distance(fsm.GetAgentPosition(), destination) < fsm.stoppingDistance)
        {
            watchTv = true;
        }else if (watchTv)
        {
            tvTimer -= Time.deltaTime;
            if (tvTimer <= 0)
            {
                OnEnd();
            }
        }
    }

    public override void OnEnd()
    {
        Debug.Log("Tu as gagné la vie");
    }

}
