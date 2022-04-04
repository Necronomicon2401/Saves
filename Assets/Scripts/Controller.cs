using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public Save save;
    public Player player;
    private float _speed = 0.3f;

    private Rigidbody _rb;

    public bool endOfGame = false;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        string path = Path.Combine(Application.dataPath + "/toLoad.json");
        
        save = JsonUtility.FromJson<Save>(File.ReadAllText(path));
        player = save.player;
        transform.position = save.position;
        transform.rotation = Quaternion.Euler(save.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.IsAlive())
        {
            gameObject.SetActive(false);
            this.enabled = false;
            SceneManager.LoadScene(0);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (player.level == 3 && SceneManager.GetActiveScene().buildIndex != 2)
        {
            SaveDataToNextLevel();
            SceneManager.LoadScene(2);
        }

        if (player.level == 5)
        {
            endOfGame = true;
        }
        
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) *  _speed;
        dir = Vector3.ClampMagnitude(dir, _speed);

        if (dir != Vector3.zero)
        {
            transform.Translate(dir * _speed, Space.World);
            _rb.MoveRotation(Quaternion.LookRotation(dir));
        }
    }
    
    private void SaveDataToNextLevel()
    {
        Save nextLevel = new Save(save.scene++);
        nextLevel.player = save.player;

        var path = Path.Combine(Application.dataPath + "/toLoad.json");
        var dataToSave = JsonUtility.ToJson(nextLevel, true);
        Debug.Log(dataToSave);
        File.WriteAllText(path, dataToSave);
        Debug.Log("dataPath : " + path);
    }
}
