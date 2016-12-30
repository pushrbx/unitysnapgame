using UnityEngine;

namespace SnapGameLogic.Abstractions
{
    public interface IGameController
    {
        ISlapjackGame CurrentGame { get; }

        IUnitySnapBehavior ViewModel { get; }

        bool StartNewGame();

        bool AbortCurrentGame();

        bool OnUserClickedOnHisDeck(ICardGamePlayer player);

        bool FlushRenderQueue(IUnitySnapBehavior targetViewModel);
    }
}
