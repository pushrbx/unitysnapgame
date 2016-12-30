using System;
using SnapGameLogic.Abstractions;
using UnityEngine;

namespace SnapGameLogic
{
    public class SnapGameViewModel : MonoBehaviour, IUnitySnapBehavior
    {
        // the current game's controller object
        private IGameController m_gameController;

        public bool TurnUpCard(ICardObject card)
        {
            throw new NotImplementedException();
        }

        public Vector3 GetPositionOfGameObjectByName(string objName)
        {
            var go = FindGameObject(objName);
            ThrowIfGameObjectNull(go, objName);
            return go.transform.localPosition;
        }

        public Vector3 GetScaleOfGameObjectByName(string objName)
        {
            var go = FindGameObject(objName);
            ThrowIfGameObjectNull(go, objName);
            return go.transform.localScale;
        }

        public Quaternion GetRotationOfGameObjectByName(string objName)
        {
            var go = FindGameObject(objName);
            ThrowIfGameObjectNull(go, objName);
            return go.transform.localRotation;
        }

        public void Start()
        {
            m_gameController = SnapGameContext.GetGameController(this);
            m_gameController.StartNewGame();
        }

        private GameObject FindGameObject(string objName)
        {
            // https://docs.unity3d.com/ScriptReference/GameObject.Find.html
            return GameObject.Find(objName);
        }

        private static void ThrowIfGameObjectNull(GameObject go, string objName)
        {
            if (go == null) // todo: custom exception class
                throw new Exception(string.Format("Couldn't find gameobject in the hiearchy with name/path '{0}'", objName));
        }
    }
}
