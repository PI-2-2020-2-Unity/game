using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemy_text : MonoBehaviour
{
    public TextMeshProUGUI true_respuesta;
    private int valor;

    // Start is called before the first frame update
    void Start()
    {
        valor = operation_gen.respuesta[operation_gen.respuesta.Count - 1];
        true_respuesta.text = valor.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
