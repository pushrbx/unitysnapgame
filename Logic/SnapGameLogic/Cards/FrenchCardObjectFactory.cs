using SnapGameLogic.Abstractions;

namespace SnapGameLogic.Cards
{
    public class FrenchCardObjectFactory : ICardObjectFactory
    {
        private readonly ICardSpriteFactory m_spriteFactory;

        public FrenchCardObjectFactory(ICardSpriteFactory spriteFactory)
        {
            m_spriteFactory = spriteFactory;
        }

        public ICardObject CreateCardObject(ICardType type)
        {
            var sprite = m_spriteFactory.CreateSpriteFor(type);
            return new FrenchCardObject(type as FrenchCardType, sprite);
        }
    }
}
