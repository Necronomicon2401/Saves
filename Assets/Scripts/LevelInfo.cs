using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private Text hp;
    [SerializeField] private Text coins;
    [SerializeField] private Text level;
    [SerializeField] private GameObject winPanel;

    [SerializeField] private GameObject go;
    [SerializeField] private GameObject[] coinsObjects;

    private Save save;

    private Controller _controller;
    private Player _player;

    private void Start()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
        _controller = go.GetComponent<Controller>();
        _player = _controller.player;
        
        for (int i = 0; i < coinsObjects.Length; i++)
        {
            var coin = coinsObjects[i].GetComponent<Coin>();
            coin.isActive = _controller.save.activeCoins[i];
            coin.SetActive();
        }
    }

    private void Update()
    {
        if (_player is null)
        {
            _player = go.GetComponent<Controller>().player;
            return;
        }
        
        hp.text = _player.health.ToString();
        coins.text = _player.coins.ToString();
        level.text = _player.level.ToString();

        if (_controller.endOfGame)
        {
            winPanel.SetActive(true);
        }
    }

    public void Save()
    {
        save = _controller.save;
        
        for (int i = 0; i < coinsObjects.Length; i++)
        {
            save.activeCoins[i] = coinsObjects[i].GetComponent<Coin>().isActive;
        }
        
        save.position = go.transform.position;
        save.rotation = go.transform.rotation.eulerAngles;
        save.scene = SceneManager.GetActiveScene().buildIndex;

        var path = Path.Combine(Application.dataPath + "/save.json");
        var dataToSave = JsonUtility.ToJson(save, true);
        Debug.Log(dataToSave);
        File.WriteAllText(path, dataToSave);
        Debug.Log("dataPath : " + path);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}