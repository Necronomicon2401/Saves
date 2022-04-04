using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Save _save;

    private string _savePath;
    private string _basicSavePath;
    private string _toLoadPath;

    private void Awake()
    {
        _savePath = Path.Combine(Application.dataPath + "/save.json");
        _basicSavePath = Path.Combine(Application.dataPath + "/basic.json");
        _toLoadPath = Path.Combine(Application.dataPath + "/toLoad.json");
    }

    public void StartGame()
    {
        _save = JsonUtility.FromJson<Save>(File.ReadAllText(_basicSavePath));

        if (_save is null)
        {
            MakeBasicSave();
        }
        
        var dataToSave = JsonUtility.ToJson(_save, true);
        Debug.Log(dataToSave);
        File.WriteAllText(_toLoadPath, dataToSave);
        Debug.Log("dataPath : " + _toLoadPath);
        
        SceneManager.LoadScene(_save.scene);
    }

    public void LoadSave()
    {
        _save = JsonUtility.FromJson<Save>(File.ReadAllText(_savePath));
        
        var dataToSave = JsonUtility.ToJson(_save, true);
        Debug.Log(dataToSave);
        File.WriteAllText(_toLoadPath, dataToSave);
        Debug.Log("dataPath : " + _toLoadPath);
        
        SceneManager.LoadScene(_save.scene);
    }

    public void Exit()
    {
        Application.Quit();
    }
    
    //Debug tool
    public void MakeBasicSave()
    {
        Save basicSave = new Save(1);

        var path = Path.Combine(_basicSavePath);
        var dataToSave = JsonUtility.ToJson(basicSave, true);
        Debug.Log(dataToSave);
        File.WriteAllText(path, dataToSave);
        Debug.Log("dataPath : " + path);

        _save = basicSave;
        
        path = Path.Combine(_toLoadPath);
        dataToSave = JsonUtility.ToJson(basicSave, true);
        Debug.Log(dataToSave);
        File.WriteAllText(path, dataToSave);
    }
}
