using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SnowBack : MonoBehaviour
{
    public float velociCenario;
    private float camerax;
    private float cameray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MovimentaCenario();
        camerax = Camera.main.transform.position.x;
        cameray = Camera.main.transform.position.y;
        transform.position = new Vector3(camerax, cameray, transform.position.z);
    }

    private void MovimentaCenario()
    {
        Vector2 deslocamento = new Vector2(Time.time * velociCenario, 0);
        GetComponent<Renderer>().material.mainTextureOffset = deslocamento;
    }
}
