using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject boss100;
    public GameObject boss75;
    public GameObject boss50;
    public GameObject boss25;

    private int impacts = -1;

    private enemy_text text;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        impacts++;
        Debug.Log("ontrigger");
        if (collider.tag == "PlayerBullet")
        {
            Debug.Log("collider");
            switch (impacts)
            {
                case 1:
                    {
                        Debug.Log("Holi1");
                        boss100.SetActive(false);
                        boss75.SetActive(true);
                        Destroy(collider.gameObject);
                        break;
                    }
                case 2:
                    {
                        Debug.Log("Holi2");
                        boss75.SetActive(false);
                        boss50.SetActive(true);
                        Destroy(collider.gameObject);
                        break;
                    }
                case 3:
                    {
                        Debug.Log("Holi3");
                        boss50.SetActive(false);
                        boss25.SetActive(true);
                        Destroy(collider.gameObject);
                        break;
                    }
                default:
                    {
                        Destroy(collider.gameObject);
                        Debug.Log("GANASTE");
                        break;
                    }
            }
            //if (text.getValor() == texto.respuesta[texto.val1])
            //{
            //    AudioSource.PlayClipAtPoint(deathClip, gameObject.transform.position, 60);
            //    controller.text.remove_operation(texto.val1);
            //    StartCoroutine(Die());
            //}
        }
    }
}
