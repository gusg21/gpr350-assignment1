using System;
using UnityEngine;

public class Particle2D : MonoBehaviour
{
    public float inverseMass = 0;
    public Vector2 velocity = Vector2.zero;
    public Vector2 acceleration = Vector2.zero;
    public Vector2 accumulatedForces = Vector2.zero;
    public float dampingConstant = 0;

    private void FixedUpdate()
    {
        Integrator.Integrate(this, Time.deltaTime);
    }
}
