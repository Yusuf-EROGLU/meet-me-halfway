using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLevelAchived())
        {
            Debug.Log("bölüm bitti");
        }
        else if (isLevelFailed())
        {
            Debug.Log("Bölüm Başarısız");

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Male"))
        {
            ScoreManager.maleOntheButton = true;
        }
        else if (other.tag.Equals("Female"))
        {
            ScoreManager.femaleOntheButton = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Male"))
        {
            ScoreManager.maleOntheButton = false;
        }
        else if (other.tag.Equals("Female"))
        {
            ScoreManager.femaleOntheButton = false;
        }
    }
    private bool isLevelAchived()
    {
        bool located = ScoreManager.femaleOntheButton && ScoreManager.maleOntheButton;
        bool loaded = ScoreManager.femaleLoad == 2 && ScoreManager.maleLoad == 2;
        if (located && loaded)
        {
            return true;
        }
        return false;
    }
    private bool isLevelFailed()
    {
        bool fall = ScoreManager.femaleFalling || ScoreManager.maleFalling;
        return fall;
    }

}
