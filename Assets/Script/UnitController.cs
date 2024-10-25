using UnityEngine;

public class UnitController : MonoBehaviour
{
    public float maxhp;
    private float fuel;
    public bool player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuel = maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float dmg)
    {
        fuel -= dmg;
        if (fuel <= 0)
        {
            if (!player)
            {
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("DED");
            }
        }
    }

    public void Refuel(float amt)
    {
        if (player)
        {
            fuel += amt;
            if (fuel > maxhp)
            {
                fuel = maxhp;
            }
        }
    }
}
