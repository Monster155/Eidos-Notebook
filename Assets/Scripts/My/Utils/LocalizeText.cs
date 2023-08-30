using TMPro;
using UnityEngine;

namespace My.Utils
{
    public class LocalizeText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private string _key;

        private void Start()
        {
            UpdateText();
        }

        private void OnEnable()
        {
            LanguageController.Instance.LanguageChanged += LanguageController_LanguageChanged;
        }
        private void OnDisable()
        {
            LanguageController.Instance.LanguageChanged -= LanguageController_LanguageChanged;
        }

        private void LanguageController_LanguageChanged()
        {
            UpdateText();
        }
        private void UpdateText()
        {
            _text.text = Localization.TABLE[Localization.CURRENT_LANGUAGE][_key];
        }
    }
}