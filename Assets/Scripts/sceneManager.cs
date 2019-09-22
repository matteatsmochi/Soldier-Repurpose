
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void LoadS(int index)
    {
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
    }

}
