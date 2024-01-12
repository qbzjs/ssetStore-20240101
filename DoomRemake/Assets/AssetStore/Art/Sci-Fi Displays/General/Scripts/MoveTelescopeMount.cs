using System.Collections;
using UnityEngine;

namespace com.ggames4u.scifidisplays {
    [RequireComponent(typeof(Transform))]
    public class MoveTelescopeMount : MonoBehaviour {
        #region Variables
        private Transform m_Transform;

        private float startPosition = 0.495f;
        private float maxPosition = 0.675f;
        private float endPosition = 0f;

        [Tooltip("The movement distance in percent between 0% - 100%")]
        [Range(0, 100)]
        [SerializeField] private float moveDistance = 50;

        [Tooltip("How fast the mount moves upwards")]
        [SerializeField] private float moveSpeed = 1f;

        [Tooltip("The time after which the movement starts in seconds. If you need a longer time, just increase the Range max value in the script.")]
        [Range(0, 25)]
        [SerializeField] private float delay = 1f;
        private bool canMove = false;
        #endregion

        #region Builtin Methods
        private void Start() {
            m_Transform = transform;

            // Make sure the value is positive
            moveSpeed = Mathf.Abs(moveSpeed);

            endPosition = maxPosition;

            // Set axe to start position
            m_Transform.localPosition = new Vector3(m_Transform.localPosition.x, startPosition, m_Transform.localPosition.z);

            // Calculate the distance the axe move up
            endPosition = startPosition + (maxPosition - startPosition) * (moveDistance * 0.01f);

            if (delay > 0f) {
                StartCoroutine(Delay());
            }
        }

        private void Update() {
            // Move mount up
            if (canMove && Mathf.Floor(transform.localPosition.y * 100) != Mathf.Floor(endPosition * 100)) {
                float newYPos = Mathf.Lerp(m_Transform.localPosition.y, endPosition, Time.deltaTime * moveSpeed);
                m_Transform.localPosition = new Vector3(m_Transform.localPosition.x, newYPos, m_Transform.localPosition.z);
            }
        }
        #endregion

        #region Custom Methods
        private IEnumerator Delay() {
            yield return new WaitForSeconds(delay);
            canMove = true;
        }
        #endregion
    }
}