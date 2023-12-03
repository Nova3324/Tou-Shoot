using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InputsController : MonoBehaviour
{
    private PlayerInput m_playerInput;
    [SerializeField] private PlayerController m_playerController;

    [Header("GameObjects")]
    [SerializeField] private GameObject m_pause;
    [SerializeField] private GameObject m_settings;

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
        if (context.started)
            m_playerController.m_canFire = true;
        else if (context.canceled)
            m_playerController.m_canFire = false;
    }

    public void PauseMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            m_pause.SetActive(true);
            Time.timeScale = 0f;
            m_playerInput.SwitchCurrentActionMap("Menu");
        }
    }
}
