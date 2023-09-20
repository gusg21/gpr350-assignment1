using UnityEngine;

public class Integrator
{
    public static void Integrate(Particle2D particle, float dt)
    {
        particle.transform.position += (Vector3)particle.velocity * dt;
    }
}