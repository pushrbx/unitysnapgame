using Autofac;
using SnapGameLogic.Abstractions;
using SnapGameLogic.Cards;
using SnapGameLogic.Internal;

namespace SnapGameLogic
{
    /// <summary>
    /// Represents the dependency injection container for the snap card game.
    /// </summary>
    /// <remarks>
    /// http://blog.ploeh.dk/2011/07/28/CompositionRoot/
    /// </remarks>
    public static class SnapGameContext
    {
        private static IContainer _gameContextContainer;

        public static IGameController GetGameController(IUnitySnapBehavior viewModel)
        {
            Check.NotNull(viewModel, "viewModel");

            if (_gameContextContainer == null)
            {
                _gameContextContainer = CreateGameContextContainer(viewModel);
            }

            using (var scope = _gameContextContainer.BeginLifetimeScope())
                return scope.Resolve<IGameController>();
        }

        private static IContainer CreateGameContextContainer(IUnitySnapBehavior viewModel)
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(viewModel).As<IUnitySnapBehavior>();
            builder.RegisterType<FrenchCardCollectionFactory>().As<ICardCollectionFactory>();
            builder.RegisterType<DefaultCardDealerLogic>().As<ICardDealerLogic>();
            builder.RegisterType<DefaultSnapGameType>().As<ISlapjackGame>();
            builder.RegisterType<DefaultGameController>().As<IGameController>();
            builder.RegisterType<DefaultGameTurnManager>().As<IGameTurnManager>();
            builder.RegisterType<DefaultPlayerTurnManager>().As<IPlayerTurnManager>();
            builder.RegisterType<FrenchCardObjectFactory>().As<ICardObjectFactory>();
            builder.RegisterType<DefaultCardSpriteFactory>().As<ICardSpriteFactory>();
            builder.RegisterType<DefaultCardTypeDescriptor>().As<ICardTypeDescriptor>();
            builder.RegisterType<DefaultCardTypeTextureResolver>().As<ICardTypeTextureResolver>();

            return builder.Build();
        }
    }
}
