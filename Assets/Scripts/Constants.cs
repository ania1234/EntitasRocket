using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Constants : MonoBehaviour {

    public static string persistentFileName = "levelInfo.dat";
    public const int VersionNumber = 1;
    public const int FirstLevelWithShots = 3;

    public const int MAX_LEVELS = 8;
    public const float MAX_A = 3.0f;
    public const float MIN_A = -3.0f;
    public const float MAX_B = 2.0f;
    public const float MIN_B = 0.2f;
    public const float MAX_SPEED = 15.0f;
    public const float MIN_SPEED = 1.0f;
    public const int MAX_HEALTH = 3;
    public const int MIN_HEALTH = 0;
    public const float MAX_SIZE = 3.0f;
    public const float MIN_SIZE = 0.5f;
    public const int MAX_AMMO = 3;
    public const int MIN_AMMO = 0;
    public const float FARTHEST_X_POSITION = 14.0f;

    public const string PLAYER_ID = "Player";

    public const float SCALE_MODIFIER = 0.7f;

    public static Constants constants;

    public Dictionary<char, AsteroidMappingData> AsteroidMapping = new Dictionary<char, AsteroidMappingData>();

    public static Dictionary<int, Tuple<Rigidbody2D, string>> ExplanationContent = new Dictionary<int, Tuple<Rigidbody2D, string>>();

    public static class Tags
    {
        public const string Gold = "Gold";
        public const string Player = "Player";
    }
    void Start()
    {
        constants = this;
        AsteroidMapping.Add(asteroidMarks.greenAsteroid, new AsteroidMappingData(){
            assetName = "greenAsteroid", shouldAddSineMovement=false
        });
        AsteroidMapping.Add(asteroidMarks.greenAsteroidMobile, new AsteroidMappingData()
        {
            assetName = "greenAsteroid",
            shouldAddSineMovement = false
        });
        AsteroidMapping.Add(asteroidMarks.redAsteroid, new AsteroidMappingData()
        {
            assetName = "redAsteroid",
            shouldAddSineMovement = false
        }); ;
        AsteroidMapping.Add(asteroidMarks.redAsteroidMobile, new AsteroidMappingData()
        {
            assetName = "redAsteroid",
            shouldAddSineMovement = false
        });
        AsteroidMapping.Add(asteroidMarks.goldenAsteroid, new AsteroidMappingData()
        {
            assetName = "goldenAsteroid",
            shouldAddSineMovement = false
        });
        AsteroidMapping.Add(asteroidMarks.goldenAsteroidMobile, new AsteroidMappingData()
        {
            assetName = "goldenAsteroid",
            shouldAddSineMovement = false
        });
        AsteroidMapping.Add(asteroidMarks.turboAsteroid, new AsteroidMappingData()
        {
            assetName = "turboAsteroid",
            shouldAddSineMovement = false
        }); ;
        AsteroidMapping.Add(asteroidMarks.turboAsteroidMobile, new AsteroidMappingData()
        {
            assetName = "turboAsteroid",
            shouldAddSineMovement = false
        }); ;
        AsteroidMapping.Add(asteroidMarks.healAsteroid, new AsteroidMappingData()
        {
            assetName = "healAsteroid",
            shouldAddSineMovement = false
        }); ;
        AsteroidMapping.Add(asteroidMarks.healAsteroidMobile, new AsteroidMappingData()
        {
            assetName = "healAsteroid",
            shouldAddSineMovement = false
        }); ;
        AsteroidMapping.Add(asteroidMarks.shootAsteroid, new AsteroidMappingData()
        {
            assetName = "shootAsteroid",
            shouldAddSineMovement = false
        }); ;
        AsteroidMapping.Add(asteroidMarks.shootAsteroidMobile, new AsteroidMappingData()
        {
            assetName = "shootAsteroid",
            shouldAddSineMovement = false
        }); ;
        AsteroidMapping.Add(asteroidMarks.bigAsteroid, new AsteroidMappingData()
        {
            assetName = "bigAsteroid",
            shouldAddSineMovement = false
        }); ;
        AsteroidMapping.Add(asteroidMarks.bigAsteroidMobile, new AsteroidMappingData()
        {
            assetName = "bigAsteroid",
            shouldAddSineMovement = false
        }); ;
        AsteroidMapping.Add(asteroidMarks.smallAsteroid, new AsteroidMappingData()
        {
            assetName = "smallAsteroid",
            shouldAddSineMovement = false
        }); ;
        AsteroidMapping.Add(asteroidMarks.smallAsteroidMobile, new AsteroidMappingData()
        {
            assetName = "smallAsteroid",
            shouldAddSineMovement = false
        }); ;
    }

    public static class SceneNames
    {
        public static string StartScene = "StartScene";
        public static string GameScene = "Scene1";
        public static string LevelSelectionScene = "MenuScene";
        public static string LooseScene = "GameOverScene";
        public static string WinScene = "WinScene";
        public static string CutScene = "CutScene";
        public static string MiddleScene = "ExplanationScene";
    }

    public static class asteroidMarks
    {
        public static char redAsteroid = 'r';
        public static char redAsteroidMobile = 'R';

        public static char greenAsteroid = 'g';
        public static char greenAsteroidMobile = 'G';

        public static char goldenAsteroid = 'y';
        public static char goldenAsteroidMobile = 'Y';

        public static char turboAsteroid = 't';
        public static char turboAsteroidMobile = 'T';

        public static char healAsteroid = 'h';
        public static char healAsteroidMobile = 'H';

        public static char instantDeathAsteroid = 'd';
        public static char instantDeathAsteroidMobile = 'D';

        public static char shootAsteroid = 's';
        public static char shootAsteroidMobile = 'S';

        public static char bigAsteroid = 'b';
        public static char bigAsteroidMobile = 'B';

        public static char smallAsteroid = 'm';
        public static char smallAsteroidMobile = 'M';

    }

    public class AsteroidMappingData
    {
        public string assetName;
        public bool shouldAddSineMovement;
    }

}
