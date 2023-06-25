using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Constants : MonoBehaviour {

    public static string persistentFileName = "levelInfo.dat";
    public const int VersionNumber = 1;
    public const int LevelsNumber = 8;
    public const int FirstLevelWithShots = 3;


    public Rigidbody2D redAsteroid;
    public Rigidbody2D greenAsteroid;
    public Rigidbody2D goldenAsteroid;
    public Rigidbody2D turboAsteroid;
    public Rigidbody2D healAsteroid;
    public Rigidbody2D instantDeathAsteroid;
    public Rigidbody2D shootAsteroid;
    public Rigidbody2D bigAsteroid;
    public Rigidbody2D smallAsteroid;
    public Rigidbody2D bullet;

    public static Constants constants;

    public Dictionary<char, Tuple<Rigidbody2D, bool>> AsteroidMapping = new Dictionary<char, Tuple<Rigidbody2D, bool>>();

    public static Dictionary<int, Tuple<Rigidbody2D, string>> ExplanationContent = new Dictionary<int, Tuple<Rigidbody2D, string>>();

    public static class Tags
    {
        public const string Gold = "Gold";
        public const string Player = "Player";
    }
    void Start()
    {
        constants = this;
        AsteroidMapping.Add(asteroidMarks.greenAsteroid, new Tuple<Rigidbody2D, bool>(greenAsteroid, false));
        AsteroidMapping.Add(asteroidMarks.greenAsteroidMobile, new Tuple<Rigidbody2D, bool>(greenAsteroid, true));
        AsteroidMapping.Add(asteroidMarks.redAsteroid, new Tuple<Rigidbody2D, bool>(redAsteroid, false));
        AsteroidMapping.Add(asteroidMarks.redAsteroidMobile, new Tuple<Rigidbody2D, bool>(redAsteroid, true));
        AsteroidMapping.Add(asteroidMarks.goldenAsteroid, new Tuple<Rigidbody2D, bool>(goldenAsteroid, false));
        AsteroidMapping.Add(asteroidMarks.goldenAsteroidMobile, new Tuple<Rigidbody2D, bool>(goldenAsteroid, true));
        AsteroidMapping.Add(asteroidMarks.turboAsteroid, new Tuple<Rigidbody2D, bool>(turboAsteroid, false));
        AsteroidMapping.Add(asteroidMarks.turboAsteroidMobile, new Tuple<Rigidbody2D, bool>(turboAsteroid, true));
        AsteroidMapping.Add(asteroidMarks.healAsteroid, new Tuple<Rigidbody2D, bool>(healAsteroid, false));
        AsteroidMapping.Add(asteroidMarks.healAsteroidMobile, new Tuple<Rigidbody2D, bool>(healAsteroid, true));
        AsteroidMapping.Add(asteroidMarks.shootAsteroid, new Tuple<Rigidbody2D, bool>(shootAsteroid, false));
        AsteroidMapping.Add(asteroidMarks.shootAsteroidMobile, new Tuple<Rigidbody2D, bool>(shootAsteroid, true));
        AsteroidMapping.Add(asteroidMarks.bigAsteroid, new Tuple<Rigidbody2D, bool>(bigAsteroid, false));
        AsteroidMapping.Add(asteroidMarks.bigAsteroidMobile, new Tuple<Rigidbody2D, bool>(bigAsteroid, true));
        AsteroidMapping.Add(asteroidMarks.smallAsteroid, new Tuple<Rigidbody2D, bool>(smallAsteroid, false));
        AsteroidMapping.Add(asteroidMarks.smallAsteroidMobile, new Tuple<Rigidbody2D, bool>(smallAsteroid, true));
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

}
