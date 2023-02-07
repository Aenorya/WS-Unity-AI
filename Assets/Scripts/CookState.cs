using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookState : BaseState
{
    bool reachedKitchen;
    float timer = 4; // 4 seconds to cook

    public override void OnStart(WorkerStateMachine stateMachine)
    {
        label = "Cook";
        fsm = stateMachine;
        destination = fsm.MoveTo(Waypoints.Kitchen);
    }

    public override void OnUpdate()
    {
        fsm.stats.AddHunger();
        if (!reachedKitchen && Vector3.Distance(fsm.GetAgentPosition(), destination) < fsm.stoppingDistance)
        {
            //
            reachedKitchen = true;
        } else if (reachedKitchen)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                OnEnd();
            }
        }
    }
    public override void OnEnd()
    {
        fsm.OnStateEnd(new EatState());
    }
}
