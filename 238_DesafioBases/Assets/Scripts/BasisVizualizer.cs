using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasisVizualizer : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Text infoText;

    [Header("Basis")]
    [SerializeField] Vector2 i;
    [SerializeField] Vector2 j;

    [SerializeField] private float x;
    [SerializeField] private float y;

    private const float vectorThickness = 5.0f;

    private void OnDrawGizmos()
    {
        DrawBase();
        var v = x * i + y * j;

        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(v, vectorThickness);

        infoText.text = $"v = ({v.x}, {v.y})\ni = ({i.x}, {i.y})\nj = ({j.x}, {j.y})\nLD = {AreLineDependent(i, j)}";
    }
    private bool AreLineDependent(Vector2 a, Vector2 b)
    {
        var c = a / b;
        return Mathf.Approximately(c.x, c.y);
    }
    private void DrawBase()
    {
        Gizmos.color = Color.red;
        GizmosUtils.DrawVectorAtOrigin(i);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVectorAtOrigin(j);
    }
}
