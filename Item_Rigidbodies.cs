using UnityEngine;
using System.Collections;

namespace GameManager
{
	public class Item_Rigidbodies : MonoBehaviour
    {
        private Item_Master itemMaster;
        public Rigidbody[] rigidBodies;
        

		void OnEnable()
		{
            SetInitialReferences();
            CheckIfStartsInInventory();
            itemMaster.EventObjectThrow += SetIsKinematicToFalse;
            itemMaster.EventObjectPickup += SetIsKinematicToTrue;
		}
		
		void OnDisable()
		{
            itemMaster.EventObjectThrow -= SetIsKinematicToFalse;
            itemMaster.EventObjectPickup -= SetIsKinematicToTrue;
		}

		void SetInitialReferences()
		{
            itemMaster = GetComponent<Item_Master>();
		}

        void CheckIfStartsInInventory()
        {
            if (transform.root.CompareTag("Player"))
            {
                SetIsKinematicToTrue();
            }
        }

        void SetIsKinematicToTrue()
        {
            if (rigidBodies.Length > 0)
            {
                foreach (Rigidbody rBody in rigidBodies)
                {
                    rBody.isKinematic = true;
                }
            }
        }

        void SetIsKinematicToFalse()
        {
            if (rigidBodies.Length > 0)
            {
                foreach (Rigidbody rBody in rigidBodies)
                {
                    rBody.isKinematic = false;
                }
            }
        }
	}
}

