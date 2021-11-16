using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightGlobalPoint : MonoBehaviour
{
    private float aux = 0;
    private Light2D lg;

    private void Awake()
    {
        lg = GetComponent<Light2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startLight()
    {
        StartCoroutine(light2DOn());
    }

    IEnumerator light2DOn()
    {
        yield return new WaitForSeconds(0.05f);
        if (aux <= 1)
        {
            aux += 0.1f;
            lg.intensity = aux;
            StartCoroutine(light2DOn());
        }
    }
}
