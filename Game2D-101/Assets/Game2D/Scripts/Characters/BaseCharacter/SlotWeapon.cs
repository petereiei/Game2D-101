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

    private Weapon weapon;

    public void Init(Character character)
    {
        weapon = gameObject.GetComponentInChildren<Weapon>();
        weapon.Init(character);
    }

    // set open box collider hit box in animation attacking
    private void OpenHitBox()
    {
        weapon.OpenHitBox();
    }
    // set close box collider hit box in animation attacking
    private void CloseHitBox()
    {
        weapon.CloseHitBox();
    }
}

public enum HandType
{
    LeftHand,
    RightHand
}
