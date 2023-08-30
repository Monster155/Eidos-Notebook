using My.Utils;
using My.Windows;
using UnityEngine;

namespace My.Factories
{
    public class WindowsFactory
    {
        private CreateNoteWindow _createNoteWindow;
        private SettingsWindow _settingsWindow;

        public SettingsWindow InstantiateSettingsWindow(Transform parent)
        {
            if (_settingsWindow != null)
            {
                _settingsWindow.gameObject.SetActive(true);
                return _settingsWindow;
            }

            SettingsWindow settingsWindowPrefab = Resources.Load<SettingsWindow>(Constants.SettingsWindowPath);
            _settingsWindow = Object.Instantiate(settingsWindowPrefab, parent);
            return _settingsWindow;
        }

        public CreateNoteWindow InstantiateCreateNoteWindow(Transform parent)
        {
            if (_createNoteWindow != null)
            {
                _createNoteWindow.gameObject.SetActive(true);
                return _createNoteWindow;
            }

            CreateNoteWindow createNoteWindowPrefab = Resources.Load<CreateNoteWindow>(Constants.CreateNoteWindowPath);
            _createNoteWindow = Object.Instantiate(createNoteWindowPrefab, parent);
            return _createNoteWindow;
        }
    }
}