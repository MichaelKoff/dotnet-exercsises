using System;
using System.Globalization;
using System.Text;

#pragma warning disable S2368

namespace MorseCodeTranslator
{
    public static class Translator
    {
        public static string TranslateToMorse(string message)
        {
            // #1. Implement the method using StringBuilder, and MorseCodes.CodeTable array.
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            StringBuilder sb = new StringBuilder();

            WriteMorse(MorseCodes.CodeTable, message, sb);

            return sb.ToString();
        }

        public static string TranslateToText(string morseMessage)
        {
            // #2. Implement the method using StringBuilder, and MorseCodes.CodeTable array.
            if (morseMessage == null)
            {
                throw new ArgumentNullException(nameof(morseMessage));
            }

            StringBuilder sb = new StringBuilder();

            WriteText(MorseCodes.CodeTable, morseMessage, sb);

            return sb.ToString();
        }

        public static void WriteMorse(char[][] codeTable, string message, StringBuilder morseMessageBuilder, char dot = '.', char dash = '-', char separator = ' ')
        {
            // #3. Implement the method.
            if (codeTable == null)
            {
                throw new ArgumentNullException(nameof(codeTable));
            }

            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (morseMessageBuilder == null)
            {
                throw new ArgumentNullException(nameof(morseMessageBuilder));
            }

            for (int i = 0; i < message.Length; i++)
            {
                if (char.IsLetter(message, i))
                {
                    for (int j = 0; j < codeTable.Length; j++)
                    {
                        if (char.ToUpper(message[i], CultureInfo.InvariantCulture) == codeTable[j][0])
                        {
                            morseMessageBuilder.Append(codeTable[j][1..]);
                            morseMessageBuilder.Append(' ');
                            break;
                        }
                    }
                }
            }

            if (morseMessageBuilder.Length > 0)
            {
                morseMessageBuilder.Remove(morseMessageBuilder.Length - 1, 1);
            }

            if (dot != '.')
            {
                morseMessageBuilder.Replace('.', dot);
            }

            if (dash != '-')
            {
                morseMessageBuilder.Replace('-', dash);
            }

            if (separator != ' ')
            {
                morseMessageBuilder.Replace(' ', separator);
            }
        }

        public static void WriteText(char[][] codeTable, string morseMessage, StringBuilder messageBuilder, char dot = '.', char dash = '-', char separator = ' ')
        {
            // #4. Implement the method.
            if (codeTable == null)
            {
                throw new ArgumentNullException(nameof(codeTable));
            }

            if (morseMessage == null)
            {
                throw new ArgumentNullException(nameof(morseMessage));
            }

            if (messageBuilder == null)
            {
                throw new ArgumentNullException(nameof(messageBuilder));
            }

            if (separator != ' ')
            {
                morseMessage = morseMessage.Replace(separator, ' ');
            }

            if (dot != '.')
            {
                morseMessage = morseMessage.Replace(dot, '.');
            }

            if (dash != '-')
            {
                morseMessage = morseMessage.Replace(dash, '-');
            }

            string[] split = morseMessage.Split(' ');

            for (int i = 0; i < split.Length; i++)
            {
                for (int j = 0; j < codeTable.Length; j++)
                {
                    if (split[i].Equals(new string(codeTable[j][1..]), StringComparison.InvariantCulture))
                    {
                        messageBuilder.Append(codeTable[j][0]);
                        break;
                    }
                }
            }
        }
    }
}
