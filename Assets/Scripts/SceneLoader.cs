using UnityEngine;
using UnityEngine.SceneManagement;

namespace GPG212_04
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
