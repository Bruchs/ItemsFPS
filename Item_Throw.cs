using UnityEngine;
using System.Collections;

namespace GameManager
{
	public class Item_Throw : MonoBehaviour
    {
        private Item_Master itemMaster;
        private Transform myTransform;
        private Rigidbody myRigidbody;
        public GameObject gunHands;
        public Animator gunAnimator;
        private Vector3 throwDirection;
        public string throwButtonName;

        public bool canBeThrown;
        public float throwForce;

        void Start()
        {
            SetInitialReferences();
        }

		void Update () 
		{
            CheckForThrowInput();
		}
		
		void SetInitialReferences()
		{
            itemMaster = GetComponent<Item_Master>();
            myTransform = transform;
            myRigidbody = GetComponent<Rigidbody>();
		}

        void CheckForThrowInput()
        {
            if (throwButtonName != null)
            {
                if (Input.GetButtonDown(throwButtonName) && Time.timeScale > 0 && canBeThrown && myTransform.root.CompareTag(GameManager_References._playerTag))
                {
                    CarryOutThrowActions();
                }
            }
        }

        void CarryOutThrowActions()
        {
            throwDirection = myTransform.parent.forward;
            myTransform.parent = null;
            itemMaster.CallEventObjectThrow();
            HurlItem();
            if (gunHands != null)
            {
                gunHands.SetActive(false);
            }
            if (gunAnimator != null)
            {
                gunAnimator.applyRootMotion = true;
            }
        }

        void HurlItem()
        {
            myRigidbody.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        }
	}
}

