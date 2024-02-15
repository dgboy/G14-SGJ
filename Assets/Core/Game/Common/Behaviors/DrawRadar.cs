using System;
using UnityEngine;

namespace Core.Game.Common.Behaviors {
    public class DrawRadar : MonoBehaviour {
        public LineRenderer lineDrawer;
        public float thetaScale = 0.01f;
        public float Radius {
            get => _radius;
            set => _radius = value * 2f;
        }
        private int _size;
        private float _theta;
        private float _radius = 3f;


        [Obsolete("Obsolete")]
        private void Update() {
            _theta = 0f;
            _size = (int)(1f / thetaScale + 1f);
            lineDrawer.SetVertexCount(_size);

            for (int i = 0; i < _size; i++) {
                _theta += (2.0f * Mathf.PI * thetaScale);
                float x = Radius * Mathf.Cos(_theta);
                float y = Radius * Mathf.Sin(_theta);
                lineDrawer.SetPosition(i, transform.position + new Vector3(x, y, 0));
            }
        }
    }
}