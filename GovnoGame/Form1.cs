using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Media;

namespace GovnoGame
{

    public partial class Form1 : Form
    {
        // Переменные
        string[] MyProgressBar;                   /* Массив строк, содержащий 11 строк, заменяющие
                                                   * ProgressBar квадратными символами на каждые 10% */
        string[] Percents;                        // Массив строк с процентами для _Help
        Millioner  obj;                           /* Объект, содержащий все переменные/данные/элементы игры,
                                                   * а также пару методов, отвечающие за игровые события */
        AnswersForm subj;                         /* Дополнительный диалог, который должен показывать ответы на вопросы */
        WinForm end;                              // Windows Form, окно завершения игры.
        Adapted_strings Array;                    /* Массив строк, содержащий все вопросы и ответы к игре,
                                                   * строки подгружаются в начале игры из текстового файла.
                                                   * Нихрена не подгружаются, они инициализируются в конструкторе по умолчанию! -_-
                                                   * Отсюда Adapted_strings Array берёт своё начало
                                                   * и идёт дальше во вложенный класс Millioner  */
        Label [] Levels;                          // Массив label, которые отвечают за текущий уровень игрока и её подсветку.
        Button[] Answers;                         /* Массив, состоящий из 4 кнопок, у которых нужно перетасовать содержимое (ответы)
                                                     индекс 0 - правильный ответ, индексы 1\2\3  - неправильные ответы */
        Label [] _Help;                           // Массив label, которые отвечают за подсказки зала.
        Label [] _HelpProgBar;                    // Символьный прогресс-бар для HelpOp
        Adapted_string RandomedQuest;             /* Класс строк, не содержащий ничего, заготовка на случай, если потребуется 
                                                   * рандомизировать вопрос. */
        int   [] Findex;                          /* Прошедший индекс вопроса, который был рандомизирован, необходим для того, 
                                                   * чтобы рандомизировать без повторения. */
        int uindex = 0;                           // Индекс текущего уровня, нужен как индексатор для Label [] Levels
        const int won     = 1,                    // Константы для вывода окна 
                  losed   = -1,                   // Победы/Поражения
                  stopped = 0;                    // Или поражения с несгрораемой суммой, в случае если игру прервали.
        bool CanIPressButton = true;              // Запрещает нажимать на кнопку, пока не закончилась обработка кода в потоке.
        bool Template = true;                     // Необходим для метода SwapAnswers
        int count = 0;                            // Итератор для index
        object[] NecessaryInRefresh;              /*  Массив объектов. Все игровые элементы, 
                                                   *  нуждающиеся в обновлении(перерисовки, Refresh())
                                                   *  Элемент          Индекс
                                                   *  ─────────────────────────
                                                   *  GroupBox           1
                                                   *  PictureBox      2  -  3 
                                                   *  Button          3  -  9
                                                   *  Label           10 -  28
                                                   *  ─────────────────────────
                                                   */
        bool flag_a = true,
             flag_b = true,
             flag_c = true;


        // Конструктор
        public Form1()
        {
            InitializeComponent();
            NecessaryInRefresh = new object[29];
            MyProgressBar = new string[11];
            Percents = new string[11];
            obj     = null;
            subj    = null;
            Array   = new Adapted_strings(); // Перегрузка на загрузку с файла - new Adapted_strings("path");
            Levels  = new Label[15];
            Answers = new Button[4];
            _Help   = new Label[4];
            _HelpProgBar = new Label[4];
            InitProgressBar();
            InitLevels();
            InitHelps();
            InitPercetns();
            InitNIR();
            Findex = new int[10];
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "Sounds/begin.wav";
            player.Play();
        }

        // Методы
        private void SwapAnswers(Adapted_string adstring)
        /*Перетасовывает содержимое кнопок Answer1, Answer2, Answer3 & Answer4 так,
         * чтобы они отличались от первоначального местоположения. */
        {
            Random rand = new Random();
            Button[] Temp = new Button[4];
            Temp = InitTempButtons();
            int correct = rand.Next(1, 5);
            int uncorrect1 = 0, uncorrect2 = 0, uncorrect3 = 0;
            uncorrect1 = RandomizeUncorrectAns(rand, correct);
            uncorrect2 = RandomizeUncorrectAns(rand, correct, uncorrect1);
            uncorrect3 = RandomizeUncorrectAns(rand, correct, uncorrect1, uncorrect2);
            Answers[0] = Temp[correct - 1];
            Answers[1] = Temp[uncorrect1 - 1];
            Answers[2] = Temp[uncorrect2 - 1];
            Answers[3] = Temp[uncorrect3 - 1];
            InitButtonName(adstring);
        }
        // Инициализация
        private void InitProgressBar()
        {
            MyProgressBar[0]  = " ";          //   0%
            MyProgressBar[1]  = "█";          //  10%
            MyProgressBar[2]  = "██";         //  20%
            MyProgressBar[3]  = "███";        //  30%
            MyProgressBar[4]  = "████";       //  40%
            MyProgressBar[5]  = "█████";      //  50%
            MyProgressBar[6]  = "██████";     //  60%
            MyProgressBar[7]  = "███████";    //  70%
            MyProgressBar[8]  = "████████";   //  80%
            MyProgressBar[9]  = "█████████";  //  90%
            MyProgressBar[10] = "██████████"; // 100%
        }
        private void InitPercetns()
        {
            Percents[0]  = "  0%";
            Percents[1]  = " 10%";
            Percents[2]  = " 20%";
            Percents[3]  = " 30%";
            Percents[4]  = " 40%";
            Percents[5]  = " 50%";
            Percents[6]  = " 60%";
            Percents[7]  = " 70%";
            Percents[8]  = " 80%";
            Percents[9]  = " 90%";
            Percents[10] = " 100%";
        }
        private void InitButtons()
        {
            Answers[0] = this.Answer1;
            Answers[1] = this.Answer2;
            Answers[2] = this.Answer3;
            Answers[3] = this.Answer4;
        }
        private void InitLevels()
        {
            Levels[0]  = this.Level1;
            Levels[1]  = this.Level2;
            Levels[2]  = this.Level3;
            Levels[3]  = this.Level4;
            Levels[4]  = this.Level5;
            Levels[5]  = this.Level6;
            Levels[6]  = this.Level7;
            Levels[7]  = this.Level8;
            Levels[8]  = this.Level9;
            Levels[9]  = this.Level10;
            Levels[10] = this.Level11;
            Levels[11] = this.Level12;
            Levels[12] = this.Level13;
            Levels[13] = this.Level14;
            Levels[14] = this.Level15;
        }
        private void InitHelps()
        {
            _Help[0] = Help_A;
            _Help[1] = Help_B;
            _Help[2] = Help_C;
            _Help[3] = Help_D;
            _HelpProgBar[0] = MyProgressBar_A;
            _HelpProgBar[1] = MyProgressBar_B;
            _HelpProgBar[2] = MyProgressBar_C;
            _HelpProgBar[3] = MyProgressBar_D;
            _HelpProgBar[0].Text = MyProgressBar[0];
            _HelpProgBar[1].Text = MyProgressBar[0];
            _HelpProgBar[2].Text = MyProgressBar[0];
            _HelpProgBar[3].Text = MyProgressBar[0];
        }
        private void InitNIR()
        /* NIR - NecessaryInRefresh */
        {
            /* Не относится к этому методу, но из-за хреновой архитектуры он необходим! 
             * Иначе вылетит Exception при старте игры. */
            InitButtons();

            // GroupBox
            NecessaryInRefresh[0] = GroupZal;
            // PictureBox
            NecessaryInRefresh[1] = Galkin;
            NecessaryInRefresh[2] = Batan;     
            // Button
            NecessaryInRefresh[3] = fifty_fifty;
            NecessaryInRefresh[4] = button_help;
            NecessaryInRefresh[5] = button_call;
            for (int i = 6, j = 0; i < 10; i++, j++)
            {
                NecessaryInRefresh[i] = Answers[j];
            }
            // Label
            NecessaryInRefresh[10] = Text_NO;
            NecessaryInRefresh[11] = Text_OK;
            NecessaryInRefresh[12] = Text_Sparta;
            NecessaryInRefresh[13] = Question;
            for (int i = 14, j = 0; i < 29; i++, j++)
            {
                NecessaryInRefresh[i] = Levels[j];
            }
        }
        private int RandomizeUncorrectAns(Random rand, int reserved)
        {
            int res;
            while (true)
            {
                res = rand.Next(1, 5);
                if (res != reserved)
                    break;
            }
            return res;
        }
        private int RandomizeUncorrectAns(Random rand, int reserved, int reserved2)
        {
            int res;
            while (true)
            {
                res = rand.Next(1, 5);
                if (res != reserved && res != reserved2)
                    break;
            }
            return res;
        }
        private int RandomizeUncorrectAns(Random rand, int reserved, int reserved2, int reserved3)
        {
            int res;
            while (true)
            {
                res = rand.Next(1, 5);
                if (res != reserved && res != reserved2 && res != reserved3)
                    break;
            }
            return res;
        }
        private Button[] InitTempButtons()
        {
            Button[] Temp = new Button[4];
            if(this.Template)
            {
                Temp[0] = this.Answer1;
                Temp[1] = this.Answer2;
                Temp[2] = this.Answer3;
                Temp[3] = this.Answer4;
                this.Template = false;
            }
            else
            {
                ResetButtonText();
                Temp[0] = Answers[0];
                Temp[1] = Answers[1];
                Temp[2] = Answers[2];
                Temp[3] = Answers[3];
            }
            return Temp;
        }
        private void InitButtonName(Adapted_string adstring)
        {
            Answers[0].Text += adstring.correct_answer;
            Answers[1].Text += adstring.answer2;
            Answers[2].Text += adstring.answer3;
            Answers[3].Text += adstring.answer4;
        }
        // Прочее
        private void GameReset()
        /* Возвращает к обычному виду поле игры. Все подсказки и игровые элементы,
         * которые выскакивают скрываются */
        {
            obj.Reset();
            this.Galkin.Visible = false;
            this.Text_NO.Visible = false;
            this.Text_OK.Visible = false;
            this.GroupZal.Visible = false;
            this.Text_Sparta.Visible = false;
            this.Batan.Visible = false;
            this.Answer1.Visible = false;
            this.Answer2.Visible = false;
            this.Answer3.Visible = false;
            this.Answer4.Visible = false;
            this.Question.Visible = false;
            this.fifty_fifty.BackgroundImage = Properties.Resources._1;
            this.button_call.BackgroundImage = Properties.Resources._2;
            this.button_help.BackgroundImage = Properties.Resources._3;
            this.fifty_fifty.Enabled = true;
            this.button_call.Enabled = true;
            this.button_help.Enabled = true;
            Level1.BackColor = System.Drawing.Color.Black;
            InitPercetns();
            RefreshElements();
        }
        private void RefreshElements()
        /* Циклы с Refresh() */
        {
            GroupBox gb;
            PictureBox pb;
            Button b;
            Label l;
            gb = (GroupBox)NecessaryInRefresh[0];
            gb.Refresh();
            for (int i = 1; i < 3; i++)
            {
                pb = (PictureBox)NecessaryInRefresh[i];
                pb.Refresh();
            }
            for (int i = 4; i < 10; i++)
            {
                b = (Button)NecessaryInRefresh[i];
                b.Refresh();
            }
            for (int i = 10; i < NecessaryInRefresh.Length; i++)
            {
                l = (Label)NecessaryInRefresh[i];
                l.Refresh();
            }
        }
        private void UsualVisibility()
        /* Возвращает к стандартному для игры свойство Visible для игровых элементов. */
        {
            this.Question.Visible = true;
            this.Galkin.Visible = false;
            this.Text_NO.Visible = false;
            this.Text_OK.Visible = false;
            this.Text_Sparta.Visible = false;
            this.Batan.Visible = false;
            this.GroupZal.Visible = false;
            this.Answer1.Visible = true;
            this.Answer2.Visible = true;
            this.Answer3.Visible = true;
            this.Answer4.Visible = true;
        }
        private void ResetButtonText()
        /* Возвращает вид кнопок к стандартному. */
        {
            for (int i = 0; i < 4; i++)
            {
                if (Answers[i].Text.Contains("A: "))
                {
                    Answers[i].ResetText();
                    Answers[i].Text = "A: ";
                }
                if (Answers[i].Text.Contains("B: "))
                {
                    Answers[i].ResetText();
                    Answers[i].Text = "B: ";
                }
                if (Answers[i].Text.Contains("C: "))
                {
                    Answers[i].ResetText();
                    Answers[i].Text = "C: ";
                }
                if (Answers[i].Text.Contains("D: "))
                {
                    Answers[i].ResetText();
                    Answers[i].Text = "D: ";
                }
            }
        }
        private void DisableAllButtons()
        /* Во избежание ошибок / Exception`ов перед генерацией вопросов вырубаю все кнопки. 
         * После генерации кнопки становятся Enable снова. */
        {
            for (int i = 0; i < 4; i++)
            {
                Answers[i].Enabled = false;
            }
            this.fifty_fifty.Enabled = false;
            this.button_call.Enabled = false;
            this.button_help.Enabled = false;
            this.button_exit.Enabled = false;
            this.button_new.Enabled = false;
            this.button_stop.Enabled = false;

        }
        private void EnableAllButtons()
        /* После генерации можно вернуть кнопки. */
        {
            for (int i = 0; i < 4; i++)
            {
                Answers[i].Enabled = true;
            }
            if(flag_a)
                this.fifty_fifty.Enabled = true;
            if(flag_b)
                this.button_call.Enabled = true;
            if(flag_c)
                this.button_help.Enabled = true;
            this.button_exit.Enabled = true;
            this.button_new.Enabled = true;
            this.button_stop.Enabled = true;
        }
        private void NoModal(int result)
        /* Если пользователь выиграл - выскакивает немодальное окно с поздравлениями.
         * Если пользователь проиграл - выскакивает немодальное окно с соболезнованиями. */
        {
            GameReset();
            if (end != null) end.Close();
            end = new WinForm(result, uindex);
            end.Show();
        }


        // Обработчики
        private void Form1_Load(object sender, EventArgs e)
        {
            _methodPreGame();
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            if (Millioner.Ingame)
            {
                this.AddStripMenuItem.Enabled = false;
                this.ModifyStripMenuItem.Enabled = false;
                this.RemoveStripMenuItem.Enabled = false;
            }
            else
            {
                this.AddStripMenuItem.Enabled = true;
                this.ModifyStripMenuItem.Enabled = true;
                this.RemoveStripMenuItem.Enabled = true;
            }
            this.Refresh();
        }
        // Кнопки-подсказки
        private void fifty_fifty_Click(object sender, EventArgs e)
        {
            _methodHelp_MinusTwo();
        }
        private void button_call_Click(object sender, EventArgs e)
        {
            _methodHelp_Call();
        }
        private void button_help_Click(object sender, EventArgs e)
        {
            _methodHelp_Hall();
        }
        // Основные кнопки
        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }
        private void button_stop_Click(object sender, EventArgs e)
        {
            _methodStop();
        }
        private void button_new_Click(object sender, EventArgs e)
        {
            try
            {
                _methodStart(); // Старт для отладки. (Каждый долбанный раз вижу эту строку)
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        private void HowToPlayStripMenuItem_Click(object sender, EventArgs e)
        {
            _methodHowToPlay();
        }
        // Варианты ответов
        private void Answer1_Click(object sender, EventArgs e)
        {
            _methodVariant1();
        }
        private void Answer2_Click(object sender, EventArgs e)
        {
            _methodVariant2();
        }
        private void Answer3_Click(object sender, EventArgs e)
        {
            _methodVariant3();
        }
        private void Answer4_Click(object sender, EventArgs e)
        {
            _methodVariant4();
        }
        // Обоработчики администраторского режима
        private void AddQuestion(object sender, EventArgs e)
        {
            _methodAddQuestion();
        }
        private void ModifyQuestion(object sender, EventArgs e)
        {
            _methodModifyQuestion();
        }
        private void RemoveQuestion(object sender, EventArgs e)
        {
            _methodRemoveQuestion();
        }
        private void ShowCorrectAnswers(object sender, EventArgs e)
        {
            _methodShowCorrectAnswers();
        }
        private void Save_Menu_Click(object sender, EventArgs e)
        {
            _methodSave();
        }
        private void Load_Menu_Click(object sender, EventArgs e)
        {
            _methodLoad();
        }

        // Обработчики для других потоков
        private void RefreshView()
        /* Подсвечивает текущий уровень, на котором находится пользователь.
         * Обновляет вид кнопок, диалогов и картинок.
         * В случае завершения игры выдаёт диалог с поздравлениями/соболезнованиями. */
        {
            Action Act = delegate
            {
                try
                {
                    // Победа / Поражение
                    if (obj.Game == won)
                    { 
                        SoundPlayer player = new SoundPlayer();
                        player.SoundLocation = "Sounds/winner.wav";
                        player.Play();
                        NoModal(won);
                    }
                    if (obj.Game == losed)
                    {
                        SoundPlayer player = new SoundPlayer();
                        player.SoundLocation = "Sounds/gong.wav";
                        player.Play();
                        NoModal(losed);
                    }

                    // Levels
                    uindex = obj.UIndex;
                    for (int i = 0; i < 15; i++)
                    {
                        if (i == uindex)
                            Levels[i].BackColor = System.Drawing.Color.Orange;
                        else if(i != uindex)
                            Levels[i].BackColor = System.Drawing.Color.Black;
                    }

                    // Refresh
                    UsualVisibility();
                    RefreshElements();
                }
                catch (Exception e)
                {
                        MessageBox.Show(e.Message);
                }
            };
            this.Invoke(Act);
        }
        private void Randomizing()
        /* Отдельный обработчик для обработки потока, в котором рандомизируются вопросы и ответы к ним.
         * Выполняется в цикле do { } while(n), переменная n отвечает за разрешение выполнить итерацию.
         * Если пользователь ответил на вопрос, правильно или нет, не имеет значения, 
         * то переменная принимает значение true, в остальных случаях - false. */
        {
            try
            {
                Action Act = delegate
                {
                    do
                    {
                        // DisableAllButtons();
                        RandomedQuest = new Adapted_string();
                        RandomedQuest = Array.RandomizeQuestion(Findex, count);
                        Findex = Array.Forbidden_index;
                        count++;
                        if (count == 5)
                            count = 0;
                        // EnableAllButtons();
                        this.Question.Visible = true;
                        this.Question.Text = RandomedQuest.quest;
                        SwapAnswers(RandomedQuest);
                        obj.RandomizeAllowed = false;
                    }
                    while (obj.RandomizeAllowed); // n
                };
                this.Invoke(Act);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void RightAnswer()
        /* Выскакивает Галкин и Label с надписью: "Правильно!" */
        {
            Action Act = delegate
            {
                try
                {
                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocation = "Sounds/true.wav";
                    player.Play();
                    this.Galkin.Visible = true;    
                    this.Text_OK.Visible = true;
                    this.Galkin.Refresh();
                    this.Text_OK.Refresh();
                    obj.LevelUp();
                    Thread.Sleep(1500);
                    if(obj.Game != 1)
                        obj.RandomizeAllowed = true;
                    RefreshView();
                    Randomizing();
                    CanIPressButton = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            };
            this.Invoke(Act);
        }
        private void WrongAnswer()
        /* Выскакивает Галкин и Label с надписью: "Неправильно!" */
        {
            Action Act = delegate
            {
                try
                {
                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocation = "Sounds/false.wav";
                    player.Play();
                    this.Galkin.Visible = true;
                    this.Text_NO.Visible = true;
                    this.Galkin.Refresh();
                    this.Text_NO.Refresh();
                    obj.LevelDown();
                    Thread.Sleep(1500);
                    if(obj.Game != -1)
                        obj.RandomizeAllowed = true;
                    RefreshView();
                    Randomizing();
                    CanIPressButton = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            };
            this.Invoke(Act);
        }
        private void FriendCall()
        /* Выскакивает картинка НПЦ и Label с надписью, содержащей с шансом 70% правильный ответ. */
        {
            Action Act = delegate
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = "Sounds/zvonok.wav";
                player.Play();
                this.Batan.Visible = true;
                this.Batan.Refresh();
                Random rand = new Random();
                int result = rand.Next(0, 11);
                switch (result)
                {
                    case 8:
                        this.Text_Sparta.Text = Answers[1].Text;
                        break;
                    case 9:
                        this.Text_Sparta.Text = Answers[2].Text;
                        break;
                    case 10:
                        this.Text_Sparta.Text = Answers[3].Text;
                        break;
                    default:
                        this.Text_Sparta.Text = Answers[0].Text;
                        break;
                }
                this.Text_Sparta.Visible = true;
                this.Text_Sparta.Refresh();
                Thread.Sleep(1500);
            };
            this.Invoke(Act);
        }
        private void Fifty_Fifty()
        /* Убирает 2 неправильных ответа (Привет Answers [], пригодился всё-таки)
         * и оставляет пользователю 2 варианта ответа - один правильный, другой - нет. */
        {
            Action Act = delegate
            {
                Random rand = new Random();
                int a = rand.Next(1, 4);
                int b = 0;
                while (true)
                {
                    b = rand.Next(1, 4);
                    if (b != a)
                        break;
                }
                Answers[a].Visible = false;
                Answers[b].Visible = false;
                this.Answer1.Refresh();
                this.Answer2.Refresh();
                this.Answer3.Refresh();
                this.Answer4.Refresh();
            };
            this.Invoke(Act);
        }
        private void HallHelp()
        /* Выскакивает таблица с вариантами ответа и их %, буду тупо рандомить шанс того,
         * что зал подскажет правильный ответ */
        {
            Action Act = delegate
            {
                try
                {
                    // Random
                    Random rand = new Random();
                    int right = 0, wrong = 0, wrong2 = 0, wrong3 = 0;
                    int result = 0;
                    // Хреновый рандом. Погрешность +- 10%
                    while (true)  // Рандомит right от 2 до 11
                    {
                        right = rand.Next(2, 11);
                        if (right == 2)
                        {
                            result = rand.Next(0, 101);
                            if (result < 10) // с шансом 10% число 2 останется.
                                break;
                        }
                        else if (right == 3)
                        {
                            result = rand.Next(0, 101);
                            if (result < 17) // с шансом 17% число 3 останется.
                                break;
                        }
                        else if (right > 5 && right < 7)
                        {
                            result = rand.Next(0, 11);
                            if (result < 3) // с шансом 30% число, которое больше 5 останется.
                                break;
                        }
                        else if (right > 7 && right < 9)
                        {
                            result = rand.Next(0, 101);
                            if (result < 14) // с шансом 14% число, которое больше 7 останется.
                                break;
                        }
                        else if (right == 9)
                        {
                            result = rand.Next(0, 101);
                            if (result < 7) // с шансом 7% число 9 останется.
                                break;
                        }
                        else if (right == 10)
                        {
                            result = rand.Next(0, 101);
                            if (result < 3) // с шансом 3% число 10 останется.
                                break;
                        }
                        else
                            break;
                    }
                    if (right == 9)
                    {
                        result = rand.Next(0, 3);
                        switch (result)
                        {
                            case 0: wrong = 1;
                                break;
                            case 1: wrong2 = 1;
                                break;
                            case 2: wrong3 = 1;
                                break;
                        }
                    }
                    else if (right == 10)
                    {
                        wrong = 0;
                        wrong2 = 0;
                        wrong3 = 0;
                    }
                    wrong = rand.Next(0, 11 - right);
                    if (right + wrong == 10)
                    {
                        wrong2 = 0;
                        wrong3 = 0;
                    }
                    else
                    {
                        wrong2 = rand.Next(0, 11 - right - wrong);
                        if (right + wrong + wrong2 == 10)
                            wrong3 = 0;
                        else
                            while (true)
                            { 
                                wrong3 = rand.Next(0, 11 - right - wrong - wrong2);
                                if (wrong3 != 0) break;
                            }
                    }
                    // Text
                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocation = "Sounds/zal.wav";
                    player.Play();
                    if (Answers[0].Text.Contains("A: "))
                    {
                        _Help[0].Text += Percents[right];
                        _HelpProgBar[0].Text = MyProgressBar[right];
                    }
                    if (Answers[0].Text.Contains("B: "))
                    {
                        _Help[1].Text += Percents[right];
                        _HelpProgBar[1].Text = MyProgressBar[right];
                    }
                    if (Answers[0].Text.Contains("C: "))
                    {
                        _Help[2].Text += Percents[right];
                        _HelpProgBar[2].Text = MyProgressBar[right];
                    }
                    if (Answers[0].Text.Contains("D: "))
                    {
                        _Help[3].Text += Percents[right];
                        _HelpProgBar[3].Text = MyProgressBar[right];
                    }
                    if (Answers[1].Text.Contains("A: "))
                    {
                        _Help[0].Text += Percents[wrong];
                        _HelpProgBar[0].Text = MyProgressBar[wrong];
                    }
                    if (Answers[1].Text.Contains("B: "))
                    {
                        _Help[1].Text += Percents[wrong];
                        _HelpProgBar[1].Text = MyProgressBar[wrong];
                    }
                    if (Answers[1].Text.Contains("C: "))
                    {
                        _Help[2].Text += Percents[wrong];
                        _HelpProgBar[2].Text = MyProgressBar[wrong];
                    }
                    if (Answers[1].Text.Contains("D: "))
                    {
                        _Help[3].Text += Percents[wrong];
                        _HelpProgBar[3].Text = MyProgressBar[wrong];
                    }
                    if (Answers[2].Text.Contains("A: "))
                    {
                        _Help[0].Text += Percents[wrong2];
                        _HelpProgBar[0].Text = MyProgressBar[wrong2];
                    }
                    if (Answers[2].Text.Contains("B: "))
                    {
                        _Help[1].Text += Percents[wrong2];
                        _HelpProgBar[1].Text = MyProgressBar[wrong2];
                    }
                    if (Answers[2].Text.Contains("C: "))
                    {
                        _Help[2].Text += Percents[wrong2];
                        _HelpProgBar[2].Text = MyProgressBar[wrong2];
                    }
                    if (Answers[2].Text.Contains("D: "))
                    {
                        _Help[3].Text += Percents[wrong2];
                        _HelpProgBar[3].Text = MyProgressBar[wrong2];
                    }
                    if (Answers[3].Text.Contains("A: "))
                    {
                        _Help[0].Text += Percents[wrong3];
                        _HelpProgBar[0].Text = MyProgressBar[wrong3];
                    }
                    if (Answers[3].Text.Contains("B: "))
                    {
                        _Help[1].Text += Percents[wrong3];
                        _HelpProgBar[1].Text = MyProgressBar[wrong3];
                    }
                    if (Answers[3].Text.Contains("C: "))
                    {
                        _Help[2].Text += Percents[wrong3];
                        _HelpProgBar[2].Text = MyProgressBar[wrong3];
                    }
                    if (Answers[3].Text.Contains("D: "))
                    {
                        _Help[3].Text += Percents[wrong3];
                        _HelpProgBar[3].Text = MyProgressBar[wrong3];
                    }
                    this.GroupZal.Visible = true;
                    this.GroupZal.Refresh();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            };
            this.Invoke(Act);
        }

        // Вспомогательные методы
        // Инициализация
        private void _methodPreGame()
        {
            try
            {
                this.Back_start.BackgroundImage = Properties.Resources._423;
                this.Background.BackgroundImage = Properties.Resources.mil;
                this.button_new.BackgroundImage = Properties.Resources._new;
                this.button_exit.BackgroundImage = Properties.Resources.Exit;
                this.fifty_fifty.BackgroundImage = Properties.Resources._1;
                this.button_call.BackgroundImage = Properties.Resources._2;
                this.button_help.BackgroundImage = Properties.Resources._3;
                this.Batan.BackgroundImage = Properties.Resources.zvonok;
                this.Galkin.BackgroundImage = Properties.Resources.Uhajer_za_babushkami;
                this.Level1.BackColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Кнопки Start, Stop
        private void _methodStart()
        {
            if (end != null) end.Close();
            obj = new Millioner();
            // Создания потока с обработчиком RefreshView
            ThreadStart MethodGameEv = new ThreadStart(RefreshView);
            Thread threadEv = new Thread(MethodGameEv);
            threadEv.IsBackground = false;
            threadEv.Start();
            // Создание потока с обработчиком Randomizing
            ThreadStart MethodRandom = new ThreadStart(Randomizing);
            Thread threadRand = new Thread(MethodRandom);
            threadRand.IsBackground = false;
            threadRand.Start();
        }
        private void _methodStop()
        {
            if (Millioner.Ingame)
            {
                NoModal(stopped);
            }
        }
        // Варианты ответа
        private void _methodVariant1()
        {
            if (CanIPressButton)
            {
                CanIPressButton = false;
                if (this.Answer1 == Answers[0])
                {
                    ThreadStart MethodThread = new ThreadStart(RightAnswer);
                    Thread thread = new Thread(MethodThread);
                    thread.IsBackground = false;
                    thread.Priority = ThreadPriority.Highest;
                    thread.Start();
                }
                else
                {
                    ThreadStart MethodThread = new ThreadStart(WrongAnswer);
                    Thread thread = new Thread(MethodThread);
                    thread.IsBackground = false;
                    thread.Priority = ThreadPriority.Highest;
                    thread.Start();
                }
            }
        }
        private void _methodVariant2()
        {
            if (CanIPressButton)
            {
                CanIPressButton = false;
                if (this.Answer2 == Answers[0])
                {
                    ThreadStart MethodThread = new ThreadStart(RightAnswer);
                    Thread thread = new Thread(MethodThread);
                    thread.IsBackground = false;
                    thread.Start();
                }
                else
                {
                    ThreadStart MethodThread = new ThreadStart(WrongAnswer);
                    Thread thread = new Thread(MethodThread);
                    thread.IsBackground = false;
                    thread.Start();
                }
            }
        }
        private void _methodVariant3()
        {
            if (CanIPressButton)
            {
                CanIPressButton = false;
                if (this.Answer3 == Answers[0])
                {
                    ThreadStart MethodThread = new ThreadStart(RightAnswer);
                    Thread thread = new Thread(MethodThread);
                    thread.IsBackground = false;
                    thread.Start();
                }
                else
                {
                    ThreadStart MethodThread = new ThreadStart(WrongAnswer);
                    Thread thread = new Thread(MethodThread);
                    thread.IsBackground = false;
                    thread.Start();
                }
            }
        }
        private void _methodVariant4()
        {
            if (CanIPressButton)
            {
                CanIPressButton = false;
                if (this.Answer4 == Answers[0])
                {
                    ThreadStart MethodThread = new ThreadStart(RightAnswer);
                    Thread thread = new Thread(MethodThread);
                    thread.IsBackground = false;
                    thread.Start();
                }
                else
                {
                    ThreadStart MethodThread = new ThreadStart(WrongAnswer);
                    Thread thread = new Thread(MethodThread);
                    thread.IsBackground = false;
                    thread.Start();
                }
            }
        }
        // Кнопки подсказки
        private void _methodHelp_MinusTwo()
        {
            if (Millioner.Ingame)
            {
                if (this.fifty_fifty.Enabled)
                {
                    ThreadStart MethodThread = new ThreadStart(Fifty_Fifty);
                    Thread thread = new Thread(MethodThread);
                    thread.IsBackground = false;
                    thread.Start();
                    this.fifty_fifty.BackgroundImage = Properties.Resources._4;
                    this.fifty_fifty.Enabled = false;
                    flag_a = false;
                }
            }
        }
        private void _methodHelp_Call()
        {
            if (Millioner.Ingame == true)
            {
                if (this.button_call.Enabled)
                {
                    ThreadStart MethodThread = new ThreadStart(FriendCall);
                    Thread thread = new Thread(MethodThread);
                    thread.IsBackground = false;
                    thread.Start();
                    this.button_call.BackgroundImage = Properties.Resources._5;
                    this.button_call.Enabled = false;
                    flag_b = false;
                }
            }
        }
        private void _methodHelp_Hall()
        {
            if (Millioner.Ingame)
            {
                if (this.button_help.Enabled)
                {
                    ThreadStart MethodThread = new ThreadStart(HallHelp);
                    Thread thread = new Thread(MethodThread);
                    thread.IsBackground = false;
                    thread.Start();
                    this.button_help.BackgroundImage = Properties.Resources._6;
                    this.button_help.Enabled = false;
                    flag_c = false;
                }
            }
        }
        // Меню
        private void _methodAddQuestion()
        {
            if(!Millioner.Ingame)
            {
                AddForm dialog = new AddForm();
                DialogResult res = dialog.ShowDialog();
                if (res == DialogResult.OK)
                {
                    Array.AddQuestions(dialog.ToBeAdded);
                }
            }
        }
        private void _methodModifyQuestion()
        {
            if (!Millioner.Ingame)
            {
                ModifyForm dialog = new ModifyForm(Array);
                DialogResult res = dialog.ShowDialog();
                if (res == DialogResult.OK)
                {
                    Array.EditQuestions(dialog.ToBeModified);
                }
            }
        }
        private void _methodRemoveQuestion()
        {
            if (!Millioner.Ingame)
            {
                RemoveForm dialog = new RemoveForm(Array);
                DialogResult res = dialog.ShowDialog();
                if (res == DialogResult.OK)
                {
                    Array.DeleteQuestions(dialog.ToBeDeleted);
                }
            }
        }
        private void _methodShowCorrectAnswers()
        {
            /* Если одна форма уже открыта, сначала закроем ее, 
            прежде чем открывать следующую */
            if (subj != null) subj.Close();
            subj = new AnswersForm();
            // Ещё не реализован код.
            subj.Show();
        }
        private void _methodHowToPlay()
        {
            MessageBox.Show("Действие, оно пока не реализовано и вместо этого я выдаю этот MessageBox.");
        }
        private void _methodSave()
        {
            MessageBox.Show("Действие, оно пока не реализовано и вместо этого я выдаю этот MessageBox.");
        }
        private void _methodLoad()
        {
            MessageBox.Show("Действие, оно пока не реализовано и вместо этого я выдаю этот MessageBox.");
        }
    }
}