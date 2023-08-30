using My.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace My.Windows
{
    public class SettingsWindow : MonoBehaviour
    {
        [SerializeField] private Button _changeLanguageButton;
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            _changeLanguageButton.onClick.AddListener(ChangeLanguageButton_OnClick);
            _exitButton.onClick.AddListener(ExitButton_OnClick);
        }

        private void ChangeLanguageButton_OnClick()
        {
            for (int i = 0; i < Localization.LANGUAGES.Length; i++)
            {
                if (Localization.LANGUAGES[i].Equals(Localization.CURRENT_LANGUAGE))
                {
                    int index = i + 1;
                    if (index >= Localization.LANGUAGES.Length)
                        index = 0;
                    
                    LanguageController.Instance.ChangeLanguage(Localization.LANGUAGES[index]);
                    
                    break;
                }
            }
        }

        private void ExitButton_OnClick()
        {
            gameObject.SetActive(false);
        }
    }
}