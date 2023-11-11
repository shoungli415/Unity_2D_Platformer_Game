using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes
{
    public class TouchingDirections : MonoBehaviour
    {
        private bool _isGrouonded = true;
        public bool IsGrounded
        {
            get { return _isGrouonded; }
            set
            {
                _isGrouonded = value;
                animator.SetBool("IsGrounded", _isGrouonded);
            }
        }

        CapsuleCollider2D touchingCol;
        Animator animator;

        public ContactFilter2D castFilter;
        [SerializeField] private float groundDistance = 0.05f;

        RaycastHit2D[] groundHits = new RaycastHit2D[5];

        private void Awake()
        {
            touchingCol = GetComponent<CapsuleCollider2D>();
            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            IsGrounded = touchingCol.Cast(Vector2.down, groundHits, groundDistance) > 0;
        }
    }
}

