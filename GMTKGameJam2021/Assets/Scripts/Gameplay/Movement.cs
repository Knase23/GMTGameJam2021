using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        public float speed;
        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            inputDirection.Normalize();
            Vector3 velocity = new Vector3(inputDirection.x, 0, inputDirection.y);
            _rigidbody.velocity = velocity * speed;
        }
    }
}
