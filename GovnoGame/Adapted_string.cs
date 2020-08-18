using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace GovnoGame
{
    public class Adapted_string
    /* Класс, используемый для хранения вопроса и ответов к нему */ 
    {
        // Поля
        public string quest,
                      correct_answer,
                      answer2,
                      answer3,
                      answer4;
        bool initialized = false;

        public bool Inited
        {
            set
            {
                initialized = value;
            }
            get
            {
                return initialized;
            }
        }

        // Конструктор
        public Adapted_string()
        {
            quest = string.Empty;
            correct_answer = string.Empty;
            answer2 = string.Empty;
            answer3 = string.Empty;
            answer4 = string.Empty;
        }
        public Adapted_string(string quest, string c_answer, string answer2, string answer3, string answer4)
        {
            this.quest = quest;
            this.correct_answer = c_answer;
            this.answer2 = answer2;
            this.answer3 = answer3;
            this.answer4 = answer4;
        }

        // Методы
        // тут должен быть метод типа "Set" - Название_метода(string quest, string c_a, string a_2, string a_3, string a_4);
        // позже добавлю. Вместо этого - public string.
    }

    public class Adapted_strings
    /* Класс, используемый для хранения массивов вопросов и ответов к ним,
    также облегчает работу с ними */ 
    {   
        // Поля
        Adapted_string [] Array;                    // Массив строк
        int length = 28;                            // Максимальная длина массива
        int [] Findex;                              // Индексы текущего вопроса, который сгенерировал метод.
        Random rand;                                // Просто, чтобы был!

        // Свойства
        public Adapted_string [] GimmeStrings
        {
            set
            {
                // Пока, что незачем реализовывать этот кусок кода.
            }
            get
            {
                return Array;
            }
        }
        public int [] Forbidden_index
        {
            set
            {
                // Nope!
            }
            get
            {
                return Findex;
            }
        }
        public int Length
        {
            get { return length; }
        }

        // Конструктор
        public Adapted_strings()
        {
            Array = new Adapted_string[length];
            for (int i = 0; i < length; i++)
            {
                Array[i] = new Adapted_string();
            }
            InitializeStandartQuestions();
            Findex = new int[5];
        }
        public Adapted_strings(Adapted_string[] Array, int size)
        {
            this.Array = Array;
            length = size;
            Findex = new int[5];
        }
        public Adapted_strings(string pathname)
        {
            InitializeQuestionsFromPath(pathname);
            Findex = new int[5];
        }

        // Методы
        public Adapted_string RandomizeQuestion(int [] Forbidden_index, int count)
        /* Выбирает наугад 1 вопрос из 28, исключая index вопрос. 
         * Возвращает Adapted_string, в отличии от RandomizeQuestions() */
        {
            rand = new Random();
            int n, i = 0, result = 0;
            while(true)
            {
                n = rand.Next(1, 29);
                for (int j = 0; j < 10; j++)
                {
                    if (n != Forbidden_index[j])
                        result++;
                }
                if (result == 10)
                    break;
                i++;
            }
            Findex = Forbidden_index;
            Findex[count] = n;
            Adapted_string Return = Array[n - 1];
            return Return;
        }
        public void AddQuestions(Adapted_string ToBeAdded)
        /* Добавляет пользовательский вопрос к текущей базе вопросов.
         * (При выходе из программы исчезают вопросы, потом реализую подгрузку из файла с сохранением в файл) */
        {
            Adapted_string[] Temp = new Adapted_string[length + 1];
            for (int i = 0; i < length; i++)
            {
                Temp[i] = Array[i];
            }
            Temp[length] = ToBeAdded;
            length++;
            Array = Temp;
        }
        public void DeleteQuestions(Adapted_string ToBeDeleted)
        /* Удаляет вопросы из текущей базы вопросов, сравнивая их по критериям.
         * (При выходе из программы вопросы исчезают, потом реализую подгрузку из файла с сохранением в файл) */
        {
            bool a = true;
            Adapted_string[] Temp = new Adapted_string[length - 1];
            for(int i = 0, j = 0; i < length - 1; i++, j++)
            {
                if (Array[i].quest == ToBeDeleted.quest && a)
                {
                    a = false;
                    j++;
                }
                Temp[i] = Array[j];
            }
            length--;
            Array = Temp;
        }
        public void EditQuestions(Adapted_string ToBeModified)
        /* Редактирует вопрос из текущей базы вопросов
         * (При выходе из программы редактированные вопросы не заменяют изначальные вопросы,
         * потом реализую подгрузку из файла с сохранением в файл)*/
        {
            bool a = true;
            Adapted_string[] Temp = new Adapted_string[length];
            for (int i = 0; i < length; i++)
            {
                if (Array[i].quest == ToBeModified.quest && a)
                { 
                    Temp[i] = ToBeModified;
                    a = false;
                }
                Temp[i] = Array[i];
            }
            Array = Temp;
        }

        // Вспомогательные методы
        private void InitializeStandartQuestions()
        /* Инициализирует стандартные вопросы, предусмотренные программой. 
         * Внимание!! ТОТ ЕЩЁ ГОВНОКОД!! Смотреть код на свой страх и риск. */
        {
            int i = 0;
            Array[i].quest = "Как называется место на берегу, где обитают тюлени?";
            Array[i].correct_answer = "Лежбище";
            Array[i].answer2 = "Стойбище";
            Array[i].answer3 = "Пастбище";
            Array[i].answer4 = "Гульбище";
            i++; // 1
            Array[i].quest = "Как мировая пресса называла премьер-министра Великобритании Маргарет Тэтчер?";
            Array[i].correct_answer = "Железная леди";
            Array[i].answer2 = "Стальная леди";
            Array[i].answer3 = "Оловянный солдатик";
            Array[i].answer4 = "Крепкий орешек";
            i++; // 2
            Array[i].quest = "Какое из этих городов южнее остальных?";
            Array[i].correct_answer = "Каир";
            Array[i].answer2 = "Токио";
            Array[i].answer3 = "Мадрид";
            Array[i].answer4 = "Сан-Франциско";
            i++; // 3
            Array[i].quest = "Через какой город мира проходит нулевой меридиан?";
            Array[i].correct_answer = "Гринвич";
            Array[i].answer2 = "Гринсборо";
            Array[i].answer3 = "Глазго";
            Array[i].answer4 = "Гронинген";
            i++; // 4
            Array[i].quest = "Какая птица является символом Новой Зеландии?";
            Array[i].correct_answer = "Киви";
            Array[i].answer2 = "Жако";
            Array[i].answer3 = "Эму";
            Array[i].answer4 = "Казуар";
            i++; // 5
            Array[i].quest = "Какого короля англичане прозвали \"Львиное сердце\"?";
            Array[i].correct_answer = "Ричард I";
            Array[i].answer2 = "Вильгельм I";
            Array[i].answer3 = "Георг I";
            Array[i].answer4 = "Генрих I";
            i++; // 6
            Array[i].quest = "Как в народе называются финансовые институты, обещающие вкладчикам золотые горы?";
            Array[i].correct_answer = "Пирамиды";
            Array[i].answer2 = "Гробницы";
            Array[i].answer3 = "Захоронения";
            Array[i].answer4 = "Сфинксы";
            i++; // 7
            Array[i].quest = "Какая награда вручается вместе с присвоением звания Героя России?";
            Array[i].correct_answer = "Медаль \"Золотая Звезда\"";
            Array[i].answer2 = "Медаль \"За отвагу\"";
            Array[i].answer3 = "Орден Суворова";
            Array[i].answer4 = "Орден мужества";
            i++; // 8
            Array[i].quest = "В каком городе родился Вольфганг Амадей Моцарт?";
            Array[i].correct_answer = "Зальцбург";
            Array[i].answer2 = "Веймар";
            Array[i].answer3 = "Прага";
            Array[i].answer4 = "Вена";
            i++; // 9
            Array[i].quest = "Какую реку Юлий Цезарь перешел со словами \"Жребий брошен\"?";
            Array[i].correct_answer = "Рубикон";
            Array[i].answer2 = "Припять";
            Array[i].answer3 = "Нил";
            Array[i].answer4 = "Евфрат";
            i++; // 10
            Array[i].quest = "Как называется искусство аранжировки цветов?";
            Array[i].correct_answer = "Икебана";
            Array[i].answer2 = "Суши";
            Array[i].answer3 = "Кэндо";
            Array[i].answer4 = "Харакири";
            i++; // 11
            Array[i].quest = "Какая страна является мировым лидером по производству кофе?";
            Array[i].correct_answer = "Бразилия";
            Array[i].answer2 = "Венесуэла";
            Array[i].answer3 = "Мексика";
            Array[i].answer4 = "Аргентина";
            i++; // 12
            Array[i].quest = "Что труднее всего дается не трезвому человеку?";
            Array[i].correct_answer = "Вязать лыко";
            Array[i].answer2 = "Трепать нервы";
            Array[i].answer3 = "Бить баклуши";
            Array[i].answer4 = "Витать в облаках";
            i++; // 13
            Array[i].quest = "Как называют японских мафиози?";
            Array[i].correct_answer = "Якудза";
            Array[i].answer2 = "Джакузи";
            Array[i].answer3 = "Камикадзе";
            Array[i].answer4 = "Коза Ностра";
            i++; // 14
            Array[i].quest = "Участник какого из перечисленных спортивных состязаний экипирован винтовкой?";
            Array[i].correct_answer = "Биатлон";
            Array[i].answer2 = "Бейсбол";
            Array[i].answer3 = "Бадминтон";
            Array[i].answer4 = "Бобслей";
            i++; // 15
            Array[i].quest = "В каком канадском городе находится самая высокая в мире телебашня?";
            Array[i].correct_answer = "Торонто";
            Array[i].answer2 = "Оттава";
            Array[i].answer3 = "Ванкувер";
            Array[i].answer4 = "Монреаль";
            i++; // 16
            Array[i].quest = "Какой из этих романов написал не Хемингуэй?";
            Array[i].correct_answer = "\"Триумфальная арка\"";
            Array[i].answer2 = "\"Фиеста\"";
            Array[i].answer3 = "\"По ком звонит колокол\"";
            Array[i].answer4 = "\"Острова в океане\"";
            i++; // 17
            Array[i].quest = "В каком виде спорта прославился Евгений Кафельников?";
            Array[i].correct_answer = "Теннис";
            Array[i].answer2 = "Бокс";
            Array[i].answer3 = "Метание ядра";
            Array[i].answer4 = "Охота на лис";
            i++; // 18
            Array[i].quest = "Как называется пара, присутствующая на церемонии бракосочетания вместе с молодыми?";
            Array[i].correct_answer = "Свидетели";
            Array[i].answer2 = "Соучастники";
            Array[i].answer3 = "Запасные";
            Array[i].answer4 = "Защитники";
            i++; // 19
            Array[i].quest = "Как звали невесту Эдмона Дантеса, будущего графа Монте-Кристо?";
            Array[i].correct_answer = "Мерседес";
            Array[i].answer2 = "Тойота";
            Array[i].answer3 = "Хонда";
            Array[i].answer4 = "Лада";
            i++; // 20
            Array[i].quest = "Какой цвет получается при смешении синего и красного?";
            Array[i].correct_answer = "Фиолетовый";
            Array[i].answer2 = "Коричневый";
            Array[i].answer3 = "Зеленый";
            Array[i].answer4 = "Голубой";
            i++; // 21
            Array[i].quest = "Какая компания в Италии выпускает наибольшее количество автомобилей?";
            Array[i].correct_answer = "Фиат";
            Array[i].answer2 = "Феррари";
            Array[i].answer3 = "Ламборгини";
            Array[i].answer4 = "Альфа Ромео";
            i++; // 22
            Array[i].quest = "Кто из древних философов, по преданию, жил в бочке?";
            Array[i].correct_answer = "Диоген";
            Array[i].answer2 = "Демокрит";
            Array[i].answer3 = "Платон";
            Array[i].answer4 = "Сократ";
            i++; // 23
            Array[i].quest = "Каким из этих природных явлений А.Островский назвал свою пьесу?";
            Array[i].correct_answer = "Гроза";
            Array[i].answer2 = "Снегопад";
            Array[i].answer3 = "Шаровая молния";
            Array[i].answer4 = "Гололед";
            i++; // 24
            Array[i].quest = "Какой туман кажется В.Добрынину похожим на обман в одной из его песен?";
            Array[i].correct_answer = "Синий";
            Array[i].answer2 = "Утренний";
            Array[i].answer3 = "Сиреневый";
            Array[i].answer4 = "Желтый";
            i++; // 25
            Array[i].quest = "Кому принадлежат строки - пророчества: \"Настанет год, России черный год, Когда царей корона упадет...\"?";
            Array[i].correct_answer = "Лермонтов";
            Array[i].answer2 = "Пушкин";
            Array[i].answer3 = "Нострадамус";
            Array[i].answer4 = "Некрасов";
            i++; // 26
            Array[i].quest = "Как называется маскировочная окраска военной техники и обмундирования?";
            Array[i].correct_answer = "Камуфляж";
            Array[i].answer2 = "Макияж";
            Array[i].answer3 = "Хаки";
            Array[i].answer4 = "Камуфлет";
            i++; // 27
            Array[i].quest = "Какой материк омывается всеми четырьмя океанами?";
            Array[i].correct_answer = "Евразия";
            Array[i].answer2 = "Северная Америка";
            Array[i].answer3 = "Австралия";
            Array[i].answer4 = "Южная Америка";

        }
        private void InitializeQuestionsFromPath(string pathname)
        {
            // Реализовать подгрузку
        }
    } 
}
