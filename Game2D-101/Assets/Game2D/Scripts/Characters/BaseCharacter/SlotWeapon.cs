using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotWeapon : MonoBehaviour
{
    [System.Serializable]
    public struct Slot
    {
        public HandType handType;
        public Transform attachmentJoint;
        public GameObject attachmentItem;
    }

    public Slot[] attachments;
}

public enum HandType
{
    LeftHand,
    RightHand
}
