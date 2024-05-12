using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 10f;

        [Header("Shoot")] [SerializeField] private float shootCooldown = 0.1f;

        private PlayerInputHandler _inputHandler;

        private void Awake()
        {
            _inputHandler = PlayerInputHandler.Instance;
            
        }

        private void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            Vector2 moveDir = _inputHandler.MoveInput.normalized;
            print(moveDir);
            
            transform.Translate(moveDir * (moveSpeed * Time.deltaTime));
        }
    }
}
