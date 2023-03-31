namespace Ejercicio2
{
    class Program
    {
        private static string userString = "";
        static void Main(string[] args)
        {
            userString = GetUserString();

            char userOption = '0';

            while (!userOption.Equals('0'))
            {
                PaintOptionsMenu(userString);

                Console.Write("Seleccione una opción: ");

                switch (userOption)
                {
                    case '0':
                        ExitOption();
                        break;
                    case '1':
                       ReplaceWordOption(userString);
                        break;
                    case '2':


                        break;
                }

            }
        }

        private static void ReplaceWordOption(string userString)
        {
            bool isFound = false;

            // Comprueba si la palabra se encuentra dentro de la cadena.
            while (!isFound)
            {
                Console.Clear();

                ShowString(userString);

                string wordToReplace = GetWordToReplace();

                // Comprueba que la palabra se encuentre dentro de la cadena. 
                if (userString.Contains(wordToReplace))
                {
                    string newWord = GetNewWord();

                    bool isNotNull = false;

                    // Valida que la palabra sea correcta. Si no, la vuelve a solicitar. 
                    while (!isNotNull)
                    {
                        // Comprueba que la cadena no esté vacía ni sea nula.
                        if (!string.IsNullOrEmpty(userString))
                        {
                            // Reemplaza la nueva palabra por la anterior. 
                            string auxiliaryString = ReplaceWordInString(userString, wordToReplace, newWord);

                            userString = auxiliaryString;

                            Console.WriteLine("\nSe ha sustituido la palabra con éxito.\n");
                            ShowString(userString);
                        }
                        else
                        {
                            Console.WriteLine("\nDebe introducir una palabra para sustituirla.");
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("La palabra introducida no se encuentra en el texto." +
                        "\n Introduzca una palabra que sí lo esté.");
                    Console.ReadKey();
                }
            }
        }

        private static string ReplaceWordInString(string userString, string wordToReplace, string newWord)
        {
            return userString.Replace(wordToReplace, newWord);
        }

        private static string GetNewWord()
        {
            Console.WriteLine("\n¿Por qué palabra quiere sustituirla?: ");
            string newWord = Console.ReadLine();
            return newWord;
        }

        private static string GetWordToReplace()
        {
            Console.WriteLine("\n¿Qué palabra quiere sustituir?: ");
            string wordToReplace = Console.ReadLine();
            return wordToReplace;
        }

        private static void ExitOption()
        {
            Console.Clear();
            Console.WriteLine("Gracias por usar este software. ¡Hasta la próxima!");
            Console.ReadKey();
        }

        private static void PaintOptionsMenu(string userString)
        {
            ShowString(userString);

            Console.WriteLine("\nOpciones:");
            Console.WriteLine("\t1.- Sustituir palabra.");
            Console.WriteLine("\t2.- Buscar texto.");
            Console.WriteLine("\t3.- Buscar texto de inicio.");
            Console.WriteLine("\t4.- Salir.");
        }

        private static void ShowString(string userString)
        {
            Console.WriteLine("La cadena es la siguiente: ");
            Console.WriteLine(userString);
        }

        private static string GetUserString()
        {
            bool isCorrectString = false;
            string userString = "";

            while (!isCorrectString)
            {
                Console.WriteLine("Introduzca una cadena de, al menos, 40 caracteres: ");
                userString = Console.ReadLine();


                if (userString.Length >= 40 && !string.IsNullOrEmpty(userString))
                {
                    Console.WriteLine("Cadena válida.");

                    isCorrectString = true;
                }
                else
                {
                    Console.WriteLine($"\nLa cadena introducida posee únicamente {userString.Length} caracteres." +
                        $" Por favor, introduzca una cadena con, al menos, 40 caracteres.");
                }
            }

            return userString;
        }
    }
}