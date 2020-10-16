
using UnityEngine;
using TMPro;

public class texto : MonoBehaviour
{

    int operacion;

    char operador;
    int n1;
    int n2;
    int val1 = 0;
    public TextMeshProUGUI optr;
    public TextMeshProUGUI valor1;
    public TextMeshProUGUI Valor2;
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
<<<<<<< HEAD
        if (operation_gen.val1 >= 0)
        {
            optr.text = operation_gen.operador[operation_gen.val1];
            valor1.text = operation_gen.true_N1[operation_gen.val1].ToString();
            Valor2.text = operation_gen.true_N2[operation_gen.val1].ToString();
        }
=======
        if (Input.GetKeyDown(KeyCode.E))
        {
            val1 = (val1+1)%3;
            operator_gen(Random.Range(1, 5));
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            val1 = (val1-1)%3;
            operator_gen(Random.Range(1, 5));
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
                operador = '+';
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
                Debug.Log(n1 + "-" + n2 + "=" + operacion);
                break;
            case 3:
                Debug.Log("Multiplicacion");
                operacion = n1 * n2;
                Debug.Log(n1 + "x" + n2 + "=" + operacion);
                break;
            case 4:
                Debug.Log("Division");
                operacion = n1 / n2;
                Debug.Log(operacion + "/" + n1 + "=" + n2);
                break;
            default:
                break;
        }
        UpdateText(operador.ToString(), n1, n2);
>>>>>>> 617cf60cd345a4dd3c3a233b7b8324c449be9730
    }
}
