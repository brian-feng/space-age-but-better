using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector3 velocity;
    public float MAX_SPEED;

    public float last_shot;
    public float fire_delay;
    public GameObject bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 thrust = ((Vector3)Mouse.current.position.value - (Vector3)transform.position).normalized / 4;
        Vector3 newThrust = new Vector3(0, 0, 0);
        newThrust.x = thrust.y;
        newThrust.z = thrust.x;
        transform.Translate((velocity + newThrust) * Time.deltaTime*MAX_SPEED, Space.Self);

        Vector3 mouse = Mouse.current.position.value;
        mouse.z = Camera.main.transform.position.y;
        Vector3 world = Camera.main.ScreenToWorldPoint(mouse);
        world.y = transform.position.y;
        transform.LookAt(world);
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        velocity.x = move.x;
        velocity.z = move.y;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (last_shot + fire_delay < Time.time)
        {
            var new_bullet = Instantiate(bullet,
                     transform.position + transform.rotation * new Vector3(0, 0, 3),
                     transform.rotation);
            var ctrl = new_bullet.GetComponent<BulletController>();
            ctrl.lifetime = 3;
            ctrl.speed = 40;
            ctrl.damage = 10;
            ctrl.player = true;
            last_shot = Time.time;
        }
    }
}
