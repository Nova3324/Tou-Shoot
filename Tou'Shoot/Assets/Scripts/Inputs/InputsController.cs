using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsController : MonoBehaviour
{
    private PlayerInput m_playerInput;
    [SerializeField] private PlayerController m_playerController;
    void Start()
    {
        m_playerInput = GetComponent<PlayerInput>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onMove(InputAction.CallbackContext context)
    {
        Vector2 horizontal = context.ReadValue<Vector2>();
        m_playerController.Move(horizontal);
    }
}
