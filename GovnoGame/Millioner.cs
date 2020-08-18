using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace GovnoGame
{
    public class Millioner
    {
        // Поля
        static bool ingame = false;           /* Переменная, отвечающая за состояние игры. Используется только в 3 методах.
                                               * true = игра в действии. false = игра прервана. */
        int uindex  = 0,                      // Индекс, который показывает прогресс пользователя.
            game    = 0;                      // Переменная, отвечающая за результат игры. 1 = игра выиграна, -1 = игра проиграна.
        bool ingame_action = true;            /* true = можно рандомизировать вопросы и ответы, т.к. пользователь уже ответил на вопрос,
                                               * правильно или нет, не имеет значения. false = нельзя рандомизировать, т.к. пользователь
                                               * не отвечает на вопросы или призадумался */

        // Свойства
        static public bool Ingame
        {
            set
            {
                // Read Only!
            }
            get
            {
                return ingame;
            }
        }
        public bool RandomizeAllowed
        {
            set
            {
                ingame_action = value;
            }
            get
            {
                return ingame_action;
            }
        }
        public int UIndex
        {
            set
            {
                // Read Only!
            }
            get
            {
                return uindex;
            }
        }
        public int Game
        {
            set
            {
                // Read Only
            }
            get
            {
                return game;
            }
        }

        // Конструктор
        public Millioner()
        {
            ingame_action = true;
            game = 0;
            uindex = 0;
            ingame = true;
        }

        // Методы
        public void LevelUp()
        /* Если пользователь ответил на верный вопрос, то он переходит на уровень выше.
        Если пользователь ответил верно на 15ом уровне вопроса, то игра выиграна. */ 
        {
            uindex++;
            if (uindex == 15) game = 1;
        }
        public void LevelDown()
        /* Если пользователь ответил на неверный вопрос, то он переходит на уровень ниже.
        Если пользователь ответил неверно на 15ом уровне вопроса, то игра проиграна. */ 
        {
            uindex--;
            if (uindex == -1) game = -1;
        }
        public void Reset()
        /* Обнуление */
        {
            game = 0;
            ingame = false;
            uindex = 0;
            ingame_action = true;
        }
    }
}
