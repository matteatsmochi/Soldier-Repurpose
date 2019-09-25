
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    static sceneManager Instance;
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    public void LoadS(int index)
    {
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
    }

}
