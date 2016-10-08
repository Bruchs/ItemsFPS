using UnityEngine;
using System.Collections;

namespace GameManager
{
	public class Item_Ammo : MonoBehaviour
    {
        private Item_Master itemMaster;
        private GameObject playerGo;
        public string ammoName;
        public int quantity;
        public bool isTriggerPickup;

		void OnEnable()
		{
            SetInitialReferences();
            itemMaster.EventObjectPickup += TakeAmmo;
		}
		
		void OnDisable()
		{
            itemMaster.EventObjectPickup -= TakeAmmo;
		}

        void Start()
        {
            SetInitialReferences();
        }

        //void OnTriggerEnter(Collider coll)
        //{
        //    if (coll.CompareTag("Player") && isTriggerPickup)
        //    {
        //        TakeAmmo();
        //    }
        //}

        void SetInitialReferences()
		{
            itemMaster = GetComponent<Item_Master>();
            playerGo = GameManager_References._player;

            if (isTriggerPickup)
            {
                if (GetComponent<Collider>() != null)
                {
                    GetComponent<Collider>().isTrigger = true;
                }

                if (GetComponent<Rigidbody>() != null)
                {
                    GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }

        void TakeAmmo()
        {
            playerGo.GetComponent<Player_Master>().CallEventPickedUpAmmo(ammoName, quantity);
            Destroy(gameObject);
        }
	}
}

