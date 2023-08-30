using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace My.Loading
{
    public class LoadingController : MonoBehaviour
    {
        [SerializeField] private string _sceneToLoadName;
        [SerializeField] private CustomProgressBar _progressBar;

        private AsyncOperation _loadSceneAsync;

        private void Start()
        {
            StartCoroutine(LoadingCoroutine());
            _progressBar.SetProgress(0);
        }

        private IEnumerator LoadingCoroutine()
        {
            for (float i = 0f; i < 3f; i += Time.deltaTime)
            {
                _progressBar.SetProgress(i / 3f);

                yield return null;
            }

            SceneManager.LoadScene(_sceneToLoadName);
        }
    }
}