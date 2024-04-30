
// 몬스터 클래스 생성
internal class Monster
{
    public int MonLevel { get; }
    public string MonName { get; }
    public int MonHp { get; }
    public int MonAtk { get; }
    public bool MonCall { get; private set; }

    public Monster(int monLevel, string monName, int monHp, int monAtk, bool monCall = false)
    {
        MonLevel = monLevel;
        MonName = monName;
        MonHp = monHp;
        MonAtk = monAtk;
        MonCall = monCall;
    }

    void ToggleBattle()
    {
        MonCall = !MonCall;
    }


    // 배틀 전과 배틀 시작 시 몬스터가 동일해야함
    public void ShowMonster(int idx)
    {
        Random random = new Random();
        int count = random.Next(1, 5); // 2. 두줄을 getrandomcount안에 넣기
        
        for (int i = 0; i < count; i++)
        {
            switch (idx) // 4.for문은 사라지게 됨
            {
                case 0:
                    Console.WriteLine($"Lv.{MonLevel} {MonName} HP {MonHp}");
                    break;
                case 1:
                    Console.WriteLine($"Lv.{MonLevel} {MonName} HP {MonHp}");
                    break;
                case 2:
                    Console.WriteLine($"Lv.{MonLevel} {MonName} HP {MonHp}");
                    break;
            }
        }
    }

}

