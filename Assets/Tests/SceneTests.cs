using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneTests : InputTestFixture
{
    Mouse mouse { get => Mouse.current; }
    const string testSceneId = "Assets/Scenes/TestScene.unity";

    public override void Setup()
    {
        base.Setup();
        InputSystem.AddDevice<Mouse>();
        SceneManager.LoadScene(testSceneId);
    }

    public struct MouseTestData
    {
        public MouseTestData(Vector2 mouseStart, Vector2 mouseEnd)
        {
            this.mouseStart = mouseStart;
            this.mouseEnd = mouseEnd;
        }
        public Vector2 mouseStart;
        public Vector2 mouseEnd;
        public override string ToString()
        {
            return $"({mouseStart}, {mouseEnd})";
        }
    }

    public static readonly MouseTestData[] testDatas = new MouseTestData[]
    {
            new MouseTestData(Vector2.zero, Vector2.right),
            new MouseTestData(Vector2.zero, Vector2.left),
            new MouseTestData(Vector2.one, Vector2.left * 200),
            new MouseTestData(new Vector2(1.024f, 90.443f), new Vector2(53.22f, -104f)),
    };

    [UnityTest]
    public IEnumerator SceneTest([ValueSource("testDatas")] MouseTestData mouseData)
    {
        Assert.That(Camera.main.orthographic, "Main camera is not orthographic.");

        Move(mouse.position, mouseData.mouseStart);
        Press(mouse.leftButton);
        yield return null;
        Debug.Log($"Test suite suite pressed mouse and waited a frame. LMB pressed: {mouse.leftButton.IsPressed()}");

        Move(mouse.position, mouseData.mouseEnd);
        Release(mouse.leftButton);
        yield return null;
        Debug.Log($"Test suite released LMB and waited a frame. LMB pressed: {mouse.leftButton.IsPressed()}");

        Particle2D[] particles = GameObject.FindObjectsOfType<Particle2D>();
        Assert.AreEqual(1, particles.Length,
            $"Scene has {particles.Length} particles after mouse release, but expected 1.");
            
        Particle2D particle = particles[0];
            
        Assert.IsNull(particle.GetComponent<Rigidbody>(), "Particle has rigidbody attached.");
        Assert.IsNull(particle.GetComponent<Rigidbody2D>(), "Particle has rigidbody2d attached.");
        Vector2 velocity = Camera.main.ScreenToWorldPoint(mouseData.mouseEnd)
            - Camera.main.ScreenToWorldPoint(mouseData.mouseStart);
        yield return TestHelpers.TestVelocity(particle, velocity);
            
        GameObject.Destroy(particle);
    }
    
}
