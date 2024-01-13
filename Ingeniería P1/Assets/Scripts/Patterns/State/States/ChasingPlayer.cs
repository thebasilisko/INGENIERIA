using Patterns.State.Interfaces;
using UnityEngine;

namespace Patterns.State.States
{
    public class ChasingPlayer : ASnowManState
    {
        private Transform playerTransform;
        private Transform currentTransform;

        private float rotationSpeed;
        private float chaseSpeed;

        public ChasingPlayer(ISnowMan snowMan) : base(snowMan)
        {
        }

        public override void Enter()
        {
            currentTransform = snowMan.GetGameObject().transform;
            playerTransform = snowMan.PlayerAtSight().transform;
            rotationSpeed = snowMan.GetRotateSpeed();
            chaseSpeed = snowMan.GetChaseSpeed();
            Debug.Log($"SnowMan {snowMan.GetGameObject().name} started chasing player");
        }

        public override void Exit()
        {
            Debug.Log($"SnowMan {snowMan.GetGameObject().name} ended chasing player");
        }

        public override void Update()
        {
        }

        public override void FixedUpdate()
        {
            if (snowMan.PlayerAtSight())
            {
                snowMan.MoveTo(playerTransform, chaseSpeed, rotationSpeed);
            }
            else
            {
                snowMan.SetState(new WalkingToWaypoint(snowMan));
            }
        }
    }
}