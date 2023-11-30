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

    public void onMove(InputAction.CallbackContext context)
    {
        Vector2 horizontal = context.ReadValue<Vector2>();
        m_playerController.Move(horizontal);
    }

    public void onFire(InputAction.CallbackContext context) 
    {
        if(context.started)
            m_playerController.m_canFire = true;
        else if(context.canceled)
            m_playerController.m_canFire = false;
    }
}
