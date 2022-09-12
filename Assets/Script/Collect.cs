using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public characterColor color;

    void Start()
    {

        if (TryGetComponent(out RandomColor randomColor))
        {
            color = randomColor.color;
        }


    }

}
