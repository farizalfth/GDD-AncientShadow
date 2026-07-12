using UnityEngine;
using UnityEngine.InputSystem;

namespace NaughtyCharacter
{
    public class PlayerInputComponent : MonoBehaviour
    {
        [Header("Mobile Input")]
        [SerializeField] private global::Joystick _joystick;

        [Header("Slow Motion Settings")]
        [SerializeField] private float _slowMoScale = 0.3f;
        [SerializeField] private GameObject _slowMoUI;
        private bool _isSlowMo = false;

        [Header("Flashlight Settings")]
        [SerializeField] private GameObject _flashlight; // Deklarasi Senter

        public Vector2 MoveInput { get; private set; }
        public Vector2 LastMoveInput { get; private set; }
        public Vector2 CameraInput { get; private set; }
        public bool JumpInput { get; private set; }
        public bool HasMoveInput { get; private set; }

        // Penampung internal untuk memisahkan input keyboard dan mobile
        private Vector2 _keyboardMoveInput;
        private bool _keyboardJumpActive;
        private bool _mobileJumpPressed;

        private void Start()
        {
            if (_slowMoUI != null)
                _slowMoUI.SetActive(false);
        }

        private void Update()
        {
            // 1. Membaca pergerakan Joystick
            Vector2 joystickInput = Vector2.zero;
            if (_joystick != null)
            {
                joystickInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
            }

            Vector2 activeMoveInput = joystickInput;

            bool hasMoveInput = activeMoveInput.sqrMagnitude > 0.0f;
            if (HasMoveInput && !hasMoveInput)
            {
                LastMoveInput = MoveInput;
            }

            MoveInput = activeMoveInput;
            HasMoveInput = hasMoveInput;

            // 2. Menggabungkan input lompat secara aman (Keyboard ATAU Mobile)
            JumpInput = _keyboardJumpActive || _mobileJumpPressed;

            // Fitur lambat lewat keyboard (Tombol T)
            if (Keyboard.current != null && Keyboard.current.tKey.wasPressedThisFrame)
            {
                ToggleSlowMo();
            }
        }

        private void LateUpdate()
        {
            // Reset input lompat mobile di akhir frame agar karakter sempat membaca status 'true'
            if (_mobileJumpPressed)
            {
                _mobileJumpPressed = false;
            }
        }

        // ==========================================
        //  FUNGSI UNTUK JUMP (MOBILE BUTTON)
        // ==========================================
        public void SetJumpInput(bool value)
        {
            Debug.Log("Sinyal Tombol Jump Mobile Terbaca: " + value);
            if (value)
            {
                _mobileJumpPressed = true;
            }
        }

        // ==========================================
        //  FUNGSI UNTUK SLOWMO (MOBILE BUTTON)
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
                _keyboardJumpActive = true;
            else if (context.canceled)
                _keyboardJumpActive = false;
        }

        // ==========================================
        //  FUNGSI UNTUK SENTER (MOBILE BUTTON)
        // ==========================================
        public void ToggleFlashlight()
        {
            if (_flashlight != null)
            {
                _flashlight.SetActive(!_flashlight.activeSelf);
                Debug.Log("Status Senter: " + _flashlight.activeSelf);
            }
        }
    }
}