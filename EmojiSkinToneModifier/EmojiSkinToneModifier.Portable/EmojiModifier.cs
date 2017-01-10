using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmojiSkinToneModifier.Portable
{
    public static class EmojiModifier
    {
        private static Lazy<string[]> _modifierBases = new Lazy<string[]>(LoadModifierBases);

        /// <summary>
        /// Loads the modifier bases embedded resource file
        /// </summary>
        /// <returns>Array of all Emoji modifier bases</returns>
        private static string[] LoadModifierBases()
        {
            var assembly = typeof(EmojiModifier).GetTypeInfo().Assembly;

            List<string> modifierBases = new List<string>();
            using (Stream stream = assembly.GetManifestResourceStream(assembly.GetManifestResourceNames().First()))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        modifierBases.Add(line);
                    }
                }
            }

            return modifierBases.ToArray();
        }

        /// <summary>
        /// Changes the Emoji skin tone. In case the provided emoji is not an Emoji Modifier Base, it does nothing.
        /// </summary>
        /// <param name="emoji">Emoji</param>
        /// <param name="skinTone">Requested skin tone</param>
        /// <returns>Emoji with requested skin tone</returns>
        public static string ChangeSkinTone(this string emoji, EmojiSkinTone skinTone)
            => _modifierBases.Value.Contains(emoji) ? emoji + skinTone.ToModifierCharacter() : emoji;
    }
}
