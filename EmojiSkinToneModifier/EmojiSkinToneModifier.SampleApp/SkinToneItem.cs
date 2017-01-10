using EmojiSkinToneModifier.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiSkinToneModifier.SampleApp
{
    public class SkinToneItem
    {
        public SkinToneItem( EmojiSkinTone skinTone )
        {
            SkinTone = skinTone;
            Glyph = skinTone.ToModifierCharacter();
        }

        public EmojiSkinTone SkinTone { get; }
        public string Glyph { get; }
    }
}
