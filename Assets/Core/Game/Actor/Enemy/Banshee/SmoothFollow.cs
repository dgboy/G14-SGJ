using UnityEngine;

namespace Core.Game.Actor.Enemy.Banshee {
    public class SmoothFollow : MonoBehaviour {
        public Transform target;            // Цель, за которой следует камера
        public float smoothSpeed = 0.125f;  // Скорость перемещения камеры
        public Vector3 offset;              // Смещение камеры относительно цели

        void FixedUpdate () {
            Vector3 desiredPosition = target.position + offset;           // Новое положение камеры
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);  // Плавное перемещение камеры к новому положению
            transform.position = smoothedPosition;                         // Установка нового положения камеры
        }

    }
}