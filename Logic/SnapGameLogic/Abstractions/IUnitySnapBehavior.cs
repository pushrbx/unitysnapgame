using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace SnapGameLogic.Abstractions
{
    public interface IUnitySnapBehavior
    {
        bool TurnUpCard(ICardObject card);

        /// <summary>
        /// Retrieves the local position of the game object by name. The position is relative to the parent game object.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Vector3 GetPositionOfGameObjectByName(string name);

        /// <summary>
        /// Retrieves the local scale of the game object by name. The scale is relative to the parent game object.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Vector3 GetScaleOfGameObjectByName(string name);

        /// <summary>
        /// Retrieves the local rotation of the game object by name. The rotation is relative to the parent game object.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Quaternion GetRotationOfGameObjectByName(string name);

        SpriteRenderer GameRenderer { get; }

        void AddGameObjectToScene(GameObject object2Spawn);
    }
}
