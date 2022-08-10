using UnityEngine;
using System.Collections;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace TarodevController {
    public class PlayerInput : MonoBehaviour {
        public FrameInput FrameInput { get; private set; }

        private void Update() {
            FrameInput = Gather();
        }

#if (ENABLE_INPUT_SYSTEM)
        private PlayerInputActions _actions;
        private InputAction _move, _jump, _dash, _attack, _ghostSelect, _ghostSelectHeld;
        [SerializeField]
        public bool ghostSelectHeld;

        private void Awake() {
            _actions = new PlayerInputActions();
            _move = _actions.Player.Move;
            _jump = _actions.Player.Jump;
            _dash = _actions.Player.Dash;
            _attack = _actions.Player.Attack;
            _ghostSelect = _actions.Player.GhostSelect;
            _actions.Player.GhostSelect.performed += x => ghostSelectHeld = true;
            _actions.Player.GhostSelect.canceled += x => setfalselaunch();
        }

        private void OnEnable() {
            _actions.Enable();
        }

        private void OnDisable() {
            _actions.Disable();
        }

        private void setfalselaunch(){
            StartCoroutine(SetFalse());
        }
        private IEnumerator SetFalse(){
            yield return new WaitForSeconds(0.05f);
            ghostSelectHeld = false;
        }

        private FrameInput Gather() {
            return new FrameInput {
                JumpDown = _jump.WasPressedThisFrame(),
                JumpHeld = _jump.IsPressed(),
                DashDown = _dash.WasPressedThisFrame(),
                AttackDown = _attack.WasPressedThisFrame(),
                Move = _move.ReadValue<Vector2>(),
                GhostSelectDown = _ghostSelect.WasReleasedThisFrame(),
                GhostSelectHeld = ghostSelectHeld
            };
        }

#elif (ENABLE_LEGACY_INPUT_MANAGER)
        private FrameInput Gather() {
            return new FrameInput {
                JumpDown = Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.C),
                JumpHeld = Input.GetButton("Jump") || Input.GetKey(KeyCode.C),
                DashDown = Input.GetKeyDown(KeyCode.X),
                AttackDown = Input.GetKeyDown(KeyCode.Z),
                Move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")),
            };
        }
#endif
    }

    public struct FrameInput {
        public Vector2 Move;
        public bool JumpDown;
        public bool JumpHeld;
        public bool DashDown;
        public bool AttackDown;
        public bool GhostSelectDown;
        public bool GhostSelectHeld;
    }
}