using SnapGameLogic.Abstractions;
using SnapGameLogic.Internal;
using UnityEngine;

namespace SnapGameLogic
{
    public class DefaultCardSpriteFactory : ICardSpriteFactory
    {
        private readonly ICardTypeTextureResolver m_textureResolver;

        public DefaultCardSpriteFactory(ICardTypeTextureResolver textureResolver)
        {
            Check.NotNull(textureResolver, "textureResolver");
            m_textureResolver = textureResolver;
        }

        public Sprite CreateSpriteFor(ICardType cardType)
        {
            var spriteImmutable = m_textureResolver.Resolve(cardType);
            var spriteMutable = Sprite.Create(spriteImmutable.texture, spriteImmutable.rect, spriteImmutable.pivot);

            return spriteMutable;
        }
    }
}
