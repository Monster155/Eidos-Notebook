using System;
using System.Linq;
using UnityEngine;

namespace My.Utils
{
    public class LanguageController : MonoBehaviour
    {
        public event Action LanguageChanged;
     
        public static LanguageController Instance { get; private set; }

        private void Awake()
        {
            // Make 'DontDestroyOnLoad' unique

            var objs = GameObject.FindGameObjectsWithTag("languageController");

            if (objs.Length > 1)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);

            // Create Instance for Singleton

            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }

        private void Start()
        {
            string currentLanguage = PlayerPrefs.GetString("current_language", Localization.CURRENT_LANGUAGE);
            if (!Localization.LANGUAGES.Contains(currentLanguage))
                currentLanguage = Localization.CURRENT_LANGUAGE;

            Localization.CURRENT_LANGUAGE = currentLanguage;
            LanguageChanged?.Invoke();
        }

        public void ChangeLanguage(string newLanguage)
        {
            if (Localization.LANGUAGES.Contains(newLanguage))
            {
                PlayerPrefs.SetString("current_language", newLanguage);
                PlayerPrefs.Save();

                Localization.CURRENT_LANGUAGE = newLanguage;
                LanguageChanged?.Invoke();
            }
        }
    }
}