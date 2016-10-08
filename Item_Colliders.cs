using UnityEngine;
using System.Collections;

namespace GameManager
{
	public class Item_Colliders : MonoBehaviour
    {
        private Item_Master itemMaster;
        public Collider[] itemColliders;
        public PhysicMaterial myPhysicMaterial;

		void OnEnable()
		{
            SetInitialReferences();
            CheckIfStartsInInventory();
            itemMaster.EventObjectPickup += DisableCollider;
            itemMaster.EventObjectThrow += EnableCollider;
		}
		
		void OnDisable()
		{
            itemMaster.EventObjectPickup -= DisableCollider;
            itemMaster.EventObjectThrow -= EnableCollider;
		}
		
		void SetInitialReferences()
		{
            itemMaster = GetComponent<Item_Master>();
		}

        void CheckIfStartsInInventory()
        {
            if (transform.root.CompareTag("Player"))
            {
                DisableCollider();
            }
        }

        void EnableCollider()
        {
            if (itemColliders.Length > 0)
            {
                foreach(Collider iCollider in itemColliders)
                {
                    iCollider.enabled = true;

                    if (myPhysicMaterial != null)
                    {
                        iCollider.material = myPhysicMaterial;
                    }
                }
            }
        }

        void DisableCollider()
        {
            if (itemColliders.Length > 0)
            {
                foreach (Collider iCollider in itemColliders)
                {
                    iCollider.enabled = false;
                }
            }
        }
	}
}

