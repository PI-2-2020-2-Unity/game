using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bondaries : MonoBehaviour
{
    private Vector2 screenbounds;

    // Start is called before the first frame update
    void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;

    }
}
