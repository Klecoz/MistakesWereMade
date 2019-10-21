using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class DoorController : MonoBehaviour
    {
        public float Smooth = 2.0f;
        public float DoorOpenAngle = 90.0f;
        public float DoorCloseAngle = 0.0f;
        public bool IsOpenClose;
        public bool disabled;

        private float _lowPitchRange = .75F;
        private float _highPitchRange = 1.5F;

        AudioSource DoorAudio;
        public AudioClip DoorOpen;
        public bool PlayClipOnce;

        public UnityEvent OpenedTheDoor;

        void Start()
        {
            DoorAudio = GetComponent<AudioSource>();
            IsOpenClose = false;
        }

        // Update is called once per frame
        void Update()
        {
            OpenDoor();
        }

        void OpenDoor()
        {
            if (IsOpenClose == true && !disabled)
            {
                var target = Quaternion.Euler(0, DoorOpenAngle, 0);

                // Dampen towards the target rotation
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target,
                    Time.deltaTime * Smooth);

                DoorAudio.pitch = Random.Range(_lowPitchRange, _highPitchRange);
                if (PlayClipOnce == false)
                {
                    DoorAudio.PlayOneShot(DoorOpen);
                    PlayClipOnce = true;
                    OpenedTheDoor.Invoke();
                }


                if (gameObject.transform.localRotation.y == 90.0f)
                {
                    IsOpenClose = true;
                    PlayClipOnce = false;
                }


            }

            if (IsOpenClose == false && !disabled)
            {
                var target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
                // Dampen towards the target rotations

                transform.localRotation = Quaternion.Slerp(transform.localRotation, target1,
                    Time.deltaTime * Smooth);

                if (gameObject.transform.localRotation.y == 0.0f)
                {
                    IsOpenClose = false;
                }

            }
        }

        void TriggerDoor()
        {
            IsOpenClose = !IsOpenClose;
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Player" || col.gameObject.tag == "Hand")
            {
                TriggerDoor();
            }
        }
    }
}
