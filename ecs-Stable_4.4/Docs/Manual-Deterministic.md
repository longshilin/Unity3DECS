
# Deterministic Operations [![](Logo-Tiny.png)](/../../#glossary)
In ME.ECS there are several places where general logic must be replaced with deterministic logic.

### Random

As you know (I hope) all random values must deterministic, so if you need to use some random logic, you can use one of these methods:
| Method | Replace |
| ------ | ------- |
| ```float UnityEngine.Random.Range(float, float)``` | ```float world.GetRandomRange(float, float)``` | |
| Returns random float value in range [min, max) |
| ```int UnityEngine.Random.Range(int, int)``` | ```int world.GetRandomRange(int, int)``` |
| Returns random float value in range [min, max) |
| ```Unity.Mathematics.Random::NextFloat(float, float)``` | ```float world.GetRandomRange(float, float)``` |
| Returns random float value in range [min, max) |
| ```Unity.Mathematics.Random::NextInt(int, int)``` | ```int world.GetRandomRange(int, int)``` |
| Returns random int value in range [min, max) |
| ```Unity.Mathematics.Random::NextFloat3(float3, float3)``` | ```Vector3 world.GetRandomInSphere(Vector3 center, float maxRadius)``` |
| Returns random point in sphere |
| ```UnityEngine.Random.value``` | ```float world.GetRandomValue()``` |
| Returns random float in range 0..1 |
| ```Unity.Mathematics.Random::NextFloat(0f, 1f)``` | ```float world.GetRandomValue()``` |
| Returns random float in range 0..1 |

> Note! We are recommend to use Unity.Mathematics package instead of UnityEngine.Random. To use Unity.Mathematics package you should set UNITY_MATHEMATICS define on.

> Note! Using world.GetRandom*() methods couldn't be called inside systems with **jobs** on. You can turn of this check by disabling WORLD_THREAD_CHECK.

### HashSet and Dictionary

In deterministic logic you couldn't use default HashSet and Dictionary because it call GetHashCode() method on your instances.
You should override GetHashCode() method to be able to use these collection types.
     
[![](Footer.png)](/../../#glossary)
