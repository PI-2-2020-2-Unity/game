
using UnityEngine;
using TMPro;

public class texto : MonoBehaviour
{
    public TextMeshProUGUI optr;
    public TextMeshProUGUI valor1;
    public TextMeshProUGUI Valor2;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        optr.text = operation_gen.operador[operation_gen.val1];
        valor1.text = operation_gen.true_N1[operation_gen.val1].ToString();
        Valor2.text = operation_gen.true_N2[operation_gen.val1].ToString();
    }
}
