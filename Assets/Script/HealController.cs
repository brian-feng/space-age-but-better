using System;
using UnityEngine;

public class HealController : MonoBehaviour
{
    public float amount;
    public UnitController player;
    
    public void Start()
    {
    }
    public void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "spaceship")
        {
            player.Refuel(amount);
            Destroy(gameObject);
        }
    }
}
