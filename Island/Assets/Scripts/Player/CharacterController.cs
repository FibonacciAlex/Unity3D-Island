using UnityEngine;

namespace Kola.Test {
    public class CharacterController : MonoBehaviour {
        public string movementParam;
        public string jumpParam;
        public string[] attacksParam;

        [SerializeField]
        public float jumpPower = 3.0f;
        [SerializeField]
        public float moveSpeed = 5.0f;
        [SerializeField]
        public float movingTurnSpeed = 360;
        [SerializeField]
        public float stationaryTurnSpeed = 180;
        [SerializeField]
        public float groundCheckDistance = 0.01f;

        private new Transform camera;
        private bool startJump;
        private bool isGrounded;
        private Animator animator;
        private new Rigidbody rigidbody;
        private new Collider collider;

        void Start() {
            camera = Camera.main.transform;
            animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody>();
            collider = GetComponent<Collider>();
            //rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }

        void Update() {
            if (!startJump)
                startJump = Input.GetButtonDown("Jump");
        }

        void FixedUpdate() {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 cameraForward = Vector3.Scale(camera.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 move = v * cameraForward + h * camera.right;

#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift))
                move *= 0.5f;
#endif

            Move(move, startJump);
            startJump = false;
        }

        public void Move(Vector3 move, bool jump) {
            RaycastHit hitInfo;
            Vector3 startPoint = transform.position + Vector3.up * collider.bounds.center.y;
            isGrounded = Physics.Raycast(startPoint, Vector3.down, out hitInfo, collider.bounds.center.y + groundCheckDistance);

            if (isGrounded) {
                if (jump) {
                    rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpPower, rigidbody.velocity.z);
                    isGrounded = false;
                } else if (Time.deltaTime > 0) {
                    move.y = rigidbody.velocity.y;
                    rigidbody.velocity = move;
                }
            }

            move = transform.InverseTransformDirection(move);
            float turnAngle = Mathf.Atan2(move.x, move.z);
            float turnSpeed = Mathf.Lerp(stationaryTurnSpeed, movingTurnSpeed, move.z);
            transform.Rotate(0, turnAngle * turnSpeed * Time.deltaTime, 0, Space.Self);

            animator.SetFloat(movementParam, move.z, 0.1f, Time.deltaTime);
            animator.SetBool(jumpParam, !isGrounded);
        }

        public void PlayTriggerAnimation(string animationName) {
            Animator animator = GetComponent<Animator>();
            if (animator == null)
                return;

            animator.SetTrigger(animationName);
        }

        public void PlayBoolAnimation(string animationName) {
            Animator animator = GetComponent<Animator>();
            if (animator == null)
                return;

            animator.SetBool(animationName, true);
        }

      /*  public void AddEffect(AnimationEvent evt) {
            string bindName = evt.stringParameter;
            GameObject effect = Instantiate(evt.objectReferenceParameter) as GameObject;
            Transform bindNode = null;
            if (bindName == ".")
                bindNode = transform;
            else if (!string.IsNullOrEmpty(bindName)) {
                Transform transformBind = gameObject.transform.FindChild(bindName);
                if (transformBind != null)
                    bindNode = transformBind;
            }

            if (bindNode != null) {
                effect.transform.SetParent(bindNode, false);
            } else {
                effect.transform.Translate(transform.position, Space.World);
                effect.transform.RotateAround(transform.position, Vector3.up, transform.eulerAngles.y);
            }

            effect.AddComponent<DestroyEffect>();
        }*/
    }
}
