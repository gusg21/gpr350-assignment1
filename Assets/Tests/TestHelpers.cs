using System;
using System.Collections;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.TestTools.Utils;

public class TestHelpers {

    public static IEnumerator TestVelocity(Particle2D particle, Vector2 expectedVelocity, int iterations = 3)
    {
        const float TOLERANCE = 1e-5f;

        var comparer = new Vector3EqualityComparer(TOLERANCE);

        Vector3 startPos = particle.transform.position;

        float accumulatedTime = 0;
        for (int i = 0; i < iterations; i++)
        {
            yield return new WaitForFixedUpdate();
            accumulatedTime += Time.fixedDeltaTime;
        }
        float dt = accumulatedTime;

        Vector3 endPos = particle.transform.position;
        Assert.AreEqual(startPos.z, endPos.z);

        Vector3 expectedEndPos = startPos + new Vector3(expectedVelocity.x, expectedVelocity.y, startPos.z) * dt;
        Assert.That(endPos, Is.EqualTo(expectedEndPos).Using(comparer),
            "End position is ({0:0.00000}, {1:0.00000}, {2:0.00000}) but expected ({3:0.00000}, {4:0.00000}, {5:0.00000}) (are you using FixedUpdate?)",
            endPos.x, endPos.y, endPos.z, expectedEndPos.x, expectedEndPos.y, expectedEndPos.z);
    }

    public static void SetValue(object obj, string field, object value)
    {
        FieldInfo fieldInfo = obj.GetType().GetField(field);
        Assert.IsNotNull(fieldInfo, $"Can't set field '{field}' of type '{obj.GetType()}' because it does not exist.");
        fieldInfo.SetValue(obj, value);
    }
}
