using System.Collections;
using UnityEngine;

namespace com.ggames4u.scifidisplays {
    [RequireComponent(typeof(Transform))]
    public class DisplayRotation : MonoBehaviour {
        #region Variables
        private Transform m_Transform;
        private float calculatedRotationAngle = 0f;
        public enum AxeTypes {
            X,
            Y,
            Z
        };

        [Tooltip("The rotation axe. Must be set to X for the Com Display.")]
        [SerializeField] private AxeTypes axeType;

        [Tooltip("The rotation angle. Possible values are between -90 and +90 degrees.")]
        [Range(-90, 90)]
        [SerializeField] private float rotationAngle;
        [SerializeField] private float rotationSpeed = 1f;

        [Tooltip("The time after which the rotation starts in seconds. If you need a longer time, just increase the Range max value in the script.")]
        [Range(0, 25)]
        [SerializeField] private float delay = 1f;
        private bool canRotate = false;
        #endregion

        #region Builtin Methods
        private void Start() {
            m_Transform = transform;

            // Make sure the value is positive
            rotationSpeed = Mathf.Abs(rotationSpeed);

            calculatedRotationAngle = (rotationAngle < 0f) ? 360 - Mathf.Abs(rotationAngle) : rotationAngle;

            // Delay before start to rotate
            if (delay > 0f) {
                StartCoroutine(Delay());
            }
        }

        private void LateUpdate() {
            if (canRotate) {
                if (axeType == AxeTypes.X && Mathf.Floor(transform.localRotation.eulerAngles.x) != Mathf.Floor(calculatedRotationAngle)) {
                    transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(calculatedRotationAngle, 0f, 0f), rotationSpeed * Time.deltaTime);

                } else if (axeType == AxeTypes.Y && Mathf.Floor(transform.localRotation.eulerAngles.y) != Mathf.Floor(calculatedRotationAngle)) {
                    transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0f, calculatedRotationAngle, 0f), rotationSpeed * Time.deltaTime);

                } else if (axeType == AxeTypes.Z && Mathf.Floor(transform.localRotation.eulerAngles.z) != Mathf.Floor(calculatedRotationAngle)) {
                    transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0f, 0f, calculatedRotationAngle), rotationSpeed * Time.deltaTime);
                }
            }
        }
        #endregion

        #region Custom Methods
        private IEnumerator Delay() {
            yield return new WaitForSeconds(delay);
            canRotate = true;
        }
        #endregion
    }
}
