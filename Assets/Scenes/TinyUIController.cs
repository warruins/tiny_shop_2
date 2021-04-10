using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class TinyUIController : MonoBehaviour
    {
        public Canvas menu;
        private bool isOpen = false;
        private int currentScene;

        public void GetScene(int sceneIndex)
        {
            SceneManager.LoadSceneAsync(sceneIndex);
            // AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
            // while (!asyncLoad.isDone)
            // {
            //     yield return null;
            // }
        }
    }
}
