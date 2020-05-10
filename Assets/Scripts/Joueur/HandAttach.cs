using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class HandAttach : MonoBehaviour
    {
        private Hand hand;

        // Start is called before the first frame update
        void Start()
        {
            hand = GetComponent<Hand>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetAttachObj(GameObject GObj)
        {
            hand.AttachObject(GObj, GrabTypes.Scripted, Hand.AttachmentFlags.ParentToHand);
        }
    }
}
