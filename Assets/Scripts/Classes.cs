using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;


namespace Numeric
{
    public class Words
    {
        public bool flag;
        public string word;
    }

    public class WordsArray
    {
        private const int RESULT_AMOUNT = 7;

        private string[,] words1 = null;
        private string[,] words2 = null;
        private string[,] words3 = null;
        private string[,] words4 = null;
        private string[,] words5 = null;
        private string[,] words6 = null;
        private string[,] words7 = null;
        private string[,] words8 = null;
        private string[,] words9 = null;

        private string[][,] words = null;

        public WordsArray()
        {
            words = new string[9][,];

            // 1
            words1 = new string[,]
            {
                { "false", "борьба" },
                { "false", "решительность" },
                { "false", "масштабность" },
                { "false", "подиум" },
                { "false", "цель" },
                { "false", "поход" },
                { "false", "стойкость" },
                { "false", "точность" },
                { "false", "амбициозность" },
                { "false", "смелость" },
                { "false", "лидерство" },
                { "false", "непреклонность" },
                { "false", "сопротивление" }
            };
            words[0] = words1;

            //2
            words2 = new string[,]
            {
                { "false", "литература" },
                { "false", "океан" },
                { "false", "речь" },
                { "false", "элегантный" },
                { "false", "бассейн" },
                { "false", "дождь" },
                { "false", "письмо" },
                { "false", "филологи¤" },
                { "false", "плавание" },
                { "false", "ручей" },
                { "false", "течение" },
                { "false", "словесность" },
                { "false", "стихи" }
            };
            words[1] = words2;

            //3
            words3 = new string[,]
            {
                { "false", "игра" },
                { "false", "море" },
                { "false", "смекалка" },
                { "false", "фантази¤" },
                { "false", "прыжок" },
                { "false", "безопасность" },
                { "false", "изобретение" },
                { "false", "юмор" },
                { "false", "интерес" },
                { "false", "краски" },
                { "false", "огонь" },
                { "false", "случайность" },
                { "false", "ответственность" }
            };
            words[2] = words3;

            //4
            words4 = new string[,]
            {
                { "false", "практичность" },
                { "false", "пор¤док" },
                { "false", "аскетизм" },
                { "false", "корабль" },
                { "false", "строгость" },
                { "false", "система" },
                { "false", "реформа" },
                { "false", "хоз¤йственность" },
                { "false", "экономи¤" },
                { "false", "чистота" },
                { "false", "договор" },
                { "false", "наставление" },
                { "false", "расчетливость" }
            };
            words[3] = words4;

            //5
            words5 = new string[,]
            {
                { "false", "культура" },
                { "false", "путешествие" },
                { "false", "богема" },
                { "false", "мастерска¤" },
                { "false", "сладость" },
                { "false", "танец" },
                { "false", "кино" },
                { "false", "прогресс" },
                { "false", "перемены" },
                { "false", "автомобиль" },
                { "false", "новое" },
                { "false", "дизайн" },
                { "false", "разнообразие" }
            };
            words[4] = words5;

            //6
            words6 = new string[,]
            {
                { "false", "правдивость" },
                { "false", "собака" },
                { "false", "гармони¤" },
                { "false", "природа" },
                { "false", "честность" },
                { "false", "шутка" },
                { "false", "верность" },
                { "false", "забота" },
                { "false", "электроника" },
                { "false", "целительство" },
                { "false", "служба" },
                { "false", "прекрасное" },
                { "false", "ангел" }
            };
            words[5] = words6;

            //7
            words7 = new string[,]
            {
                { "false", "тайна" },
                { "false", "уединение" },
                { "false", "астрологи¤" },
                { "false", "знание" },
                { "false", "мистика" },
                { "false", "коллекци¤" },
                { "false", "откровение" },
                { "false", "понимание" },
                { "false", "исследование" },
                { "false", "доверие" },
                { "false", "загадка" },
                { "false", "эксперимент" },
                { "false", "волшебство" }
            };
            words[6] = words7;

            //8
            words8 = new string[,]
            {
                { "false", "контроль" },
                { "false", "гибкость" },
                { "false", "финансы" },
                { "false", "свобода" },
                { "false", "управление" },
                { "false", "регулирование" },
                { "false", "карьера" },
                { "false", "бережливость" },
                { "false", "механика" },
                { "false", "успешность" },
                { "false", "справедливость" },
                { "false", "трудолюбие" },
                { "false", "достижение" }
            };
            words[7] = words8;

            //9
            words9 = new string[,]
            {
                { "false", "дар" },
                { "false", "философи¤" },
                { "false", "горы" },
                { "false", "удача" },
                { "false", "блаженство" },
                { "false", "элитное" },
                { "false", "пожертвовани¤" },
                { "false", "величие" },
                { "false", "дружба" },
                { "false", "удовольствие" },
                { "false", "безупречность" },
                { "false", "творение" },
                { "false", "разумность" }
            };
            words[8] = words9;

        }

        public string[,] GetWordsByNumber(int number)
        {
            return words[number-1];
        }

        public void SetViewedFlag(int number, int index)
        {
            words[number - 1][index, 0] = "true";
        }

        public System.Tuple<int, int, int> CheckTestOver()
        {
            int one = -1, two = -1, three = -1;
            int rows = words1.GetUpperBound(0) + 1;
            int[] results = new int[9];

            //1
            for (int i = 0; i < rows; i++)
                if (words1[i, 0] == "true")
                    results[0] += 1;

            //2
            for (int i = 0; i < rows; i++)
                if (words2[i, 0] == "true")
                    results[1] += 1;

            //3
            for (int i = 0; i < rows; i++)
                if (words3[i, 0] == "true")
                    results[2] += 1;

            //4
            for (int i = 0; i < rows; i++)
                if (words4[i, 0] == "true")
                    results[3] += 1;

            //5
            for (int i = 0; i < rows; i++)
                if (words5[i, 0] == "true")
                    results[4] += 1;

            //6
            for (int i = 0; i < rows; i++)
                if (words6[i, 0] == "true")
                    results[5] += 1;

            //7
            for (int i = 0; i < rows; i++)
                if (words7[i, 0] == "true")
                    results[6] += 1;

            //8
            for (int i = 0; i < rows; i++)
                if (words8[i, 0] == "true")
                    results[7] += 1;

            //9
            for (int i = 0; i < rows; i++)      
                if (words9[i, 0] == "true")
                    results[8] += 1;


            int flag = -1;
            // find index of max value
            for (int i = 0; i < 8; i++)
            {
                if (results[i] > RESULT_AMOUNT)
                {
                    one = i;
                    results[i] = 0;
                    flag = 1;
                    break;
                }
            }

            if (flag > 0)
            {
                // find second max value
                int tmp = 0;
                for (int i = 0; i < 8; i++)
                    if (results[i] > tmp)
                        tmp = results[i];


                // find index of max value
                for (int i = 0; i < 8; i++)
                {
                    if (results[i] == tmp)
                    {
                        two = i;
                        results[i] = 0;
                        tmp = 0;
                        break;
                    }
                }

                //find third max value
                for (int i = 0; i < 8; i++)
                    if (results[i] > tmp)
                        tmp = results[i];


                // find index of max value
                for (int i = 0; i < 8; i++)
                {
                    if (results[i] == tmp)
                    {
                        three = i;
                        results[i] = 0;
                        tmp = 0;
                        break;
                    }
                }

                var tuple = System.Tuple.Create(one + 1, two + 1, three + 1);
                //Debug.LogWarningFormat("{0} {1} {2}", one + 1, two + 1, three + 1);
                return tuple;
            }
            else
            {
                var tuple = System.Tuple.Create(-1, -1, -1);
                return tuple;
            }

        }

        public int GetArrayDimension()
        {
            return words1.GetUpperBound(0) + 1;
        }
    }

}
