using UnityEngine;

namespace KartGame.KartSystems
{

    public class KeyboardInput : BaseInput
    {
        public string TurnInputName = "Horizontal";
        public string AccelerateButtonName = "Accelerate";
        public string BrakeButtonName = "Brake";

        private bool accelerating = false;
        private bool braking = false;
        private float horizontal = 0.0f;

        public override InputData GenerateInput()
        {
            return new InputData
            {
                Accelerate = accelerating,
                Brake = braking,
                TurnInput = horizontal
            };
        }

        public void Accelerate()
        {
            accelerating = true;
        }

        public void DeAccelerate()
        {
            accelerating = false;
        }

        public void Brake()
        {
            braking = true;
        }

        public void DeBrake()
        {
            braking = false;
        }

        public void Left()
        {
            while (horizontal > -1.0f)
            {
                horizontal -= 0.05f;
            }
        }

        public void Right()
        {
            while (horizontal < 1.0f)
            {
                horizontal += 0.05f;
            }
        }

        public void DeTurn()
        {
            horizontal = 0.0f;
        }
    }
}