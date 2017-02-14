using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SnapGameLogic;
using SnapGameLogic.Abstractions;
using SnapGameLogic.Cards;

namespace SnapGameLogicTests
{
    [TestClass]
    public class DefaultGameControllerTest
    {
        private static IGameController _testTarget;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            IUnitySnapBehavior snapBehavior;
            IGameTurnManager gameTurnManager;
            ISlapjackGame game;
            ICardDealerLogic cardDealerLogic;
            SetupMocks(out snapBehavior, out gameTurnManager, out game, out cardDealerLogic);
            _testTarget = new DefaultGameController(snapBehavior, gameTurnManager, game, cardDealerLogic);
        }

        private static ICardGamePlayer SetupNormalPlayerMock()
        {
            var player = Substitute.For<ICardGamePlayer>();
            player.IsComputerPlayer.Returns(false);
            player.CardCount.Returns(3);

            ICardCollection faceDownPile = SetupFaceDownPileMock();
            ICardCollection faceUpPile = SetupFaceUpPileMock();

            player.FaceDownPile.Returns(faceDownPile);
            player.FaceUpPile.Returns(faceUpPile);

            return player;
        }

        private static ICardCollection SetupFaceDownPileMock()
        {
            var faceDownPile = Substitute.For<ICardCollection>();
            faceDownPile.Count.Returns(1);

            ICardObject card = SetupClub2CardMock();

            faceDownPile.PopNextCard().Returns(card);

            return faceDownPile;
        }

        private static ICardCollection SetupFaceUpPileMock()
        {
            var faceUpPile = Substitute.For<ICardCollection>();
            faceUpPile.Count.Returns(1);

            ICardObject card = SetupHearts3CardMock();

            faceUpPile.PopNextCard().Returns(card);

            return faceUpPile;
        }

        private static ICardObject SetupClub2CardMock()
        {
            var card = Substitute.For<ICardObject>();
            ICardType cardType = SetupClub2CardTypeMock();

            card.Type.Returns(cardType);
            return card;
        }

        private static ICardObject SetupHearts3CardMock()
        {
            var card = Substitute.For<ICardObject>();
            ICardType cardType = SetupHearts3CardTypeMock();
            card.Type.Returns(cardType);

            return card;
        }

        private static ICardType SetupClub2CardTypeMock()
        {
            var cardType = Substitute.For<ICardType>();
            cardType.Value.Returns(2);
            cardType.Name.Returns("Club_2");

            return cardType;
        }

        private static ICardType SetupHearts3CardTypeMock()
        {
            var cardType = Substitute.For<ICardType>();
            cardType.Value.Returns(3);
            cardType.Name.Returns("Hearts_3");

            return cardType;
        }

        private static IPlayerTurn SetupPlayerTurnMock()
        {
            var playerTurn = Substitute.For<IPlayerTurn>();

            var player = SetupNormalPlayerMock();
            playerTurn.AssociatedPlayer.Returns(player);

            return playerTurn;
        }

        private static IPlayerTurnManager SetupPlayerTurnManagerMock()
        {
            var playerTurnManager = Substitute.For<IPlayerTurnManager>();
            playerTurnManager.ActivateNextPlayerTurn().Returns(true);
            playerTurnManager.ResetPlayerTurns().Returns(true);
            var playerTurn = SetupPlayerTurnMock();
            playerTurnManager.PlayerTurns.Returns(new List<IPlayerTurn>() {playerTurn});

            return playerTurnManager;
        }

        private static IGameTurnManager SetupTurnManagerMock()
        {
            var gameTurnManager = Substitute.For<IGameTurnManager>();
            var playerTurnManager = SetupPlayerTurnManagerMock();
            gameTurnManager.PlayerTurnManager.Returns(playerTurnManager);
            gameTurnManager.ActivateNextTurn().Returns(true);

            return gameTurnManager;
        }

        private static void SetupMocks(out IUnitySnapBehavior snapBehavior, out IGameTurnManager gameTurnManager,
            out ISlapjackGame game, out ICardDealerLogic cardDealerLogic)
        {
            snapBehavior = Substitute.For<IUnitySnapBehavior>();
            snapBehavior.TurnUpCard(Arg.Any<ICardObject>()).Returns(true);

            gameTurnManager = SetupTurnManagerMock();
            var player = gameTurnManager.PlayerTurnManager.PlayerTurns.First().AssociatedPlayer;

            game = Substitute.For<ISlapjackGame>();
            game.Players.Returns(new List<ICardGamePlayer>() {player});

            cardDealerLogic = Substitute.For<ICardDealerLogic>();
            cardDealerLogic.DealCards(Arg.Any<int>()).Returns(new List<ICardCollection>());
        }

        [TestMethod]
        public void TestIfOnUserClickedOnHisDeckThrowsExceptionOnArgumentNull()
        {
            var exceptionThrown = false;
            try
            {
                _testTarget.OnUserClickedOnHisDeck(null);
            }
            catch (ArgumentNullException)
            {
                exceptionThrown = true;
            }
            
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void TestIfOnUserClickedOnHisDeckReturnsTrue1()
        {
            var player = _testTarget.CurrentGame.Players.FirstOrDefault();
            Assert.IsNotNull(player);
            var result = _testTarget.OnUserClickedOnHisDeck(player);
            Assert.IsTrue(result);
        }
    }
}
