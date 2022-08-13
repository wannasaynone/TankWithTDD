namespace ProjectTank
{
    public class PlanedVector3
    {
        public float X { get; private set; }
        public float Z { get; private set; }

        public PlanedVector3 Set(float x, float z)
        {
            X = x;
            Z = z;

            return this;
        }

        public PlanedVector3 Add(float x, float z)
        {
            X += x;
            Z += z;

            return this;
        }
    }
}