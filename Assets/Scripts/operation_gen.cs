using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class operation_gen : MonoBehaviour
{
    public static int val1 = 0;
    public static int n1;
    public static int n2;
    public static List<int> true_N1 = new List<int>();
    public static List<int> true_N2 = new List<int>();
    public static List<string> operador = new List<string>();
    private int operacion;
    public static List<int> respuesta = new List<int>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (val1 == 3)
            {
                val1 = 0;
            }
            else
            {
                val1++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (val1 == 0)
            {
                val1 = 3;
            }
            else
            {
                val1--;
            }
        }
    }
    public void operator_gen(int x)
    {
        n1 = Random.Range(1, 10);
        n2 = Random.Range(1, 10);
        switch (x)
        {
            case 1:
                Debug.Log("Suma");
                operacion = n1 + n2;
                true_N1.Add(n1);
                true_N2.Add(n2);
                operador.Add("+");
                Debug.Log(n1 + "+" + n2 + "=" + operacion);
                respuesta.Add(operacion);

                break;
            case 2:
                Debug.Log("Resta");
                if (n1 >= n2)
                {
                    operacion = n1 - n2;
                    true_N1.Add(n1);
                    true_N2.Add(n2);
                    Debug.Log(n1 + "-" + n2 + "=" + operacion);

                }
                else
                {
                    operacion = n2 - n1;
                    true_N1.Add(n2);
                    true_N2.Add(n1);
                    Debug.Log(n2 + "-" + n1 + "=" + operacion);
                }
                respuesta.Add(operacion);
                operador.Add("-");
                break;
            case 3:
                Debug.Log("Multiplicacion");
                operacion = n1 * n2;
                operador.Add("×");
                true_N1.Add(n1);
                true_N2.Add(n2);
                Debug.Log(n1 + "x" + n2 + "=" + operacion);
                respuesta.Add(operacion);
                break;
            case 4:
                Debug.Log("Division");
                operacion = n1 * n2;
                true_N1.Add(operacion);
                true_N2.Add(n1);
                operador.Add("÷");
                Debug.Log(operacion + "÷" + n1 + "=" + n2);
                respuesta.Add(n2);
                break;
            default:
                break;

        }
    }
}