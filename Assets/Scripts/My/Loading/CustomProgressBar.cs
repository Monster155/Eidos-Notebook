using UnityEngine;
using UnityEngine.UI;

namespace My.Loading
{
    public class CustomProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _progressImage;

        public void SetProgress(float progress)
        {
            _progressImage.fillAmount = progress;
        }
    }
}