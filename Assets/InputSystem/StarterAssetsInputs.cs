using System.Diagnostics;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;
        public bool attack;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

        // Buffs
        public bool consumePotion1;
        public bool consumePotion2;
        public bool consumePotion3;
        public bool consumePotion4;
        public bool consumePotion5;
        public bool consumePotion6;


#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);

        }

        public void OnAttack(InputValue value)
        {
            AttackInput(value.isPressed);
        }

        public void OnConsumePotion1(InputValue value)
        {
            Potion1Input(value.isPressed);
        }

        public void OnConsumePotion2(InputValue value)
        {
            Potion2Input(value.isPressed);
        }
        public void OnConsumePotion3(InputValue value)
        {
            Potion3Input(value.isPressed);
        }
        public void OnConsumePotion4(InputValue value)
        {
            Potion4Input(value.isPressed);
        }
        public void OnConsumePotion5(InputValue value)
        {
            Potion5Input(value.isPressed);
        }
        public void OnConsumePotion6(InputValue value)
        {
            Potion6Input(value.isPressed);
        }


#endif


        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
        private void AttackInput(bool newAttackState)
        {
            attack = newAttackState;
        }
        private void Potion1Input(bool newState)
        {
            consumePotion1 = newState;
        }
        private void Potion2Input(bool newState)
        {
            consumePotion2 = newState;
        }
        private void Potion3Input(bool newState)
        {
            consumePotion3 = newState;
        }
        private void Potion4Input(bool newState)
        {
            consumePotion4 = newState;
        }
        private void Potion5Input(bool newState)
        {
            consumePotion5 = newState;
        }
        private void Potion6Input(bool newState)
        {
            consumePotion6 = newState;
        }

    }
}