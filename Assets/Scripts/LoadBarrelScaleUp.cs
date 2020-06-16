using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBarrelScaleUp : MonoBehaviour
{
    private Vector3 scale;

    // Start is called before the first frame update
    void Awake()
    {
        scale = new Vector3(1, 0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 1)
        {
            transform.localScale += scale * Time.deltaTime * 2;
            GetComponent<BoxCollider>().attachedRigidbody.useGravity = false;
        }
        else
        {
            GetComponent<BoxCollider>().attachedRigidbody.useGravity = true;
        }
    }
}
