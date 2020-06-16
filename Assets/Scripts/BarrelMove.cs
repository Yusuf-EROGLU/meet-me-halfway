using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMove : MonoBehaviour
{
    private Vector3 height;
    
    public GameObject loadBarrelPrefab;

   
  
   
    private void OnTriggerEnter(Collider other)
    {

               
        GameObject loadBarrel = Instantiate(loadBarrelPrefab, other.transform.position, Quaternion.identity);
        loadBarrel.transform.localScale = new Vector3(0, 0, 0);

        if (other.CompareTag("Male"))
        {
            ScoreManager.maleLoad++;
            height = new Vector3(0, ScoreManager.maleLoad, 0);
            loadBarrel.transform.position += height;
        }
        else if (other.CompareTag("Female"))
        {
            ScoreManager.femaleLoad++;
            height = new Vector3(0, ScoreManager.femaleLoad, 0);
            loadBarrel.transform.position += height;
        }

        loadBarrel.transform.parent = other.transform.parent;
        Destroy(this.gameObject);
    }
}
