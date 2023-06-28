using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GPG212_04
{
    public class TitleScreen : MonoBehaviour
    {
        [SerializeField] GameObject instructionsPanel;

        public static bool isGameTimed = true;

        public void CloseInstructionsPanel()
        {
            instructionsPanel.GetComponent<Animator>().Play("Instructions-Out");
            StartCoroutine(DisableGameObjectAfterTime(instructionsPanel, 0.5f));
        }

        private IEnumerator DisableGameObjectAfterTime(GameObject go, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            go.SetActive(false);
        }

        public void SetGameMode(bool isTimed)
        {
            isGameTimed = isTimed;
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
