using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ExtensionMethods
{
    #region Vector
    public static Vector2 SetX(this Vector2 vector, float x)
    {
        return new Vector2(x, vector.y);
    }
    public static Vector2 AddX(this Vector2 vector, float x)
    {
        return new Vector2(vector.x + x, vector.y);
    }
    public static Vector2 GetClosestVector2From(this Vector2 vector, Vector2[] otherVectors)
    {
        if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
        var minDistance = Vector2.Distance(vector, otherVectors[0]);
        var minVector = otherVectors[0];
        for (var i = otherVectors.Length - 1; i > 0; i--)
        {
            var newDistance = Vector2.Distance(vector, otherVectors[i]);
            if (newDistance < minDistance)
            {
                minDistance = newDistance;
                minVector = otherVectors[i];
            }
        }
        return minVector;
    }
    #endregion

    #region GameObject
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : MonoBehaviour
    {
        var component = gameObject.GetComponent<T>();
        if (component == null) gameObject.AddComponent<T>();
        return component;
    }
    public static bool HasComponent<T>(this GameObject gameObject) where T : MonoBehaviour
    {
        return gameObject.GetComponent<T>() != null;
    }
    public static void DestroyObject(this GameObject obj)
    {
        UnityEngine.Object.Destroy(obj);
    }
    #endregion

    #region List
    public static T GetRandomItem<T>(this IList<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }
    public static void Shuffle<T>(this IList<T> list)
    {
        for (var i = list.Count - 1; i > 1; i--)
        {
            var j = UnityEngine.Random.Range(0, i + 1);
            var value = list[j];
            list[j] = list[i];
            list[i] = value;
        }
    }
    #endregion

    #region Transform
    public static void DestroyChildren(this Transform transform)
    {
        for (var i = transform.childCount - 1; i >= 0; i--)
        {
            UnityEngine.Object.Destroy(transform.GetChild(i).gameObject);
        }
    }
    public static void ResetTransformation(this Transform transform)
    {
        transform.position = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }
    #endregion

    #region Rigidbody
    public static void ChangeDirection(this Rigidbody rb, Vector3 direction)
    {
        rb.velocity = direction.normalized * rb.velocity.magnitude;
    }
    public static void NormalizeVelocity(this Rigidbody rb, float magnitude = 1)
    {
        rb.velocity = rb.velocity.normalized * magnitude;
    }
    #endregion
}
