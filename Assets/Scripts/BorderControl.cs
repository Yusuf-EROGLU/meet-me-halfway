using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderControl : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Male")){
            ScoreManager.maleFalling = true;
        }
        else if (other.tag.Equals("Female"))
        {
            ScoreManager.femaleFalling = true;
        }
    }
}
