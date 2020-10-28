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
        texto.operator_gen(Random.Range(1, 4));
        valor = texto.respuesta[texto.respuesta.Count - 1];
        true_respuesta.text = valor.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
