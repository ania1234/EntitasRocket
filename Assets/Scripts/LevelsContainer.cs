﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using Entitas;

public class LevelsContainer : MonoBehaviour {


    public static int height = 6;
    public static int width;
    private static char[,] _levelMap;
    private static string[] _levels = new string[8];
    private static int _currentLevelNumber;

    public static void LoadLevel(int levelNumber)
    {
        _levels[0] = ".r...g............................g...r..........................\n" +
                    ".r...g..gggg..r.....g......gg.....r...g..gggg..gggg...g.....ggg..\n" +
                    ".r...g..g.....r.....g.....g..g....r...g..g..g..g...g..g.....g..g.\n" +
                    ".ggggg..ggg...r.....g.....g..g....r.g.g..g..g..gggg...r.....g..g.\n" +
                    ".g...g..g.....g.....g.....g..g....rg.gg..g..g..g..g...g.....g..g.\n" +
                    ".g...g..gggr..gggg..grrg...gg.....g...g..gggg..g...g..rggg..ggg..\n";


        //levels[0] = "....\n" +
        //    "....\n" +
        //    ".b..\n" +
        //    ".ggg\n" +
        //    ".g..\n" +
        //    ".g..\n";
        _levels[1] = ".rrrrr............................\n" +
                    ".g...g....gg..r.....r......gg.....\n" +
                    ".g.y.g....g...r.....r.....g..g....\n" +
                    ".ggggg....g...r..Y..r.....g..g....\n" +
                    ".rrrrr....g...r.....r.....g..g....\n" +
                    "........y.g...rggg..rrr....gg.....\n";
        _levels[2] = "...rrrrrrrgggg.g..gggg..gggg...g.....ggg..\n" +
                    "...rr.....g.....m.....g.....g..g....g...g.\n" +
                    "s..rrygg..ggg...s.....g.....g..g....g.g.g.\n" +
                    "...rr..g..g.....g.....g.....g..g....gg.gg.\n" +
                    "...rrrrrrrgggh..gggg..grrg...gg.....g...g.\n" +
                    "..........................................\n";
                    
        _levels[3] = "........gggg..m.....g......gg.....g...g..gggg..gggg...g.....ggg..g........gggg...g....g...gggg........g......g....g.gggg..........gggggg....gggggg..gggggg...gg..gg....gg...ggggg..........................................................................g...........gggg....\n" +
                    "..rrrrrrrrrrrrrrrrrr..m..t.....m.....g.....g..g....g...g..g..gg..g.......g....g..gg...g..g....g......g.g.....gg...g.g...g.........g.....g..g......g.g.....g..gg..ggg...gg..g..........................................................g..................g....g................\n" +
                    ".mgggg..ggg...s.....gbbt..g..g....g.g.g..g..g..gggg...g.....g.g..g.......g....g..g.g..g..g..........g...g....g.g..g.g....g........gggggg...g......g.g....g...gg..gg.g..gg..g.........................................g....g.......g..........g.........g.........g.....g..g..g.\n" +
                    ".grrrrrrrrrrrrrrrrrr...g..g.....g.....g.....g..g....gg.gg..g..gg.g.......g....g..g..g.g..g..gggg...ggggggg...g..g.g.g....g........g.....g..g......g.ggggg....gg..gg..g.gg..g....ggggg..t.........................g..............................g.................g........g...\n" +
                    ".....g..gggh..gggg..grrg...gg.....g...g..gggg..g...g..gggg..ggg..g.......g....g..g...gg..g....g...g.......g..g...gg.g...g.........g.....g...g....g..g....g...gg..gg...ggg..g......g...........................g............g....g......g....g.....g.................g...g......\n" +
                    "..........................................................b...g..gggggg...gggg...g....g...gggg....g........g.g....g.gggg..........gggggg.....gggg...g.....g..gg..gg....gg...gggggg.....g..g..g..g..g..g..g...g......................................g.................g........\n";
        _levels[4] = ".................................................................\n" +
                    "........gggg..m.....g......gg.....g...g..gggg..gggg...g.....ggg..\n" +
                    ".b...m..t.....m.....g.....g..g....g...g..g..g..g...g..g.....g..g.\n" +
                    ".ygggg..ggg...s.....g.....g..g....g.g.g..g..g..gggg...g.....g..g.\n" +
                    ".g...g..g.....g.....g.....g..g....gg.gg..g..g..g..g...g.....g..g.\n" +
                    ".g...g..gggh..gggg..grrg...gg.....g...g..gggg..g...g..gggg..ggg..\n";
        _levels[5] = "....\n" +
                    "....\n" +
                    ".b..\n" +
                    ".ygg\n" +
                    ".g..\n" +
                    ".g..\n";
        _levels[6] = "....\n" +
                    "....\n" +
                    ".b..\n" +
                    ".ygg\n" +
                    ".g..\n" +
                    ".g..\n";
        _levels[7] = "....\n" +
                    "....\n" +
                    ".b..\n" +
                    ".ygg\n" +
                    ".g..\n" +
                    ".g..\n";
        string levelName;
        _currentLevelNumber = levelNumber;
        if (_currentLevelNumber < Constants.MAX_LEVELS)
        {
            levelName = _levels[levelNumber - 1];
            using (StreamReader sr = new StreamReader(GenerateStreamFromString(levelName)))
            {
                string row = sr.ReadLine();

                width = row.Length;
                _levelMap = new char[width, height];
                int j = 0;
                do
                {
                    for (int i = 0; i < width; i++)
                    {
                        _levelMap[i, j] = row.ElementAt(i);
                    }
                    j++;
                    row = sr.ReadLine();
                }
                while (!sr.EndOfStream);

                for (int i = 0; i < width; i++)
                {
                    _levelMap[i, j] = row.ElementAt(i);
                }
                j++;
            }
        }
        else
        {
            width = int.MaxValue;
            height = 6;
        }
    }

    public static List<UnityEngine.Object> GetAsteroids(int currentWave)
    {
        List<UnityEngine.Object> result = new List<UnityEngine.Object>();
        if (_currentLevelNumber != Constants.MAX_LEVELS)
        {
            for (int j = 0; j < height; j++)
            {
                if (_levelMap[currentWave, j] != '.')
                {
                    result.Add(GetAsteroid(_levelMap[currentWave, j], j));
                }
            }
        }
        else
        {
            for (int j = 0; j < height; j++)
            {
                int realization = UnityEngine.Random.Range(0, Constants.constants.AsteroidMapping.Count * 14);
                print(realization);
                if (realization < Constants.constants.AsteroidMapping.Count)
                {
                    result.Add(GetAsteroid(Constants.constants.AsteroidMapping.ElementAt(realization).Key, j));
                }
                else if (realization < Constants.constants.AsteroidMapping.Count * 4)
                {
                    result.Add(GetAsteroid(Constants.constants.AsteroidMapping.ElementAt(0).Key, j));
                }
            }
 
        }
        return result;
    }

    public static List<AsteroidData> GetAsteroidsData(int currentWave)
    {
        List<AsteroidData> result = new List<AsteroidData>();
        if (_currentLevelNumber != Constants.MAX_LEVELS)
        {
            for (int j = 0; j < height; j++)
            {
                if (_levelMap[currentWave, j] != '.')
                {
                    result.Add(new AsteroidData() { 
                    height = j,
                    width = currentWave,
                    typeKey = Constants.constants.AsteroidMapping[_levelMap[currentWave, j]].assetName
                    });
                }
            }
        }
        else
        {
            for (int j = 0; j < height; j++)
            {
                int realization = UnityEngine.Random.Range(0, Constants.constants.AsteroidMapping.Count * 14);
                print(realization);
                if (realization < Constants.constants.AsteroidMapping.Count)
                {
                    result.Add(new AsteroidData()
                    {
                        height = j,
                        width = currentWave,
                        typeKey = Constants.constants.AsteroidMapping[_levelMap[currentWave, j]].assetName
                    });
                }
                else if (realization < Constants.constants.AsteroidMapping.Count * 4)
                {
                    result.Add(new AsteroidData()
                    {
                        height = j,
                        width = currentWave,
                        typeKey = Constants.constants.AsteroidMapping[_levelMap[currentWave, j]].assetName
                    });
                }
            }

        }
        return result;
    }

    public static Stream GenerateStreamFromString(string s)
    {
        MemoryStream stream = new MemoryStream();
        StreamWriter writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }

    public static UnityEngine.Rigidbody2D GetAsteroid(char mark, int i)
    {
        //UnityEngine.Rigidbody2D result;
        //result = (Rigidbody2D)Instantiate(Constants.constants.AsteroidMapping[mark].First, new Vector3(14, -1 * (i - 2), 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        //result.velocity = new Vector2(-1.0f*PersistingScript.persistingScript.rocket.speed, 0);
        //((Rigidbody2D)result).gameObject.GetComponent<OnCollisionScript>().moving = Constants.constants.AsteroidMapping[mark].Second;
        //(result).gameObject.GetComponent<OnCollisionScript>().A = UnityEngine.Random.Range(1, 5);
        //return (Rigidbody2D)result;
        return null;
    }
}

public struct AsteroidData
{
    public int width;
    public int height;
    public string typeKey;
}