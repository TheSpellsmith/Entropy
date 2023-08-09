using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class GameManager : MonoBehaviour
{
    //ENCAPSULATION
    public static GameManager Instance { get; private set; }
    public float playerScore;
    public float finalScore;
    public float highScore;
    public float spawnInterval;
    public float objectSpeed;
    public float spawnChance;
    public float satalitesDestroyed;
    public float level;
    public int playerLives;
    public float previousHighScore;



    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;       
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    public void Update()
    {
        ManageDifficulty();
    }

    [SerializeField]

    public void AddScore100()
    {
        playerScore += 100 * level;
        satalitesDestroyed += 1;
    }

    public void AddScore200()
    {
        playerScore += 200 * level;
        satalitesDestroyed += 1;
    }

    public void LoseScore300()
    {
        playerScore -= 600 * (level/2);
    }

    public void ManageDifficulty()
    {
        if (satalitesDestroyed > 64)
        {
            objectSpeed = 200;
            spawnChance = 2;
            spawnInterval = .5f;
            level = 6;
        }
        else if (satalitesDestroyed > 32)
        {
            objectSpeed = 150;
            spawnChance = 3;
            spawnInterval = .7f;
            level = 5;
        }
        else if (satalitesDestroyed > 16)
        {
            objectSpeed = 100;
            spawnChance = 4;
            spawnInterval = 1f;
            level = 4;
        }
        else if (satalitesDestroyed > 8)
        {
            objectSpeed = 80;
            spawnChance = 5;
            spawnInterval = 1.2f;
            level = 3;
        }
        else if (satalitesDestroyed > 4)
        {
            objectSpeed = 70;
            spawnChance = 5.5f;
            spawnInterval = 1.5f;
            level = 2;
        }
        else
        {
            objectSpeed = 60;
            spawnChance = 6;
            spawnInterval = 2;
            level = 1;
        }
    }

    public void setHighScore()
    {
        if (finalScore > highScore)
        {
            previousHighScore = highScore;
            highScore = finalScore;

        }
    }

    public void ResetGame()
    {
        if(playerLives < 1)
        {
            SaveScore();
            finalScore = playerScore;
            setHighScore();
            satalitesDestroyed = 0;
            playerLives = 4;
            StartCoroutine(SwitchToDeadScene());
        }
        else
        {
            SaveScore();
            playerLives -= 1;
            StartCoroutine(SwitchToNextLife());
        }

    }

    IEnumerator SwitchToDeadScene()
    {
        yield return new WaitForSeconds(1.5f);
        playerScore = 0;
        SceneManager.LoadScene(2);
    }

    IEnumerator SwitchToNextLife()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }
    [SerializeField]

    class SaveData
    {
        public float highScore;
    }


    public void SaveScore()
    {
        #if UNITY_EDITOR

#else
        SaveData data = new SaveData();
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
#endif

    }

    public void LoadScore()
    {
        #if UNITY_EDITOR

#else
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;

        }
#endif
    }
}
