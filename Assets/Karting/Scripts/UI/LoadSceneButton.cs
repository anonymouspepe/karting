using UnityEngine;
using UnityEngine.SceneManagement;

namespace KartGame.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        [Tooltip("What is the name of the scene we want to load when clicking the button?")]
        public string SceneName;
        public string Mode;

        public void LoadTargetScene() 
        {
            PlayerPrefs.SetString("PlayMode", Mode);
            SceneManager.LoadSceneAsync(SceneName);
        }
    }
}
