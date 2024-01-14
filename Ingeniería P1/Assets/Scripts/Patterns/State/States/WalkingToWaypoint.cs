using Patterns.State.Interfaces;
using UnityEngine;
using UnityEngine.Apple;

namespace Patterns.State.States
{
    public class WalkingToWaypoint : ASnowManState
    {
        private Transform currentWaypoint;
        private Transform currentTransform;
        private float speed;
        private float rotationSpeed;
        private Vector3 destination;

        private float secondsToSeek = 1f;
        private float lastSeek = 0f;

        public float time = 0f;
        private const float maxTime = 10;

        public override void Enter()
        {
            currentTransform = snowMan.GetGameObject().transform;
            currentWaypoint = snowMan.GetCurrentWayPoint();
            speed = snowMan.GetWanderSpeed();
            rotationSpeed = snowMan.GetRotateSpeed();

            snowMan.SetCurrentSpeed(speed);
            Debug.Log($"SnowMan {snowMan.GetGameObject().name} started going to waypoint {currentWaypoint.name}");
        }

        public WalkingToWaypoint(ISnowMan snowMan) : base(snowMan)
        {

        }

        public override void Exit()
        {
            Debug.Log($"SnowMan {snowMan.GetGameObject().name} ended going to waypoint {currentWaypoint.name}");
        }
        
        public override void Update()
        {
            lastSeek += Time.deltaTime;
            time += Time.deltaTime;

            if (lastSeek >= secondsToSeek)
            {
                snowMan.SetState(new SearchingForPlayer(snowMan));
                lastSeek = 0f;
                Debug.Log("Seeking for enemy");
            }

            if (time > maxTime)
            {
                Debug.Log("");
                snowMan.SetState(new SearchingForWaypoint(snowMan));
                time = 0;
            }
            
        }

        public override void FixedUpdate()
        {
            snowMan.MoveTo(currentWaypoint, speed, rotationSpeed);

            Vector3 toWaypoint = currentWaypoint.position - currentTransform.position;
            toWaypoint.y = 0;
            float distanceToWaypoint = toWaypoint.magnitude;
            
            // Debug.Log($"Distance to waypoint: {distanceToWaypoint}");
            if (distanceToWaypoint <= speed)
            {
                Debug.Log($"Waypoint {currentWaypoint.name} reached");
                snowMan.SetState(new SearchingForWaypoint(snowMan));
            } 
        }
    }
}