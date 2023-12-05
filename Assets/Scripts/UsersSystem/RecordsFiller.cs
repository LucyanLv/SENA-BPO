using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordsFiller : MonoBehaviour
{
    private List<UserData> _records = new List<UserData>();

    [SerializeField] public GameObject scrollViewContent;
    [SerializeField] public RecordDataView userDetailsViewPrefab;

    private void Start()
    {
        _records = FindObjectOfType<UserDataReader>().usersList;
        Debug.Log(_records.Count + "*******************");
        ShowUserDetailsListPanel();
    }
    public void ShowUserDetailsListPanel()
    {

        foreach (UserData userDetails in _records)
        {
            RecordDataView userDetailsObj = Instantiate(userDetailsViewPrefab) as RecordDataView;
            userDetailsObj.gameObject.SetActive(true);
            userDetailsObj.UpdateUserData(userDetails);
            userDetailsObj.transform.SetParent(scrollViewContent.transform, false);
        }


    }
}
