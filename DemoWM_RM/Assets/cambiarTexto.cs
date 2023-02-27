using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarTexto : MonoBehaviour
{
    public TextMesh text;

    public void cambiarTexto1(string texto)
    {
        text.text = texto;
    }
}
