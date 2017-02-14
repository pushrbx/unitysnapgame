using System;
using System.Linq;
using SnapGameLogic.Abstractions;
using UnityEngine;

namespace SnapGameLogic
{
    [RequireComponent(typeof(Canvas))]
    public class SnapGameViewModel : MonoBehaviour, IUnitySnapBehavior
    {
        // the current game's controller object
        private IGameController m_gameController;
        private SpriteRenderer m_renderer;

        [SerializeField] private Canvas m_rootCanvas;

        public SpriteRenderer GameRenderer
        {
            get { return m_renderer ?? (m_renderer = GetComponent<SpriteRenderer>()); }
        }

        public void AddGameObjectToScene(GameObject object2Spawn)
        {
            ThrowIfGameObjectNull(gameObject, "object2Spawn");
            Instantiate(object2Spawn);
        }

        public bool TurnUpCard(ICardObject card)
        {
            return false;
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

        void Awake()
        {
            m_gameController = SnapGameContext.GetGameController(this);
            m_gameController.StartNewGame();
        }

        public void Update()
        {
            m_gameController.FlushRenderQueue(this);
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

        public void OnPlayerOneCardHasBeenClicked()
        {
            m_gameController.OnUserClickedOnHisDeck(m_gameController.CurrentGame.Players.FirstOrDefault());
        }
    }
}
