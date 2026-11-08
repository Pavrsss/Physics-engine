public struct Vector
{
    public double X { get; set; }
    public double Y { get; set; }
    public Vector(double x, double y)
    {
        X = x;
        Y = y;
    }
}

// this is entirely useless
public class Physics
{
    private List<particleBody> particleBodies = new List<particleBody>();

    public static readonly Dictionary<string, double> Constants = new Dictionary<string, double>
    {

        ["c"] = 3.00e8, //speed of light in vacuo
        ["e"] = 1.60e-19, //magnitude of the charge of electron
        ["h"] = 6.63e-34,//the Planck constant
        ["G"] = 6.67e-11,//gravitational constant
        ["𝑁A"] = 6.02e23,//the Avogadro constant
        ["𝑚e"] = 9.11e-31,//electron rest mass
        ["𝑚p"] = 1.673e-27,//proton rest mass
        ["𝑚n"] = 1.675e-27,//neutron rest mass
        ["g"] = 9.81,//gravitational field strength / Acceleration due to gravity
        ["u"] = 1.661e-27,//atomic mass unit
        ["k"] = 8.99e9 // Coulomb's constant

    };


    public static double moments(decimal force, decimal distance, double Theta)
    {
        
        double moments = (double)force * (double)distance * Math.Sin(Theta);
        return (double)moments;
    }
    public static (double time, double finalVelocity) kinematcs(double distance, double initialVelocity, double acceleration)
    {

        double finalVelocity = Math.Sqrt(Math.Pow(initialVelocity, 2) + 2 * acceleration * distance);
        double time = (finalVelocity - initialVelocity) / acceleration;
        return (time, finalVelocity);
    }

    private void forceCalculation()
    {
        for (int i = 0; i < particleBodies.Count(); i++)
        {
            for (int j = 0; j < particleBodies.Count(); j++)
            {
                
                var body1 = particleBodies[i];
                
                var body2 = particleBodies[j];
                
                double directionX = body2.position.X - body1.position.X;
                double directionY = body2.position.Y - body1.position.Y;
                double distanceSquared = directionX * directionX + directionY * directionY;
                double distanceNew = Math.Sqrt(distanceSquared);
                
                if (distanceNew == 0) continue;

                double unitX = directionX / distanceNew;
                double unitY = directionY / distanceNew;

                double G = Constants["G"];
                double forceGravity = G * (body1.mass * body2.mass) / distanceSquared;

                double k = Constants["k"];
                double forceElectric = k * (body1.charge * body2.charge) / distanceSquared;

                double totalForce = forceGravity + forceElectric;

                body1.resultantForce = new Vector(unitX * totalForce + body1.resultantForce.X, body1.resultantForce.Y + unitY * totalForce);

            }
        }
    }

    public void updateFactors(double time)
    {
        forceCalculation();

        foreach (var body in particleBodies)
        {
            
            double accelerationX = body.resultantForce.X / body.mass;
            double accelerationY = body.resultantForce.Y / body.mass;
            
            body.velocity = new Vector(body.velocity.X + accelerationX * time, body.velocity.Y + accelerationY * time);
            
            body.position = new Vector(body.position.X + body.velocity.X * time, body.position.Y + body.velocity.Y * time);
            
            body.resultantForce = new Vector(0, 0);
        }
    }



    public class particleBody
    {
        
        public Vector position { get; set; }
        public Vector velocity { get; set; }
        public Vector resultantForce { get; set; }
        public double mass { get; set; }
        public double radius { get; set; }
        public double charge { get; set; }
    }
    public void AddParticle(particleBody body)
    {
        particleBodies.Add(body);
    }
}