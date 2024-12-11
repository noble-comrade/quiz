Console.Write("Сколько игроков будет играть? >> ");
int players = Convert.ToInt32(Console.ReadLine());
bool response;
Person[] persons = new Person[players];

Question[] q = new Question[11];
q[0] = new Question("Какого объекта нет на рабочем столе компьютера?", "панель задач", "корзина", "панель управления", "сетевое окружение", "3");
q[1] = new Question("Какая единица измерения не относится к измерению информации?", "бит", "герц", "байт", "бод", "2");
q[2] = new Question("Каких компьютеров не бывает?", "планшетных", "портфельных", "карманных", "портативных", "2");
q[3] = new Question("Кто является основателем компании Microsoft?", "Марк Цукерберг", "Билл Клинтоно", "Стив Джобс", "Билл Гейтс", "4");
q[4] = new Question("Какое количесвто информации потребуется для кодирования одного из 256 символов?", "8 байтов", "10 байтов", "1 байт", "1 бит", "3");
q[5] = new Question("Какого свойства информации не существует?", "дискретность", "результативность", "детерминированность", "турбулентность", "4");
q[6] = new Question("Какое понятие объединяет камень, папирус, бересту, книгу и дискету?", "носитель информации", "историческая ценность", "природное происхождение", "создано человеком", "1");
q[7] = new Question("Как называют пользователя, который путешествует по всемирной паутине?", "сёрфер", "блоггер", "спаммер", "диггер", "1");
q[8] = new Question("Как называется электронная схема для управления внешними устройствами?", "плоттер", "контролер", "сканер", "драйвер", "2");
q[9] = new Question("Кто является Отцом Интернета?", "Тим Бернер", "Марк Цукерберг", "Билл Гейтс", "Винтон Сёрф", "4");
q[10] = new Question("Какая компания не производит процессоры?", "Intel", "Microsoft", "AMD", "Motorola", "2");

for (int i = 0; i < players; i++) 
{
    Console.Write($"Введите имя и возраст {i+1}-го игрока(через пробел) >> ");
    string[] n = Console.ReadLine().Split();
    persons[i] = new Person(n[0], n[1]);
}
foreach (Person player in persons) 
{
    Console.WriteLine($" ---- Отвечает {player.GetName()}! ---- ");
    for (int i = 0; i < 5; i++) 
    {
        Console.WriteLine($"Вопрос №{i+1}:");
        Question quest = q[new Random().Next(0,q.Length)];
        response = quest.GetQuest();
        if (response == true) { Console.WriteLine("Верно!\n"); player.SetCount(); }
        else Console.WriteLine("Не верно!\n");
    }
}

Console.WriteLine("Результат:");
foreach (Person player in persons) { Console.WriteLine($"{player.GetFullInfo()}"); }

class Question 
{
    private string quest, answer1, answer2, answer3, answer4, rightAnswer;
    public Question(string quest, string answer1, string answer2, string answer3, string answer4, string rightAnswer) 
    {
        this.quest = quest;
        this.answer1 = answer1;
        this.answer2 = answer2;
        this.answer3 = answer3;
        this.answer4 = answer4;
        this.rightAnswer = rightAnswer;
    }
    public bool GetQuest() 
    {
        Console.Write($"{quest}\n1) {answer1}\n2) {answer2}\n3) {answer3}\n4) {answer4}\nВведите цифру >> ");
        string res = Console.ReadLine();
        if ( res != rightAnswer ) return false;
        else return true;
    }
}
class Person 
{
    private string name, age;
    private int count = 0;
    public Person(string name, string age) { this.name = name; this.age = age; }
    public void SetCount() => count++;
    public int GetCount() { return count; }
    public string GetName() { return name; }
    public string GetFullInfo() { return $"{name}, {age} лет -- {count} баллов;"; }
}