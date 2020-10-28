
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class texto : MonoBehaviour
{
    public TextMeshProUGUI optr;
    public TextMeshProUGUI valor1;
    public TextMeshProUGUI Valor2;
    public static int val1=-1;
    public static int n1;
    public static int n2;
    private static int operacion;
    public static List<int> true_N1 = new List<int>();
    public static List<int> true_N2 = new List<int>();
    public static List<string> operador = new List<string>();
    public static List<int> respuesta = new List<int>();
    public GameObject[] enemy;
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    void UpdateText(string operador, int n1, int n2)
    {
        optr.text = operador;
        valor1.text = n1.ToString();
        Valor2.text = n2.ToString();
    }

    void Update()
    {
        if (val1 >= 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (val1 >= true_N1.Count - 1)
                {
                    val1 = 0;
                }
                else
                {
                    val1++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                if (val1 == 0)
                {
                    val1 = true_N1.Count - 1;
                }
                else
                {
                    val1--;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                operator_gen(Random.Range(1, 4));

            }
            UpdateText(operador[val1], true_N1[val1], true_N2[val1]);
        }
    }
    public static void operator_gen(int x)
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
                respuesta.Add(operacion);
                Debug.Log(n1 + "+" + n2 + "=" + operacion);
                

                break;
            case 2:
                Debug.Log("Resta");
                if(n1 > n2)
                {
                    int temp = n1;
                    n1 = n2;
                    n2 = temp;
                }
                operacion = n1 - n2;
                true_N1.Add(n1);
                true_N2.Add(n2);
                respuesta.Add(operacion);
                Debug.Log(n1 + "-" + n2 + "=" + operacion);
                break;
            case 3:
                Debug.Log("Multiplicacion");
                operacion = n1 * n2;
                true_N1.Add(n1);
                true_N2.Add(n2);
                respuesta.Add(operacion);
                Debug.Log(n1 + "x" + n2 + "=" + operacion);
                break;
            case 4:
                Debug.Log("Division");
                operacion = n1 / n2;
                true_N1.Add(operacion);
                true_N2.Add(n1);
                operador.Add("÷");
                respuesta.Add(n2);
                Debug.Log(operacion + "/" + n1 + "=" + n2);
                break;
            
        }
        
    }
}
