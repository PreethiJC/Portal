//using System.Collections;
//using System.Collections.Generic;
//using JetBrains.Annotations;
//using UnityEngine;
//
//namespace UnityEngine.XR.iOS
//{
//    public class PortalController : MonoBehaviour
//    {
//
//        public Material[] materials;
//
//        public MeshRenderer meshRenderer;
//
//        public UnityARVideo vid;
//
//        private bool isInside = false;
//
//        private bool isOutside = true;
//        // Use this for initialization
//        void Start () {
//		    OutsidePortal();
//        }
//
//        private void OnTriggerStay(Collider other)
//        {
//            Vector3 playerPos = Camera.main.transform.position + Camera.main.transform.forward
//                                * (Camera.main.nearClipPlane * 4);
//            if (transform.InverseTransformPoint(playerPos).z <= 0)
//            {
//                if (isOutside)
//                {
//                    isOutside = false;
//                    isInside = true;
//                    InsidePortal();
//                }
//                else if (isInside)
//                {
//                    isInside = false;
//                    isOutside = true;
//                    OutsidePortal();
//                }
//            }
//        }
//
//        void OutsidePortal()
//        {
//            StartCoroutine(DelayChangedMat(3));
//        }
//        
//        void InsidePortal()
//        {
//            StartCoroutine(DelayChangedMat(6));
//        }
//
//        IEnumerator DelayChangedMat(int stencilNum)
//        {
//            vid.shouldRender = false;
//            yield return new WaitForEndOfFrame();
//            meshRenderer.enabled = false;
//            foreach (Material mat in materials)
//            {
//                mat.SetInt("_Stencil", stencilNum);
//            }
//            yield return new WaitForEndOfFrame();
//            meshRenderer.enabled = true;
//        }
//    }
//}
//
