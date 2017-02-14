using System;
using System.Collections.Generic;
using System.Linq;
using SnapGameLogic.Abstractions;
using SnapGameLogic.Internal;
using UnityEngine;

namespace SnapGameLogic
{
    public class DefaultGameController : IGameController
    {
        private readonly IGameTurnManager m_turnManager;
        private readonly Queue<GameObject> m_renderQueue;
        private readonly Dictionary<ICardGamePlayer, GameObjectTransformModel> m_playerDeckLocations;

        public DefaultGameController(IUnitySnapBehavior viewModel,
            IGameTurnManager turnManager, ISlapjackGame game)
        {
            Check.NotNull(viewModel, "viewModel");
            Check.NotNull(turnManager, "turnManager");
            Check.NotNull(game, "game");

            m_turnManager = turnManager;
            ViewModel = viewModel;
            CurrentGame = game;

            m_renderQueue = new Queue<GameObject>();
            m_playerDeckLocations = new Dictionary<ICardGamePlayer, GameObjectTransformModel>();
        }

        public ISlapjackGame CurrentGame { get; private set; }

        public IUnitySnapBehavior ViewModel { get; private set; }

        public bool StartNewGame()
        {
            try
            {
                CalculateLocationOfPlayersDecks();
                DisplayDealDecksForPlayers();
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }

        private void CalculateLocationOfPlayersDecks()
        {
            // sily implementation for now
            CalculateLocationOfPlayerOnesDeck();

            CurrentGame.Players.Where(x => x.IsComputerPlayer).Each(CalculateLocationOfPlayerDeck);
        }

        private void CalculateLocationOfPlayerOnesDeck()
        {
            var playerOne = CurrentGame.Players.FirstOrDefault(x => x.IsComputerPlayer == false && x.Name == "Player 1");

            CalculateLocationOfPlayerDeck(playerOne, 1);
        }

        private void CalculateLocationOfPlayerDeck(ICardGamePlayer player, int playerNumber)
        {
            var objPath = string.Format("RootCanvas/P{0}CardBack", playerNumber);
            var playerPosition = ViewModel.GetPositionOfGameObjectByName(objPath);
            var playerRotation = ViewModel.GetRotationOfGameObjectByName(objPath);
            var playerScale = ViewModel.GetScaleOfGameObjectByName(objPath);

            AddPlayerDeckLocation(player, playerPosition, playerRotation, playerScale);
        }

        private void DisplayDealDecksForPlayers()
        {
            // todo
            // for now just display the player's decks on screen
            //foreach (var player in CurrentGame.Players)
            //{
            //    foreach (var card in player.FaceDownPile)
            //    {
                     
            //    }
            //}
            // we do this later, for now we work with static decks which are not changing on screeen.
        }

        private void AddGameObjectToRenderQueue(Sprite sprite, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            var go = UnityEngine.Object.Instantiate(new GameObject());
            var spriteRenderer = go.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            go.transform.position = position;
            go.transform.rotation = rotation;
            go.transform.localScale = scale;

            m_renderQueue.Enqueue(go);
        }

        private void AddPlayerDeckLocation(ICardGamePlayer player, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            var model = new GameObjectTransformModel
            {
                Position = position,
                Rotation = rotation,
                Scale = scale
            };

            m_playerDeckLocations.Add(player, model);
        }

        public bool AbortCurrentGame()
        {
            throw new NotImplementedException();
        }

        public bool OnUserClickedOnHisDeck(ICardGamePlayer player)
        {
            Check.NotNull(player, "player");
            var topCardInFaceDownPile = player.FaceDownPile.PopNextCard();
            player.FaceUpPile.Add(topCardInFaceDownPile);

            // return ViewModel.TurnUpCard(topCardInFaceDownPile);
            return TurnUpCard(topCardInFaceDownPile, m_playerDeckLocations[player]);
        }

        private bool TurnUpCard(ICardObject card, GameObjectTransformModel deckTransformModel)
        {
            AddGameObjectToRenderQueue(card.CardGraphic, deckTransformModel.Position + new Vector3(25, 0), deckTransformModel.Rotation, deckTransformModel.Scale);

            return true;
        }

        public bool FlushRenderQueue(IUnitySnapBehavior targetViewModel)
        {
            while (m_renderQueue.Count > 0)
                targetViewModel.AddGameObjectToScene(m_renderQueue.Dequeue());

            return true;
        }

        private class GameObjectTransformModel
        {
            public Vector3 Position { get; set; }

            public Quaternion Rotation { get; set; }

            public Vector3 Scale { get; set; }
        }
    }
}
