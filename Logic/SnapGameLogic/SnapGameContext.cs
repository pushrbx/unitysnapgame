using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            return _gameContextContainer.Resolve<IGameController>();
        }

        private static IContainer CreateGameContextContainer(IUnitySnapBehavior viewModel)
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(viewModel);
            builder.RegisterType<FrenchCardCollectionFactory>().As<ICardCollectionFactory>();
            builder.RegisterType<DefaultGameController>().As<IGameController>();
            builder.RegisterType<DefaultSlapGameType>().As<ISlapjackGame>();

            return builder.Build();
        }
    }
}
