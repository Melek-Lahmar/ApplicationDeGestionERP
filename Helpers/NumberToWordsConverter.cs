namespace ApplicationDeGestionERP.Helpers
{
    public static class NumberToWordsConverter
    {
        private static readonly string[] UnitsMap = { "zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf" };
        private static readonly string[] TensMap = { "zéro", "dix", "vingt", "trente", "quarante", "cinquante", "soixante", "soixante-dix", "quatre-vingt", "quatre-vingt-dix" };

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zéro";

            if (number < 0)
                return "moins " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million";
                if ((number / 1000000) > 1)
                    words += "s";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                if (!string.IsNullOrEmpty(words))
                    words += " ";

                if ((number / 1000) == 1)
                    words += "mille";
                else
                    words += NumberToWords(number / 1000) + " mille";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                if (!string.IsNullOrEmpty(words))
                    words += " ";

                if ((number / 100) == 1)
                    words += "cent";
                else
                    words += NumberToWords(number / 100) + " cent";
                number %= 100;
            }

            if (number > 0)
            {
                if (!string.IsNullOrEmpty(words))
                    words += " ";

                if (number < 20)
                    words += UnitsMap[number];
                else
                {
                    int tens = number / 10;
                    int units = number % 10;

                    if (tens == 7 || tens == 9)
                    {
                        tens--;
                        units += 10;
                    }

                    words += TensMap[tens];

                    if (units > 0)
                    {
                        if (units == 1 && (tens == 1 || tens == 7 || tens == 9))
                            words += " et un";
                        else
                            words += "-" + UnitsMap[units];
                    }
                }
            }

            return words;
        }
    }
}
