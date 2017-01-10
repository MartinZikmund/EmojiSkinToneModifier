using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiSkinToneModifier.Portable
{
    public static class EmojiSkinToneExtensions
    {
        /// <summary>
        /// Returns the Emoji Skin Tone modifier character
        /// </summary>
        /// <param name="skinTone">Skin tone</param>
        /// <returns>Modifier character</returns>
        public static string ToModifierCharacter(this EmojiSkinTone skinTone)
        {
            switch (skinTone)
            {                
                case EmojiSkinTone.Type12:
                    return "🏻";
                case EmojiSkinTone.Type3:
                    return "🏼";
                case EmojiSkinTone.Type4:
                    return "🏽";
                case EmojiSkinTone.Type5:
                    return "🏾";
                case EmojiSkinTone.Type6:
                    return "🏿";
                default:
                    return string.Empty; //generic yellow color
            }
        }
    }
}
