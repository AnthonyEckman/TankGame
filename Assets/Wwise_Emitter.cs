﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wwise_Emitter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("Play", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
