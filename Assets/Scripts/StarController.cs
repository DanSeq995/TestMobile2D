using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroySelf", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void destroySelf(){
        Destroy(this.gameObject);
    }
}
