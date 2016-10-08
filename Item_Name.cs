using UnityEngine;
using System.Collections;

namespace GameManager
{
	public class Item_Name : MonoBehaviour {

        public string itemName;

		void OnEnable()
		{
            SetItemName();
		}

        void SetItemName()
        {
            transform.name = itemName;
        }
	}
}

