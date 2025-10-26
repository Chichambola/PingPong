using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string Vertical = nameof(Vertical);

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Vertical);

        Debug.Log(Direction);
    }
}
