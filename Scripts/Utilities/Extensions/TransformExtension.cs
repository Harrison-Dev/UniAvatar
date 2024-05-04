using System.Collections.Generic;
using UnityEngine;

public static class TransformExtension
{
    public static void SetPositionX(this Transform t, float x)
    {
        var position = t.position;
        t.position = new Vector3(x, position.y, position.z);
    }
    public static void SetPositionY(this Transform t, float y)
    {
        var position = t.position;
        t.position = new Vector3(position.x, y, position.z);
    }
    public static void SetPositionZ(this Transform t, float z)
    {
        var position = t.position;
        t.position = new Vector3(position.x, position.y, z);
    }

    public static void SetLocalPositionX(this Transform t, float x)
    {
        var position = t.localPosition;
        t.localPosition = new Vector3(x, position.y, position.z);
    }
    public static void SetLocalPositionY(this Transform t, float y)
    {
        var position = t.localPosition;
        t.localPosition = new Vector3(position.x, y, position.z);
    }
    public static void SetLocalPositionZ(this Transform t, float z)
    {
        var position = t.localPosition;
        t.localPosition = new Vector3(position.x, position.y, z);
    }

    public static void SetLocalScaleX(this Transform t, float x)
    {
        var scale = t.localScale;
        t.localScale = new Vector3(x, scale.y, scale.z);
    }
    public static void SetLocalScaleY(this Transform t, float y)
    {
        var scale = t.localScale;
        t.localScale = new Vector3(scale.x, y, scale.z);
    }
    public static void SetLocalScaleZ(this Transform t, float z)
    {
        var scale = t.localScale;
        t.localScale = new Vector3(scale.x, scale.y, z);
    }
}
