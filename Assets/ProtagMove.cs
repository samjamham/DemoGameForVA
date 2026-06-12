using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class ProtagMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    InputAction moveAction;
    [SerializeField]
    Rigidbody2D MyRB;


    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Vector2 moveValue = moveAction.ReadValue<Vector2>();
       MyRB.linearVelocity = moveValue * 4.0f;
    }
}
