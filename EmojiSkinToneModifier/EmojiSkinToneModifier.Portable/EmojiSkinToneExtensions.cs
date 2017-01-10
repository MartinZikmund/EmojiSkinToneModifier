using System;
using System.Collections.Generic;
using System.Globalization;
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
            string hexadecimalCode;
            switch (skinTone)
            {
                case EmojiSkinTone.Type12:
                    hexadecimalCode = "1F3FB";
                    break;
                case EmojiSkinTone.Type3:
                    hexadecimalCode = "1F3FC";
                    break;
                case EmojiSkinTone.Type4:
                    hexadecimalCode = "1F3FD";
                    break;
                case EmojiSkinTone.Type5:
                    hexadecimalCode = "1F3FE";
                    break;
                case EmojiSkinTone.Type6:
                    hexadecimalCode = "1F3FF";
                    break;
                default:
                    return string.Empty; //generic yellow color, no modifier
            }
            var code = int.Parse(hexadecimalCode, NumberStyles.HexNumber);
            return char.ConvertFromUtf32(code);
        }
    }
}
