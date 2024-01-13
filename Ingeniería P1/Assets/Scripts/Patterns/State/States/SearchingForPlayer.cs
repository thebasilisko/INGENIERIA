using Patterns.State.Interfaces;
using UnityEngine;

namespace Patterns.State.States
{
    public class SearchingForPlayer : ASnowManState
    {
        public SearchingForPlayer(ISnowMan snowMan) : base(snowMan)
        {
        }

        public override void Enter()
        {
            Debug.Log($"SnowMan {snowMan.GetGameObject().name} started searching for player");
        }

        public override void Exit()
        {
            Debug.Log($"SnowMan {snowMan.GetGameObject().name} ended searching for player");
        }

        public override void Update()
        {
            if (snowMan.PlayerAtSight() != null)
            {
                snowMan.SetState(new ChasingPlayer(snowMan));
            }
            else
            {
                snowMan.SetState(new WalkingToWaypoint(snowMan));
            }
        }

        public override void FixedUpdate()
        {
        }
    }
}