using UnityEngine;
using UnityEngine.InputSystem;

namespace NaughtyCharacter
{
    public class PlayerInputComponent : MonoBehaviour
    {
        [Header("Mobile Input")]
        // Gunakan 'global::Joystick' untuk memaksa Unity mengambil script 
        // dari folder 'Joystick Pack' Anda, bukan dari Input System.
        [SerializeField] private global::Joystick _joystick;

        [Header("Slow Motion Settings")]
        [SerializeField] private float _slowMoScale = 0.3f;
        [SerializeField] private GameObject _slowMoUI;
        private bool _isSlowMo = false;

        public Vector2 MoveInput { get; private set; }
        public Vector2 LastMoveInput { get; private set; }
        public Vector2 CameraInput { get; private set; }
        public bool JumpInput { get; private set; }
        public bool HasMoveInput { get; private set; }

        private Vector2 _keyboardMoveInput;

        private void Start()
        {
            if (_slowMoUI != null)
                _slowMoUI.SetActive(false);
        }

        private void Update()
        {
            Vector2 joystickInput = Vector2.zero;

            if (_joystick != null)
            {
                joystickInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
            }

            // === TAMBAHKAN BARIS DEBUG INI ===
            if (joystickInput.sqrMagnitude > 0f)
            {
                Debug.Log("Joystick Terbaca: " + joystickInput);
            }
            // =================================

            Vector2 activeMoveInput = joystickInput.sqrMagnitude > 0.001f ? joystickInput : _keyboardMoveInput;

            bool hasMoveInput = activeMoveInput.sqrMagnitude > 0.0f;
            if (HasMoveInput && !hasMoveInput)
            {
                LastMoveInput = MoveInput;
            }

            MoveInput = activeMoveInput;
            HasMoveInput = hasMoveInput;

            if (Keyboard.current != null && Keyboard.current.tKey.wasPressedThisFrame)
            {
                ToggleSlowMo();
            }
        }
        // ==========================================
        //  FUNGSI BARU UNTUK JUMP (MOBILE BUTTON)
        // ==========================================
        public void SetJumpInput(bool value)
        {
            // === TAMBAHKAN BARIS DEBUG INI UNTUK TES ===
            Debug.Log("Sinyal Tombol Jump Mobile Terbaca: " + value);
            // ===========================================

            JumpInput = value;
        }

        // ==========================================
        //  FUNGSI BARU UNTUK SLOWMO (MOBILE BUTTON)
        // ==========================================
        public void ToggleSlowMo()
        {
            if (!_isSlowMo)
                ActivateSlowMo();
            else
                DeactivateSlowMo();
        }

        private void ActivateSlowMo()
        {
            Time.timeScale = _slowMoScale;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            _isSlowMo = true;
            if (_slowMoUI != null) _slowMoUI.SetActive(true);
        }

        private void DeactivateSlowMo()
        {
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02f;
            _isSlowMo = false;
            if (_slowMoUI != null) _slowMoUI.SetActive(false);
        }

        // ==========================================
        //  EVENT INPUT SYSTEM (KEYBOARD / MOUSE)
        // ==========================================
        public void OnMoveEvent(InputAction.CallbackContext context)
        {
            _keyboardMoveInput = context.ReadValue<Vector2>();
        }

        public void OnLookEvent(InputAction.CallbackContext context)
        {
            CameraInput = context.ReadValue<Vector2>();
        }

        public void OnJumpEvent(InputAction.CallbackContext context)
        {
            if (context.started || context.performed)
                JumpInput = true;
            else if (context.canceled)
                JumpInput = false;
        }
    }
}