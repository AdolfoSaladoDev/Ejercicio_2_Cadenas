namespace Ejercicio2
{
    class Program
    {
        // Variable global usada por todo el programa. 
        private static string userString = "";

        static void Main(string[] args)
        {
            userString = GetUserString();
            OptionMenu();
        }

        /// <summary>
        /// Método encargado de realizar la lógica de las diferentes opciones del menú. 
        /// </summary>
        private static void OptionMenu()
        {
            string userOption = "7";

            while (!userOption.Equals("5"))
            {
                PaintOptionsMenu(userString);

                Console.Write("Seleccione una opción: ");
                userOption = Console.ReadLine();

                switch (userOption)
                {
                    case "5":
                        ExitOption();
                        break;
                    case "1":
                        ReplaceWordOption();
                        break;
                    case "2":
                        SearchTextOption();
                        break;
                    case "3":
                        SearchSringStart();
                        break;
                    case "4":
                        ConvertDigitsOption();
                        break;
                }

                Console.WriteLine("No ha introducido una opción correcta.");
            }
        }

        /// <summary>
        /// Método encargado de añadir ceros a la izquierda hasta completar una longitud de 12. 
        /// </summary>
        private static void ConvertDigitsOption()
        {
            int numberUser;

            bool isNumber = false;

            while (!isNumber)
            {
                Console.Clear();
                Console.WriteLine("Ha elegido la opción Conversión de dígito.");
                Console.Write("Introduzca un dígito: ");
                string numberUserString = Console.ReadLine();

                // Comprobando si se ha introducido un número.
                isNumber = int.TryParse(numberUserString, out numberUser);

                if (isNumber)
                {
                    if (numberUserString.Length < 12)
                    {
                        int differenceNumber = 12 - numberUserString.Length;

                        // Añade el carácter deseado a la izquierda, en este caso, 0. 
                        string newStringWithZero = numberUserString.PadLeft(differenceNumber, '0');

                        Console.WriteLine("\nLa cadena resultante es: " + newStringWithZero);
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("\nLa cadena tiene un tamaño mayor o igual a 12");
                    }
                }
                else
                {
                    Console.WriteLine("No ha introducido dígitos correctamente.");
                }
            }
        }

        /// <summary>
        /// Método encargado de comprobar si una cadena empieza por una cadena introducida por el usuario.
        /// </summary>
        private static void SearchSringStart()
        {
            bool isCorrect = false;

            while (!isCorrect)
            {
                Console.Clear();
                ShowString();
                Console.WriteLine("Ha elegido la opción Buscar texto de inicio:");

                Console.Write("Introduzca el texto deseado: ");
                string textToSearch = Console.ReadLine();

                if (!string.IsNullOrEmpty(textToSearch))
                {
                    if (userString.StartsWith(textToSearch))
                    {
                        Console.WriteLine($"\nLa cadena comienza por \'{textToSearch}\'.");
                    }
                    else
                    {
                        Console.WriteLine($"\nLa cadena no comienza por \'{textToSearch}\'.");
                    }

                    Console.ReadKey();
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("\nDebe añadir un texto. Introduzca una cadena correcta.");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Método encargado de buscar si un texto introducido por el usuario se encuentra dentro de la cadena.
        /// </summary>
        private static void SearchTextOption()
        {

            bool isNotNull = false;

            while (!isNotNull)
            {
                Console.Clear();
                ShowString();

                Console.WriteLine("\nHa elegido la opción Buscar texto: ");

                ShowString();

                Console.Write("\n¿Qué texto desea buscar?: ");
                string textToSearch = Console.ReadLine();

                if (!string.IsNullOrEmpty(textToSearch))
                {
                    if (userString.Contains(textToSearch))
                    {
                        Console.Clear();
                        Console.WriteLine($"\nLa cadena \'{textToSearch}\' se encuentra dentro del texto.");
                        Console.ReadKey();
                        isNotNull = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("La cadena introducida no se encuentra en el texto");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("No puede estar vacía. Introduzca una cadena correcta.");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Método encargado de sustituir una palabra introducida por el usuario dentro de la cadena.
        /// </summary>
        private static void ReplaceWordOption()
        {
            bool isFound = false;

            // Comprueba si la palabra se encuentra dentro de la cadena.
            while (!isFound)
            {
                Console.Clear();

                Console.WriteLine("\nHa elegido la opción Sustituir palabra: ");

                ShowString();

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
                            ShowString();

                            Console.ReadKey();

                            isNotNull = true;
                        }
                        else
                        {
                            Console.WriteLine("\nDebe introducir una palabra para sustituirla.");
                            Console.ReadKey();
                        }
                    }

                    isFound = true;
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

        /// <summary>
        /// Método que realiza la lógica de sustitución de una palabra por otra dentro de la cadena.
        /// </summary>
        /// <param name="userString">Cadena completa</param>
        /// <param name="wordToReplace">Cadena a reemplazar</param>
        /// <param name="newWord">Nueva cadena que añadir</param>
        /// <returns></returns>
        private static string ReplaceWordInString(string userString, string wordToReplace, string newWord)
        {
            return userString.Replace(wordToReplace, newWord);
        }

        /// <summary>
        /// Método encargado de obtener la nueva palabra por la que se quiere sustituir.
        /// </summary>
        /// <returns>La nueva palabra que va a sustituir a la anterior.</returns>
        private static string GetNewWord()
        {
            Console.Write("\n¿Por qué palabra quiere sustituirla?: ");
            string newWord = Console.ReadLine();
            return newWord;
        }

        /// <summary>
        /// Método encargado de obtener la cadena que se desea sustituir.
        /// </summary>
        /// <returns>Cadena que se quiere reemplazar</returns>
        private static string GetWordToReplace()
        {
            Console.Write("\n¿Qué palabra quiere sustituir?: ");
            string wordToReplace = Console.ReadLine();
            return wordToReplace;
        }

        /// <summary>
        /// Método encargado de mostrar la despedida al usuario cuando finaliza el programa.
        /// </summary>
        private static void ExitOption()
        {
            Console.Clear();
            Console.WriteLine("Gracias por usar este software. ¡Hasta la próxima!");
            Console.ReadKey();
        }

        /// <summary>
        /// Método encargado de pintar por consola la cadena introducida por el usuario y las opciones que puede realizar.
        /// </summary>
        /// <param name="userString"></param>
        private static void PaintOptionsMenu(string userString)
        {
            ShowString();

            Console.WriteLine("\nOpciones:");
            Console.WriteLine("\t1.- Sustituir palabra.");
            Console.WriteLine("\t2.- Buscar texto.");
            Console.WriteLine("\t3.- Buscar texto de inicio.");
            Console.WriteLine("\t4.- Conversión de dígito.");
            Console.WriteLine("\t5.- Salir.");
        }

        /// <summary>
        /// Método encargado de mostrar la cadena que ha introducido el usuario.
        /// </summary>
        private static void ShowString()
        {
            Console.Clear();
            Console.WriteLine("La cadena es la siguiente: ");
            Console.WriteLine(userString);
        }

        /// <summary>
        /// Método encargado de pedir al usuario la cadena que se desea utilizar durante el programa.
        /// </summary>
        /// <returns></returns>
        private static string GetUserString()
        {
            bool isCorrectString = false;
            string userString = "";

            while (!isCorrectString)
            {
                Console.WriteLine("Introduzca una cadena de, al menos, 40 caracteres: ");
                userString = Console.ReadLine();


                if (userString.Length >= 40)
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