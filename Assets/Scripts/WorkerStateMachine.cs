using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class WorkerStateMachine : MonoBehaviour
{
    [SerializeReference] BaseState currentState;
    public Stats stats;
    public NavMeshAgent agent;
    public Transform door, kitchen, table, bed, sink, workstation, tv;
    public float stoppingDistance;


    public TextMeshProUGUI stateText;
    public Image hungerFill, workFill;

    void Start()
    {
        stats = new Stats();
        stats.hunger = Random.Range(0.1f, 0.9f);
        agent = GetComponent<NavMeshAgent>();
        stoppingDistance = 0.2f;
        currentState = new WakeupState();
        currentState.OnStart(this);
        UpdateText();
    }

    void Update()
    {
        currentState.OnUpdate();
        hungerFill.fillAmount = stats.hunger;
        workFill.fillAmount = stats.work;
    }

    public void OnStateEnd(BaseState nextState)
    {
        currentState = nextState;
        currentState.OnStart(this);
        UpdateText();
    }

    public Vector3 MoveTo(Waypoints wp)
    {
        Vector3 destination = GetWaypoint(wp).position;
        agent.SetDestination(destination);
        return destination;
    }

    public Vector3 GetAgentPosition()
    {
        return transform.position;
    }

    private void UpdateText()
    {
        stateText.text = currentState.label;
    }

    public Transform GetWaypoint(Waypoints destination)
    {
        switch (destination)
        {
            case Waypoints.Kitchen:
                return kitchen;
            case Waypoints.Table:
                return table;
            case Waypoints.Bed:
                return bed;
            case Waypoints.Sink:
                return sink;
            case Waypoints.Workstation:
                return workstation;
            case Waypoints.Tv:
                return tv;
            default:
                return door;
        }
    }
}
