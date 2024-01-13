using System;
using Patterns.State.Interfaces;
using UnityEngine;

namespace Patterns.State.States
{
    public class SearchingForWaypoint : ASnowManState
    {
        private Transform nextWaypoint;
        private Transform currentTransform;
        private Vector3 nextWayPointDirection;
        private Quaternion nextWaypointRotation;
        private float rotateSpeed;
        
        public SearchingForWaypoint(ISnowMan snowMan) : base(snowMan)
        {
        }

        public override void Enter()
        {
            Transform[] waypoints = snowMan.GetWayPoints();
            int nextWayPointIndex = (Array.IndexOf(waypoints, snowMan.GetCurrentWayPoint()) + 1) % waypoints.Length;
            nextWaypoint = waypoints[nextWayPointIndex];
            Debug.Log($"Current waypoint {snowMan.GetCurrentWayPoint()}, going to waypoint {nextWayPointIndex}");
            snowMan.SetCurrentWayPoint(nextWaypoint);

            rotateSpeed = snowMan.GetRotateSpeed();   
            currentTransform = snowMan.GetGameObject().transform; 
            nextWayPointDirection = (nextWaypoint.transform.position - currentTransform.position).normalized;
            nextWaypointRotation = Quaternion.LookRotation(nextWayPointDirection, currentTransform.up);
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
        }

        public override void FixedUpdate()
        {
            currentTransform.transform.rotation = Quaternion.RotateTowards(currentTransform.rotation, 
                nextWaypointRotation,
                rotateSpeed * Time.fixedDeltaTime);

            float angle = Quaternion.Angle(currentTransform.rotation, nextWaypointRotation);
            if (angle < rotateSpeed * Time.fixedDeltaTime)
            {
                currentTransform.rotation = nextWaypointRotation;
                snowMan.SetState(new WalkingToWaypoint(snowMan));
            }
        }
    }
}