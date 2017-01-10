using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmojiSkinToneModifier.EmojiDataParser
{
    class Program
    {
        private const char CommentCharacter = '#';
        private const char NewLineCharacter = '\n';

        private const string RangeSplitter = "..";
        private const string EmojiModifierBaseDefinition = "; Emoji_Modifier_Base";

        static void Main(string[] args)
        {
            HttpClient emojiDataDownloader = new HttpClient();
            var emojiData = emojiDataDownloader.GetStringAsync("http://www.unicode.org/Public/emoji/latest/emoji-data.txt").Result;
            var emojiBases = GetModifierBases(emojiData);
            File.WriteAllLines("emojimodifierbases.txt", emojiBases);
        }

        private static string[] GetModifierBases(string emojiData)
        {
            List<string> modifierBases = new List<string>();
            var lines = emojiData.Split(NewLineCharacter);
            foreach (var line in lines)
            {
                if (!line.StartsWith(CommentCharacter.ToString()) && //ignore comment lines
                     line.Contains(EmojiModifierBaseDefinition)
                    )
                {
                    //parse line
                    var firstColumn = line.Split(';').First().Trim();
                    if (firstColumn.Contains(RangeSplitter))
                    {
                        var indexOfRangeSplitter = firstColumn.IndexOf(RangeSplitter);
                        var rangeStartHexadecimal = firstColumn.Substring(0, indexOfRangeSplitter);
                        var rangeEndHexadecimal = firstColumn.Substring(indexOfRangeSplitter + RangeSplitter.Length);
                        //range, enumerate
                        var rangeStart = int.Parse(rangeStartHexadecimal, NumberStyles.HexNumber);
                        var rangeEnd = int.Parse(rangeEndHexadecimal, NumberStyles.HexNumber);
                        for (var currentCode = rangeStart; currentCode <= rangeEnd; currentCode++)
                        {
                            //output emoji character
                            modifierBases.Add(char.ConvertFromUtf32(currentCode));
                        }
                    }
                    else
                    {
                        //single emoji
                        var code = int.Parse(firstColumn, NumberStyles.HexNumber);
                        modifierBases.Add(char.ConvertFromUtf32(code));
                    }
                }
            }
            return modifierBases.ToArray();
        }
    }
}
