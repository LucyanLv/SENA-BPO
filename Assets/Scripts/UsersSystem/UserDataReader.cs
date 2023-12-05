using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class UserDataReader : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    private const string FileName = "usersData.data";
    private string path = Path.Combine(Application.streamingAssetsPath, FileName);

    [SerializeField] public List<UserData> usersList = new List<UserData>();

    [ContextMenu("Save")]
    public void Save()
    {
        string usersInfoJson = JsonUtility.ToJson(usersList);
        File.WriteAllText(path, usersInfoJson);
        Debug.Log(path);
    }

    public void SaveActualUser()
    {
        ActualUser();

        string usersInfoJson = "[";
        for (int i = 0; i < usersList.Count; i++)
        {
            usersInfoJson = String.Concat(usersInfoJson, JsonUtility.ToJson(usersList[i]), i + 1 < usersList.Count ? "," : "]");
        }
        File.WriteAllText(path, usersInfoJson);
    }

    public void ActualUser()
    {
        bool isExists = false;
        UserData user = new UserData(PlayerPrefs.GetString("username"), PlayerPrefs.GetString("code"));

        for (int i = 0; i < usersList.Count; i++)
        {
            if (usersList[i].userName.Equals(user.userName))
            {
                isExists = true;
                Debug.Log($"Username  ' {user.userName}' already exists, updating data... ");
                usersList[i].maxLevel = PlayerPrefs.GetInt("maxlvl"); ;
                usersList[i].correctAnswer += PlayerPrefs.GetInt("maxlvl").Equals(1) ?
                    PlayerPrefs.GetInt($"correctaslvl{usersList[i].maxLevel}", 0) * -1
                    : PlayerPrefs.GetInt($"correctaslvl{usersList[i].maxLevel}", 0);
                Debug.Log(usersList[i].userName);
                Debug.Log(usersList[i].code);
                Debug.Log(usersList[i].maxLevel);
                Debug.Log(usersList[i].correctAnswer);
                break;
            }
        }
        if (!isExists)
        {
            user.maxLevel = PlayerPrefs.GetInt("maxlvl");
            user.correctAnswer += PlayerPrefs.GetInt($"correctaslvl{user.maxLevel}", 0);
            Debug.Log(user.userName);
            Debug.Log(user.code);
            Debug.Log(user.maxLevel);
            Debug.Log(user.correctAnswer);
            usersList.Add(user);
            Debug.Log(usersList.Count);
        }
    }

    [ContextMenu("Load")]
    public void Load()
    {
        string usersInfoJson = File.ReadAllText(path);
        List<UserData> loadedUsers = JsonUtility.FromJson<UserWrapper>("{\"users\":" + usersInfoJson + "}").users;
        usersList.AddRange(loadedUsers);
        Debug.Log($"HA cargado {usersList.Count} users");
    }

    [System.Serializable]
    private class UserWrapper
    {
        public List<UserData> users;
    }

    private void Awake()
    {
        Load();
    }
}