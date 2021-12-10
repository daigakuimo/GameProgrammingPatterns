using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.Template
{
    public class PlayerActor : MonoBehaviour
    {
        public Transform ownTransform { get; private set; }

        private void Awake()
        {
            ownTransform = transform;
        }
        public void MoveUp()
        {
            ownTransform.position = ownTransform.position + Vector3.up;
        }

        public void MoveDown()
        {
            ownTransform.position = ownTransform.position + Vector3.down;
        }

        public void MoveRight()
        {
            ownTransform.position = ownTransform.position + Vector3.right;
        }

        public void MoveLeft()
        {
            ownTransform.position = ownTransform.position + Vector3.left;
        }
    }
}

