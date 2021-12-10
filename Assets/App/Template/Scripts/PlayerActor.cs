using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.Template
{
    public class PlayerActor : Actor
    {
        public Transform ownTransform { get; private set; }

        private void Awake()
        {
            ownTransform = transform;
        }
        public override void MoveUp()
        {
            ownTransform.position = ownTransform.position + Vector3.up;
        }

        public override void MoveDown()
        {
            ownTransform.position = ownTransform.position + Vector3.down;
        }

        public override void MoveRight()
        {
            ownTransform.position = ownTransform.position + Vector3.right;
        }

        public override void MoveLeft()
        {
            ownTransform.position = ownTransform.position + Vector3.left;
        }
    }
}

