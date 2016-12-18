using UnityEngine;

namespace SnapGameLogic.Abstractions
{
    public interface IGameController
    {
        ISlapjackGame CurrentGame { get; }

        MonoBehaviour ViewModel { get; }

        bool StartNewGame();

        bool AbortCurrentGame();
    }
}
