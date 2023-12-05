using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecordDataView : MonoBehaviour
{
    public TMP_Text user;
    public TMP_Text points;

    public void UpdateUserData(UserData userData)
    {
        user.text = userData.userName;
        points.text = string.Concat( userData.correctAnswer, " / ", userData.maxLevel, "0");
    }
}
