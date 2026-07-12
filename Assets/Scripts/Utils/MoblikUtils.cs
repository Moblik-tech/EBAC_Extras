using UnityEngine;

public static class MoblikUtils
{
    /// <summary>
    /// Muda a escala do objeto em que o script está anexado.
    /// </summary>
    /// <param name="size">Parâmetro que influenciará a escala.</param>
    public static void ChangeScale(this Transform t, float size)
    {
        t.localScale = Vector3.one * size;
    }
}