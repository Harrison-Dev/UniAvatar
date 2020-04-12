using UnityEngine;

public static class SpriteRendererExtension
{
    public static void SetAlpha(this SpriteRenderer renderer, float alpha)
    {
        var color = renderer.color;
        renderer.color = new Color(color.r, color.g, color.b, alpha);
    }
}
