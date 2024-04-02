using System;
using UnityEngine;

namespace Core.Game.Common.Behaviors {
    public class DrawRadar : MonoBehaviour {
        public LineRenderer lineDrawer;
        public float radius = 3f;
        public float thetaScale = 0.01f;

        private int _size;
        private float _theta;


        private void Update() {
            _theta = 0f;
            _size = (int)(1f / thetaScale + 1f);
            lineDrawer.positionCount = _size;

            for (int i = 0; i < _size; i++) {
                _theta += (2.0f * Mathf.PI * thetaScale);
                float x = radius * Mathf.Cos(_theta);
                float y = radius * Mathf.Sin(_theta);
                lineDrawer.SetPosition(i, transform.position + new Vector3(x, y, 0));
            }
        }
    }
}