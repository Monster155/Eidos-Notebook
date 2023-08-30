using My.Notes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace My.Windows
{
    public class CreateNoteWindow : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _titleText;
        [SerializeField] private TMP_InputField _bodyText;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _exitButton;

        private int _oldNoteId;

        private void Start()
        {
            _saveButton.onClick.AddListener(SaveButton_OnClick);
            _exitButton.onClick.AddListener(ExitButton_OnClick);
        }

        public void Init()
        {
            _oldNoteId = 0;

            _titleText.text = "";
            _bodyText.text = "";
        }

        public void Init(NotesSaveService.NoteData noteData)
        {
            Init();

            _oldNoteId = noteData._id;
            _titleText.text = noteData._title;
            _bodyText.text = noteData._body;
        }

        private void SaveButton_OnClick()
        {
            SaveNote(_titleText.text, _bodyText.text);
        }

        private void ExitButton_OnClick()
        {
            gameObject.SetActive(false);
        }

        private void SaveNote(string title, string body)
        {
            if (_oldNoteId > 0)
                NotesSaveService.Instance.Resave(_oldNoteId, title, body);
            else
                NotesSaveService.Instance.Save(title, body);
        }
    }
}