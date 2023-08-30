using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace My.Notes
{
    public class Note : MonoBehaviour
    {

        [SerializeField] private TMP_Text _title;
        [SerializeField] private Button _openButton;
        private int _index;

        public NotesSaveService.NoteData NoteData { get; private set; }

        private void Start()
        {
            _openButton.onClick.AddListener(OpenButton_OnClick);
        }
        public event Action<int> NoteClicked;

        public void Init(NotesSaveService.NoteData noteData, int index)
        {
            NoteData = noteData;
            _title.text = NoteData._title;
            _index = index;
        }

        private void OpenButton_OnClick()
        {
            NoteClicked?.Invoke(_index);
        }
    }
}