using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Reflection;
using UnityEngine.InputSystem;
using UnityEngine.TestTools.Utils;
using static TestHelpers;

public class MovementTest : InputTestFixture
{
    public struct VariableTestData
    {
        public string name;
        public System.Type type;
        public override string ToString()
        {
            return $"{name}";
        }
    }

    public static VariableTestData[] variableTestDatas = new VariableTestData[]
    {
        new VariableTestData{name = "velocity", type = typeof(Vector2)},
        new VariableTestData{name = "dampingConstant", type = typeof(float)},
        new VariableTestData{name = "inverseMass", type = typeof(float)},
        new VariableTestData{name = "acceleration", type = typeof(Vector2)},
        new VariableTestData{name = "accumulatedForces", type = typeof(Vector2)}
    };
    
    [Test]
    public void VariablesExistTest([ValueSource("variableTestDatas")] VariableTestData testData)
    {
        System.Type type = typeof(Particle2D);
        System.Type variableType = testData.type;
        string variableName = testData.name;
        FieldInfo fieldInfo = type.GetField(variableName,
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        Assert.NotNull(fieldInfo, $"no instance variable named '{variableName}' is defined for class '{type.Name}'.");
        Assert.That(fieldInfo.FieldType == variableType, $"'{variableName}' variable is of type {fieldInfo.FieldType}, but should be {variableType.Name}.");
    }

    public static Vector2[] testVelocities = new Vector2[] {Vector2.zero, Vector2.one, Vector2.down,
        Vector2.left, Vector2.up, Vector2.right,
        new Vector2(Mathf.Cos(Mathf.PI/4), Mathf.Sin(Mathf.PI/4)),
        Vector2.one * 5, Vector2.left * 3, Vector2.right * 12};

    [UnityTest]
    public IEnumerator VelocityLogicTest([ValueSource("testVelocities")] Vector2 testVelocity)
    {
        Particle2D particle = new GameObject().AddComponent<Particle2D>();
        SetValue(particle, "velocity", testVelocity);

        yield return TestVelocity(particle, testVelocity);
        GameObject.Destroy(particle);
    }

    public struct IntegratorTestData
    {
        public Vector3 startPosition;
        public Vector2 startVelocity;
        public Vector3 expectedPosition;
        public float dt;
        public IntegratorTestData(Vector2 startPosition, Vector2 startVelocity, Vector2 expected, float dt)
        {
            this.startPosition = startPosition;
            this.startVelocity = startVelocity;
            this.expectedPosition = expected;
            this.dt = dt;
        }
    }

    public static IntegratorTestData[] integratorTestDatas = new IntegratorTestData[]
    {
        new IntegratorTestData(Vector3.zero, new Vector2(3, 0), new Vector3(3, 0), 1)
    };

    [Test]
    public void IntegratorTest([ValueSource("integratorTestDatas")] IntegratorTestData testData)
    {
        System.Type integratorType = System.Type.GetType("Integrator, Project");
        Assert.IsNotNull(integratorType, "Integrator type does not exist.");
        MethodInfo integrateMethod = integratorType.GetMethod("Integrate", BindingFlags.Static | BindingFlags.Public);
        Assert.IsNotNull(integrateMethod, "Integrator.Integrate does not exist.");
        Particle2D particle = new GameObject().AddComponent<Particle2D>();

        particle.transform.position = testData.startPosition;
        SetValue(particle, "velocity", testData.startVelocity);
        integrateMethod.Invoke(null, new object[] { particle, testData.dt }) ;
        Assert.That(particle.transform.position, Is.EqualTo(testData.expectedPosition).Using(Vector3EqualityComparer.Instance));
    }
}
