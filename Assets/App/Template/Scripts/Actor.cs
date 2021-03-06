using UnityEngine;

namespace App.Template
{
    public abstract class Actor : MonoBehaviour
    {
        public virtual void MoveUp() { }
        public virtual void MoveDown() { }
        public virtual void MoveRight() { }
        public virtual void MoveLeft() { }
    }
}