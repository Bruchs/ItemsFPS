using UnityEngine;
using System.Collections;

namespace GameManager
{
	public class Item_Pickup : MonoBehaviour
    {
        private Item_Master itemMaster;
        public GameObject gunHands;
        public Animator gunAnimator;

		void OnEnable()
		{
            SetInitialReferences();
            itemMaster.EventPickupAction += CarryOutPickupActions;
		}
		
		void OnDisable()
		{
            itemMaster.EventPickupAction -= CarryOutPickupActions;
		}

		void SetInitialReferences()
		{
            itemMaster = GetComponent<Item_Master>();
		}

        void CarryOutPickupActions(Transform transformParent)
        {
            transform.SetParent(transformParent);
            itemMaster.CallEventObjectPickup();
            if (transform.gameObject.layer != 0)
            {
                transform.gameObject.SetActive(false);
            } 
            if (gunHands != null)
            {
                gunHands.SetActive(true);
            }
            if (gunAnimator != null)
            {
                if (!gunAnimator.isActiveAndEnabled)
                {
                    gunAnimator.enabled = true;
                }
                gunAnimator.applyRootMotion = false;
            }
        }
	}
}

