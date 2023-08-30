using My.Notes;
using UnityEngine;

namespace My.Factories
{
    public class NotesFactory
    {
        private readonly NotesPool _notesPool;

        public NotesFactory()
        {
            _notesPool = new NotesPool();
        }

        public Note InstantiateNote(Transform parent)
        {
            Note note = _notesPool.Pool.Get();
            note.transform.SetParent(parent);
            note.transform.localScale = Vector3.one;
            return note;
        }

        public void DestroyNote(Note note)
        {
            _notesPool.Pool.Release(note);
        }
    }
}