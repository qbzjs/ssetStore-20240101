using System.Collections;
using UnityEngine;

namespace com.ggames4u.scifidisplays {
    [RequireComponent(typeof(Transform))]
    public class LaptopDisplayRotation : MonoBehaviour {
        #region Variables
        private Transform m_Transform;

        [Tooltip("The rotation angle. Possible values are between -360 and +360 degrees.")]
        [Range(-180, 180)]
        [SerializeField] private float rotationAngle;
        [SerializeField] private float rotationSpeed = 5f;

        [Tooltip("The time after which the rotation starts in seconds. If you need a longer time, just increase the Range max value in the script.")]
        [Range(0, 25)]
        [SerializeField] private float delay = 1f;
        #endregion

        #region Builtin Methods
        private void Start() {
            m_Transform = transform;

            // Make sure the value is positive
            rotationSpeed = Mathf.Abs(rotationSpeed);

            // Delay before start to rotate
            if (delay > 0f) {
                StartCoroutine(Delay());

            } else {
                StartCoroutine(OpenDisplayRotation());
            }

            // Close display.
            StartCoroutine(CloseDelay(delay + 30));
        }
        #endregion

        #region Custom Methods
        private IEnumerator Delay() {
            yield return new WaitForSeconds(delay);
            StartCoroutine(OpenDisplayRotation());
        }

        private IEnumerator CloseDelay(float delay) {
            yield return new WaitForSeconds(delay);

            StartCoroutine(CloseDisplayRotation());

            // Close side displays
            LaptopSideDisplay.MoveOut = false;
        }

        /// <summary>
        /// Open the display.
        /// </summary>
        /// <returns></returns>
        private IEnumerator OpenDisplayRotation() {
            float rotated = 0;
            bool directionPositive = (rotationAngle > 0) ? true : false;
            Vector3 rotation = Vector3.zero;

            do {
                float angle = Time.deltaTime * rotationSpeed;

                if (directionPositive) {
                    rotation = Vector3.left * angle;
                    rotated += angle;

                } else {
                    rotation = Vector3.right * angle;
                    rotated += angle;
                }
                
                m_Transform.Rotate(rotation, Space.Self);

                yield return null;

            } while (rotated < Mathf.Abs(rotationAngle));
        }

        /// <summary>
        /// Close display. It is important that the display is completly open before starting this coroutine.
        /// </summary>
        /// <returns></returns>
        private IEnumerator CloseDisplayRotation() {
            float rotated = 0;
            bool directionPositive = (rotationAngle > 0) ? true : false;
            Vector3 rotation = Vector3.zero;

            do {
                float angle = Time.deltaTime * rotationSpeed;

                if (directionPositive) {
                    rotation = Vector3.right * angle;
                    rotated += angle;

                } else {
                    rotation = Vector3.left * angle;
                    rotated += angle;
                }

                m_Transform.Rotate(rotation, Space.Self);

                yield return null;

            } while (rotated < Mathf.Abs(rotationAngle));
        }
        #endregion
    }
}