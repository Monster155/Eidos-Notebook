using My.Utils;
using UnityEngine;
using UnityEngine.Pool;

namespace My.Notes
{
    public class NotesPool
    {
        private IObjectPool<Note> _pool;

        public IObjectPool<Note> Pool
        {
            get
            {
                return _pool ??= new ObjectPool<Note>(
                    CreatePooledItem,
                    OnTakeFromPool,
                    OnReturnedToPool,
                    OnDestroyPoolObject);
            }
        }

        private Note CreatePooledItem()
        {
            Note notePrefab = Resources.Load<Note>(Constants.NotePath);
            Note note = Object.Instantiate(notePrefab);

            return note;
        }

        private void OnReturnedToPool(Note note)
        {
            note.gameObject.SetActive(false);
        }

        private void OnTakeFromPool(Note note)
        {
            note.gameObject.SetActive(true);
        }

        private void OnDestroyPoolObject(Note note)
        {
            Object.Destroy(note.gameObject);
        }
    }
}