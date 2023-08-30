using System;
using System.Collections.Generic;
using UnityEngine;

namespace My.Notes
{
    public class NotesSaveService : MonoBehaviour
    {

        private SerializableList<NoteData> _serializedNoteDatas;
        public static NotesSaveService Instance { get; private set; }
        private List<NoteData> _noteDatas
        {
            get
            {
                return _serializedNoteDatas.list;
            }
            set
            {
                _serializedNoteDatas.list = value;
            }
        }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            _serializedNoteDatas = new SerializableList<NoteData>();
            _noteDatas = new List<NoteData>();
        }

        public void Save(string title, string body)
        {
            int newId = GetAvailableId();
            NoteData noteData = new NoteData(newId, title, body);

            _noteDatas.Add(noteData);

            string json = JsonUtility.ToJson(_serializedNoteDatas);
            PlayerPrefs.SetString("notes", json);
            PlayerPrefs.Save();

            Debug.Log($"Note '{title}' saved\n{json}");
        }

        public void Resave(int oldNoteId, string newTitle, string newBody)
        {
            NoteData newNoteData = new NoteData(oldNoteId, newTitle, newBody);

            for (int i = 0; i < _noteDatas.Count; i++)
                if (_noteDatas[i]._id == oldNoteId)
                {
                    _noteDatas.RemoveAt(i);
                    break;
                }
            _noteDatas.Add(newNoteData);

            string json = JsonUtility.ToJson(_serializedNoteDatas);
            PlayerPrefs.SetString("notes", json);
            PlayerPrefs.Save();

            Debug.Log($"Note '{newTitle}' saved\n{json}");
        }

        public List<NoteData> Load()
        {
            string json = PlayerPrefs.GetString("notes");
            _serializedNoteDatas = JsonUtility.FromJson<SerializableList<NoteData>>(json);

            if (_serializedNoteDatas == null)
                _serializedNoteDatas = new SerializableList<NoteData>();
            if (_noteDatas == null)
                _noteDatas = new List<NoteData>();

            Debug.Log($"Loaded {_noteDatas.Count} notes\n{json}");

            return _noteDatas;
        }

        private int GetAvailableId()
        {
            int id = PlayerPrefs.GetInt("last_id", 0);
            id++;
            PlayerPrefs.SetInt("last_id", id);
            PlayerPrefs.Save();
            return id;
        }

        [Serializable]
        public class NoteData
        {
            public int _id;
            public string _title;
            public string _body;

            public NoteData(int id, string title, string body)
            {
                _id = id;
                _title = title;
                _body = body;
            }
        }

        [Serializable]
        public class SerializableList<T>
        {
            public List<T> list;
        }
    }
}