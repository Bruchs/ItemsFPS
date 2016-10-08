using UnityEngine;
using System.Collections;

namespace GameManager
{
	public class Item_Sounds : MonoBehaviour
    {
        private Item_Master itemMaster;
        public float defaultVolume;
        public AudioClip throwSound;
        public AudioClip pickupSound;

		void OnEnable()
		{
            SetInitialReferences();
            itemMaster.EventObjectThrow += PlayThrowSound;
            itemMaster.EventObjectPickup += PlayPickupSound;
		}
		
		void OnDisable()
		{
            itemMaster.EventObjectThrow -= PlayThrowSound;
            itemMaster.EventObjectPickup -= PlayPickupSound;
		}
		
		void SetInitialReferences()
		{
            itemMaster = GetComponent<Item_Master>();
		}

        void PlayPickupSound()
        {
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position, defaultVolume);
            }
        }

        void PlayThrowSound()
        {
            if (throwSound != null)
            {
                AudioSource.PlayClipAtPoint(throwSound, transform.position, defaultVolume);
            }
        }


	}
}

