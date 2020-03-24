using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static bool existAnElement = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!existAnElement)
        {
            DontDestroyOnLoad(gameObject);
            existAnElement = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
