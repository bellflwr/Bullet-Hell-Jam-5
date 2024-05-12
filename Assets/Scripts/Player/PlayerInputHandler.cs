using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [Header("Input Action Asset")] [SerializeField]
        private InputActionAsset playerControls;

        [Header("Action Map Name References")] [SerializeField]
        private string actionMapName = "Player";

        [Header("Action Name References")]
        [SerializeField] private string move = "Move";

        [SerializeField] private string shoot = "Shoot";

        private InputAction _moveAction;
        private InputAction _shootAction;

        public Vector2 MoveInput { get; private set; }
        public bool ShootTriggered { get; private set; }


        public static PlayerInputHandler Instance { get; private set; }


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            _moveAction = playerControls.FindActionMap(actionMapName).FindAction(move);
            _shootAction = playerControls.FindActionMap(actionMapName).FindAction(shoot);
            RegisterInputActions();
        }

        void RegisterInputActions()
        {
            _moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
            _moveAction.canceled += context => MoveInput = Vector2.zero;

            _shootAction.performed += context => ShootTriggered = true;
            _shootAction.canceled += context => ShootTriggered = false;
        }

        private void OnEnable()
        {
            _moveAction.Enable();
            _shootAction.Enable();
        }

        private void OnDisable()
        {
            _moveAction.Disable();
            _shootAction.Disable();
        }
    }
}