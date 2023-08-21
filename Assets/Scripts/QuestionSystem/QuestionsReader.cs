using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class QuestionsReader : MonoBehaviour
{
    private const string FileName = "questionsData.data";

    [SerializeField]
    public List<Question> questions =  new List<Question>();

    [ContextMenu("Save")]
    public void Save()
    {
        string questionsInfoJson = JsonUtility.ToJson(questions);
        string path = Path.Combine(Application.persistentDataPath, FileName);
        File.WriteAllText(path, questionsInfoJson);
        Debug.Log(path);
    }

    [ContextMenu("Load")]
    public void Load()
    {
        Debug.Log("HA entrado al load");
        string path = Path.Combine(Application.persistentDataPath, FileName);
        string questionsInfoJson = File.ReadAllText(path);
        Debug.Log($"HA leido {questionsInfoJson} questions");
        List<Question> loadedQuestions = JsonUtility.FromJson<QuestionWrapper>("{\"questions\":" + questionsInfoJson + "}").questions;
        Debug.Log($"HA puesto en json {loadedQuestions} questions");
        questions.AddRange(loadedQuestions);
        Debug.Log($"HA cargado {questions.Count} questions");

    }

    [System.Serializable]
    private class QuestionWrapper
    {
        public List<Question> questions;
    }

    private void Awake()
    {
        Load();
    }
}
