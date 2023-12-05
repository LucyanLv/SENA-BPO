using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

[System.Serializable]
public class UserData
{
    public string userName;
    public string code;
    public int maxLevel;
    public int correctAnswer;

    public UserData()
    {
    }

    public UserData(string userNames, string codee)
    {
        userName = userNames;
        code = codee;
        maxLevel = 0;
        correctAnswer = 0;
    }

}
