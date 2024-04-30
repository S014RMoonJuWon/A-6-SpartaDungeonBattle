internal class Player
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }
    public int Gold { get; set; }

    public Player(string name, string job, int level, int atk, int def, int hp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Gold = gold;
    }

    // 플레이어 이름 입력받는 것
    public Player()
    {
        string name = Console.ReadLine();

        while(name == null || name == string.Empty)
        {
            Console.WriteLine("잘못된 입력입니다.");
            Console.WriteLine("캐릭터 이름을 작성해주세요.");
            name = Console.ReadLine();
        }
        
        Name = name;

        Console.WriteLine("");
        Console.WriteLine($"{name}님, 환영합니다!");
        Thread.Sleep(2000); // 콘솔 클리어가 너무 빨라서 설정해둠
    }

    public Player(int min, int max)
    {
        
    }
}

