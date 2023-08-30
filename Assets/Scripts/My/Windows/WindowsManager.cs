using My.Factories;
using My.Notes;
using UnityEngine;

namespace My.Windows
{
    public class WindowsManager : MonoBehaviour
    {
        [SerializeField] private Transform _windowsContainer;

        private WindowsFactory _windowsFactory;

        private void Start()
        {
            _windowsFactory = new WindowsFactory();
        }

        public void OpenSettingsWindow()
        {
            SettingsWindow settingsWindow = _windowsFactory.InstantiateSettingsWindow(_windowsContainer);
        }

        public void OpenCreateNoteWindow()
        {
            CreateNoteWindow createNoteWindow = _windowsFactory.InstantiateCreateNoteWindow(_windowsContainer);
            createNoteWindow.Init();
        }

        public void OpenCreateNoteWindow(NotesSaveService.NoteData noteData)
        {
            CreateNoteWindow createNoteWindow = _windowsFactory.InstantiateCreateNoteWindow(_windowsContainer);
            createNoteWindow.Init(noteData);
        }
    }
}