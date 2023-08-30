using System.Collections.Generic;
using My.Factories;
using My.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace My.Notes
{
    public class NotesController : MonoBehaviour
    {
        [SerializeField] private Button _createButton;
        [SerializeField] private Button _loadButton;
        [SerializeField] private Button _settingsButton;
        [Space]
        [SerializeField] private WindowsManager _windowsManager;
        [SerializeField] private Transform _notesContainer;
        private List<Note> _notes;

        private NotesFactory _notesFactory;

        private void Start()
        {
            _notesFactory = new NotesFactory();
            _notes = new List<Note>();

            _createButton.onClick.AddListener(CreateButton_OnClick);
            _loadButton.onClick.AddListener(LoadButton_OnClick);
            _settingsButton.onClick.AddListener(SettingsButton_OnClick);
        }

        private void CreateButton_OnClick()
        {
            _windowsManager.OpenCreateNoteWindow();
        }

        private void LoadButton_OnClick()
        {
            for (int i = 0; i < _notes.Count; i++)
            {
                _notes[i].NoteClicked -= Note_NoteClicked;
                _notesFactory.DestroyNote(_notes[i]);
            }
            _notes.Clear();

            var noteDatas = NotesSaveService.Instance.Load();

            for (int i = 0; i < noteDatas.Count; i++)
            {
                Note note = _notesFactory.InstantiateNote(_notesContainer);
                note.NoteClicked += Note_NoteClicked;
                note.Init(noteDatas[i], i);
                _notes.Add(note);
            }
        }

        private void SettingsButton_OnClick()
        {
            _windowsManager.OpenSettingsWindow();
        }

        private void Note_NoteClicked(int index)
        {
            _windowsManager.OpenCreateNoteWindow(_notes[index].NoteData);
        }
    }
}