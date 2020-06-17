using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    ///!!!!!! this class is temp solution


    public GameObject MaleObsttaclePrefab;
    public GameObject FemaleObsttaclePrefab;
    public GameObject noRigidBarrelPrefab;
    public GameObject femaleCharacter;
    public GameObject maleCharacter;
    public GameObject failCanvas;
    public GameObject nextLevelCanvas;
    public int levelGoal;


    // Start is called before the first frame update
    void Awake()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (isLevelAchived())
        {
            Debug.Log("bölüm bitti");
            if (!nextLevelCanvas.activeSelf) { nextLevelCanvas.SetActive(true); }
        }
        else if (isLevelFailed())
        {
            Debug.Log("Bölüm Başarısız");
            
            if (!failCanvas.activeSelf) { failCanvas.SetActive(true); }

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
        bool loaded = ScoreManager.femaleLoad == levelGoal && ScoreManager.maleLoad == levelGoal;
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



    public void LevelReset(int level)
    {
        switch (level)
        {
            case 1:
              
                SceneManager.LoadScene("Level2");
                break;
        }
    }

    private void ResetCharactersPosition()
    {
        femaleCharacter.transform.position = new Vector3(5.5f, 0.5f, 1.5f);
   
        maleCharacter.transform.position = new Vector3(-7.5f, 0.5f, 1.5f); 
}

}
