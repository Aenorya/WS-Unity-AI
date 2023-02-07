using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public abstract class BaseState
{
    public string label = "Base State";
    protected WorkerStateMachine fsm;
    protected Vector3 destination;

    public abstract void OnStart(WorkerStateMachine stateMachine);
    public abstract void OnUpdate();

    public abstract void OnEnd();
}
