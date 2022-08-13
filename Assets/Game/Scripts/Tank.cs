using System;

namespace ProjectTank
{
    public class Tank
    {
        public static event Action<Tank> OnStartToChargeCannon;
        public static event Action<Tank, PlanedVector3> OnCannonFired;

        public class Stats
        {
            private readonly PlanedVector3 position;
            public int HP { get; private set; }
            public int Attack { get; private set; }

            public Stats(PlanedVector3 startPosition, int startHP, int startAttack)
            {
                position = startPosition;
                HP = startHP;
                Attack = startAttack;
            }

            public PlanedVector3 GetPosition()
            {
                return new PlanedVector3().Set(position.X, position.Z);
            }

            public void AddPosition(float x, float z)
            {
                position.Add(x, z);
            }
        }

        public Stats CurrentStats { get; private set; }

        private enum State
        {
            Idle,
            Charging
        }

        private State m_currentState = State.Idle;

        public Tank(PlanedVector3 startPosition, int startHP, int startAttack)
        {
            CurrentStats = new Stats(startPosition, startHP, startAttack);
        }

        public void Move(PlanedVector3 add)
        {
            if (m_currentState != State.Idle)
                return;

            CurrentStats.AddPosition(add.X, add.Z);
        }

        public void StartCharge()
        {
            m_currentState = State.Charging;

            OnStartToChargeCannon?.Invoke(this);
        }

        public void FireCannon(PlanedVector3 force)
        {
            PlanedVector3 currentPos = CurrentStats.GetPosition();
            OnCannonFired?.Invoke(this, force.Add(currentPos.X, currentPos.Z));
        }
    }
}
