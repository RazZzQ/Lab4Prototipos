using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float SpeedMultiplier;
    [SerializeField] private float ForceJump;
    [SerializeField] private float RayDistance;
    [SerializeField] private bool CanJump;
    [SerializeField] private LayerMask layer;

    //Private
    private Vector2 Speed;
    private Rigidbody2D rb2D;

    void LoadComponent()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadComponent();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(Speed.x * SpeedMultiplier, rb2D.velocity.y);
        //Jump Logic
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, RayDistance, layer);
        if (hit.collider != null && hit.collider.CompareTag("Floor")) CanJump = true;
    }
    public void Movement(InputAction.CallbackContext context)
    {
        Speed = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && CanJump)
        {
            print("salte");
            rb2D.velocity = new Vector2(rb2D.velocity.x, ForceJump);
            CanJump = false;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * RayDistance);
    }
}
