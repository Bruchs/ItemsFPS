using UnityEngine;
using System.Collections;

namespace GameManager
{
    public class Item_Tag : MonoBehaviour
    {
        private string itemTag;

        void OnEnable()
        {
            SetTag();
        }

        void SetTag()
        {
            itemTag = "Item";
            transform.tag = itemTag;
        } 
	}
}

