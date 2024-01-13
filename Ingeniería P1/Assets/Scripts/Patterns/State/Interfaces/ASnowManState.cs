using UnityEngine;

namespace Patterns.State.Interfaces
{
    public abstract class ASnowManState : IState
    {
        protected ISnowMan snowMan;
        
        public ASnowManState(ISnowMan snowMan)
        {
            this.snowMan = snowMan;
        }
        
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
        public abstract void FixedUpdate();
    }
}