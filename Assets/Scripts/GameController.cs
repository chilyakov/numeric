using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Numeric
{
    public class GameController : MonoBehaviour
    {

        private int arrayDimension = 0;

        private WordsArray wordsArray = null;
        private string[,] currentWords = null;
        //private int showWordOne = 0;
        //private int showWordTwo = 0;
        //private int showWordThree = 0;
        private string wordOne = null;
        private string wordTwo = null;
        private string wordThree = null;
        
        private int indexOne = 0;
        private int indexTwo = 0;
        private int indexThree = 0;

        private System.Tuple<int, string> tuple = null;
        private System.Tuple<int, int, int> randoms = null;
        private int selectedWord = 0;

        [SerializeField]
        private Button buttonOne = null;
        [SerializeField]
        private Button buttonTwo = null;
        [SerializeField]
        private Button buttonThree = null;
        [SerializeField]
        private Button buttonStart = null;


        [SerializeField] 
        private TextMeshProUGUI textButtonOne = null;
        [SerializeField]
        private TextMeshProUGUI textButtonTwo = null;
        [SerializeField]
        private TextMeshProUGUI textButtonThree = null;
        [SerializeField]
        private TextMeshProUGUI textButtonResult = null;
        [SerializeField]
        private TextMeshProUGUI textButtonResultNumber = null;


        private System.Tuple<int, int, int> GetRandomNumbers(bool withSeleceted)
        {
            var tuple = new System.Tuple<int, int, int>(0, 0, 0);

            int showWordOne = Random.Range(1, 10);
            int showWordTwo = Random.Range(1, 10);
            int showWordThree = Random.Range(1, 10);

            while (true)
            {
                if (showWordOne != showWordTwo && showWordOne != showWordThree && showWordTwo != showWordThree)
                    break;
                else
                {
                    showWordTwo = Random.Range(1, 10);
                    showWordThree = Random.Range(1, 10);
                }
            }

            // with selected word
            if (!withSeleceted) return System.Tuple.Create(showWordOne, showWordTwo, showWordThree);


            if (showWordOne != selectedWord && showWordTwo != selectedWord && showWordThree != selectedWord) showWordOne = selectedWord;
      
            int rnd = Random.Range(1, 7);
           

            switch (rnd)
            {
                case 1: // 1 2 3
                    tuple = System.Tuple.Create(showWordOne, showWordTwo, showWordThree);
                    return tuple;

                case 2: // 1 3 2
                    tuple = System.Tuple.Create(showWordOne, showWordThree, showWordTwo);
                    return tuple;

                case 3: // 2 1 3
                    tuple = System.Tuple.Create(showWordTwo, showWordOne, showWordThree);
                    return tuple;

                case 4: // 2 3 1
                    tuple = System.Tuple.Create(showWordTwo, showWordThree, showWordOne);
                    return tuple;

                case 5: // 3 1 2
                    tuple = System.Tuple.Create(showWordThree, showWordOne, showWordTwo);
                    return tuple;

                case 6: // 3 2 1
                    tuple = System.Tuple.Create(showWordThree, showWordTwo, showWordOne);
                    return tuple;

            }

            // shuffle
            return tuple;
        }

        private void GetWordIndex()
        {
            while (true)
            {
                int rnd = Random.Range(0, arrayDimension - 1);
                if (currentWords[rnd, 0] == "false")
                {
                    tuple = System.Tuple.Create(rnd, currentWords[rnd, 1]);
                    break;
                }
            }
        }


        private void GetRandomWords()
        {
            randoms = GetRandomNumbers(false);
            currentWords = wordsArray.GetWordsByNumber(randoms.Item1);
            GetWordIndex();
            indexOne = tuple.Item1;
            wordOne = tuple.Item2;
            textButtonOne.text = wordOne;

            currentWords = wordsArray.GetWordsByNumber(randoms.Item2);
            GetWordIndex();
            indexTwo = tuple.Item1;
            wordTwo = tuple.Item2;
            textButtonTwo.text = wordTwo;

            currentWords = wordsArray.GetWordsByNumber(randoms.Item3);
            GetWordIndex();
            indexThree = tuple.Item1;
            wordThree = tuple.Item2;
            textButtonThree.text = wordThree;

        }

        void CheckTestOver()
        {
            var result = wordsArray.CheckTestOver();
            if (result.Item1 < 0)
            {
                //GetRandomNumbers();
                GetRandomWords();
                //Debug.LogWarningFormat("{0} {1} {2}", wordOne, wordTwo, wordThree);
            }
            else
            {
                textButtonOne.text = "";
                textButtonTwo.text = "";
                textButtonThree.text = "";
                textButtonResult.text = "вам больше всего подходят эти цифры";
                textButtonResultNumber.text = "" + result.Item1 + " " + result.Item2 + " " + result.Item3;

                buttonStart.gameObject.SetActive(true);
                buttonStart.onClick.AddListener(buttonStartListener);

                //Debug.LogWarningFormat("Your number is {0}", result);
                buttonOne.enabled = false;
                buttonTwo.enabled = false;
                buttonThree.enabled = false;
            }

        }

        void ButtonOneListener()
        {
            //Debug.LogWarningFormat("index {0} of number {1}, ", indexOne, showWordOne);
            Debug.LogWarningFormat("Your choise is {0}", wordOne);
            wordsArray.SetViewedFlag(randoms.Item1, indexOne);
            selectedWord = randoms.Item1;
            CheckTestOver();
        }

        void ButtonTwoListener()
        {
            //Debug.LogWarningFormat("index {0} of number {1}, ", indexTwo, showWordTwo);
            Debug.LogWarningFormat("Your choise is {0}", wordTwo);
            wordsArray.SetViewedFlag(randoms.Item2, indexTwo);
            selectedWord = randoms.Item2;
            CheckTestOver();
        }

        void ButtonThreeListener()
        {
            //Debug.LogWarningFormat("index {0} of number {1}, ", indexThree, showWordThree);
            Debug.LogWarningFormat("Your choise is {0}", wordThree);
            wordsArray.SetViewedFlag(randoms.Item3, indexThree);
            selectedWord = randoms.Item3;
            CheckTestOver();
        }

        void buttonStartListener()
        {
            InitGame();
        }

        void InitGame()
        {
            buttonStart.onClick.RemoveAllListeners();
            buttonStart.gameObject.SetActive(false);
            buttonOne.enabled = true;
            buttonTwo.enabled = true;
            buttonThree.enabled = true;
            textButtonResult.text = "";
            textButtonResultNumber.text = "";
            wordsArray = null;
            wordsArray = new WordsArray();
            arrayDimension = wordsArray.GetArrayDimension();
            //GetRandomNumbers();

            selectedWord = Random.Range(1, 10);
            GetRandomWords();
            //Debug.LogWarningFormat("{0} {1} {2}", wordOne, wordTwo, wordThree);

        }

        void Awake()
        {
            if (buttonOne != null)
            {
                buttonOne.onClick.AddListener(ButtonOneListener);
            }
            if (buttonTwo != null)
            {
                buttonTwo.onClick.AddListener(ButtonTwoListener);
            }
            if (buttonThree != null)
            {
                buttonThree.onClick.AddListener(ButtonThreeListener);
            }
            if (buttonStart != null)
            {
                buttonStart.onClick.AddListener(buttonStartListener);
            }
        }


    }




}
