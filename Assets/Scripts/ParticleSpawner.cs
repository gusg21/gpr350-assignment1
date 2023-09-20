using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class ParticleSpawner : MonoBehaviour
{
    public Mouse Mouse { get => Mouse.current; }
    public Particle2D ParticlePrefab;

    private Vector3 _initial;
    
    private void Awake()
    {
        InputSystem.AddDevice<Mouse>();
    }

    private void Update()
    {
        if (Mouse.press.wasPressedThisFrame)
        {
            _initial = Camera.main.ScreenToWorldPoint(Mouse.position.value);
        }

        if (Mouse.press.wasReleasedThisFrame)
        {
            var particle = Instantiate(ParticlePrefab, transform);
            particle.transform.position = Camera.main.ScreenToWorldPoint(Mouse.position.value);
            particle.transform.position = new Vector3(particle.transform.position.x, particle.transform.position.y, 0);
            particle.velocity = Camera.main.ScreenToWorldPoint(Mouse.position.value) - _initial;
        }
    }
}
