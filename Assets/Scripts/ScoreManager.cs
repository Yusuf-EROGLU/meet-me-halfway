using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager: ScriptableObject
{

    public static int maleLoad = 0;
    public static int femaleLoad = 0;

    public static bool maleOntheButton = false;
    public static bool femaleOntheButton = false;

    public static bool maleFalling = false;
    public static bool femaleFalling = false;

    public static int currentLevel = 1;

   public static void ResetScoreManager()
    {
        ScoreManager.maleLoad = 0;
        ScoreManager.femaleLoad = 0;

        ScoreManager.maleOntheButton = false;
        ScoreManager.femaleOntheButton = false;

        ScoreManager.maleFalling = false;
        ScoreManager.femaleFalling = false;
    }
}
