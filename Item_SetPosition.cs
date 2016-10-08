using UnityEngine;
using System.Collections;

namespace GameManager
{
	public class Item_SetPosition : MonoBehaviour
    {
        private Item_Master itemMaster;
        public Vector3 itemLocalPosition;
        public Quaternion itemLocalRotation;

		void OnEnable()
		{
            SetInitialReferences();
            SetPositionOnPlayer();
            itemMaster.EventObjectPickup += SetPositionOnPlayer;
		}
		
		void OnDisable()
		{
            itemMaster.EventObjectPickup -= SetPositionOnPlayer;
		}
		
		void SetInitialReferences()
		{
            itemMaster = GetComponent<Item_Master>();
		}

        void SetPositionOnPlayer()
        {
            if (transform.root.CompareTag("Player"))
            {
                transform.localPosition = itemLocalPosition;
                transform.rotation = itemLocalRotation;
            }
        }
	}
}

