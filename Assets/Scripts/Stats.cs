
using UnityEngine;

[System.Serializable]
public class Stats
{
    public float hunger = 0.5f, work = 0f;
    public float hungerSpeed = 0.05f, workSpeed = 0.1f;



    public void AddHunger()
    {
        hunger = Mathf.Min(hunger + hungerSpeed*Time.deltaTime, 1);
    }

    public void DoWork()
    {
        work += workSpeed * Time.deltaTime;
    }
}
