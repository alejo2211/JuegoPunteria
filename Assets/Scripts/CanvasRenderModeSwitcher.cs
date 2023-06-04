using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class CanvasRenderModeSwitcher : MonoBehaviour
{
    private Canvas canvas;
    private Vector3 position;
    private Vector3 scale;
    private Quaternion rotation;

    private void OnEnable()
    {
        canvas = GetComponent<Canvas>();
    }

    public void SetRenderMode(RenderMode renderMode)
    {
        if (renderMode == RenderMode.WorldSpace)
        {
            // Set the render mode before values are reset.
            canvas.renderMode = renderMode;

            // Restore the values.
            transform.position = position;
            transform.rotation = rotation;
            transform.localScale = scale;
        }
        else
        {
            // Cache the values.
            position = transform.position;
            rotation = transform.rotation;
            scale = transform.localScale;

            // Set the render mode after values are cached.
            canvas.renderMode = renderMode;
        }
    }
}
