using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dogelix.Utils
{
    [ExecuteInEditMode]
    public class SpringArm : MonoBehaviour
    {
        [Header("In Editor")]
        public bool _seeSpringArmGizmo = true;
        public bool _seeSpringArmEndPoint = false;
        public float _minArmLength = 4.0f;
        public float _maxArmLength = 15.0f;

        [Header("In Game")]
        public float _length = 10f;
        private float _prevLength;
        private Vector3 _endPoint;
        private Quaternion _prevRotation;

        public Camera  _attachedCamera;

        private void Awake()
        {
            _prevRotation = transform.rotation;   
            _prevLength = _length;
            _endPoint = transform.position + ( _length * ( -transform.forward + transform.up ) );
            _attachedCamera.transform.position = _endPoint;
        }

        private void Update()
        {
            if ( _prevLength != _length || _prevRotation != transform.rotation )
            {
                _endPoint = transform.position + ( _length * (-transform.forward + transform.up));
                _attachedCamera.transform.position = _endPoint;
                _prevLength = _length;
            }
        }

        private void OnDrawGizmos()
        {
            if ( _seeSpringArmEndPoint )
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(_endPoint, 0.2f);

                Gizmos.color = Color.green;
                Gizmos.DrawSphere(transform.position, 0.2f);
            }

            if ( _seeSpringArmGizmo )
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, _attachedCamera.transform.position);
            }
        }
    }
}