using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static IEnemy;
using static System.Net.Mime.MediaTypeNames;

//Tạo một interface tên IEnemy bao gồm các properties và methods: (Total: 4 points)
//a.Tạo 2 kiểu enum: (0.5 points)
//i.ENEMY_TYPE(enum): GOBLIN, BOSS, ORC
//ii. ATTACK_TYPE(enum): RANGE, MELEE
//b. Properties
//i. Id (long) – (0.5 points)
//ii.Name(string) – (0.5 points)
//iii.Type(ENEMY_TYPE) – (0.5 points)
//iv.Health(int) – (0.5 points)
//v.AttackType(ATTACK_TYPE) – (0.5 points)
//vi.Damage(float) - Read only property – (0.5 points)
//c.Methods
//i. void ShowInfo(); -(0.5 points)

public enum ENEMY_TYPE
{
    GOBIN,
    BOSS,
    ORC
}
public enum ATTACK_TYPE
{
    RANGE,
    MELEE
}
interface IEnemy
{

    long ID { get; set; }
    string Name { get; set; }
    ENEMY_TYPE TYPE { get; set; }
    int Health { get; set; }
    ATTACK_TYPE AttackType { get; set; }
    float Damage { get; }
    void ShowInfo();
}

//a.Triển khai(implement) inteface IEnemy ở bước 1 (2.0 points)

public class Enemy : IEnemy
{
    public long ID { get; set; }
    public string Name { get; set; }
    public ENEMY_TYPE TYPE { get; set; }
    public int Health { get; set; }
    public ATTACK_TYPE AttackType { get; set; }
    public float Damage { get; }

    public Enemy(long iD, string name, ENEMY_TYPE tYPE, int health, ATTACK_TYPE attackType, List<float> damageList)
    {
        ID = iD;
        Name = name;
        TYPE = tYPE;
        Health = health;
        AttackType = attackType;
        DamageList = damageList;
    }



    //    . Method ShowInfo() sẽ hiển Id, Name, Type, Health, AttackType và Damage
    //của student trên console. (1.0 points)
    public void ShowInfo()
    {
        Console.WriteLine("ID: {0}\t Name: {1}\t Type: {2}\t Health: {3}\t AttackType: {4}\t Damage: {5}", ID, Name, TYPE, Health, AttackType, Damage);
    }

    //c.Khai báo danh sách DamageList kiểu float (0.5 points).
    private List<float> DamageList = new List<float>();

    //d.Tạo indexer sử dụng DamageList trong bước 2c(1.5 points).
    public float this[int i]
    {
        get { return DamageList[i]; }
        set { DamageList[i] = value; }
    }

    //    Tạo method CalDamage để gán giá trị Damage bằng giá trị max của
    //DamageList. (1.0 points)
    //} 
    void CalDamage()
    {

        float Damage = DamageList[0];
        for (int i = 0; i < DamageList.Count; i++)
        {
            if (Damage < DamageList[i])
                Damage = DamageList[i];
        }

    }
}
public class Program
{
    static void Main(string[] args)
    {
        Dictionary<long, Enemy> dict = new Dictionary<long, Enemy>();

        Console.WriteLine("Please select an option");
        Console.WriteLine("—----------------------------------------");
        Console.WriteLine("1.Insert new enemy…");
        Console.WriteLine("2.Display all the enemy list…");
        Console.WriteLine("3.Calculate the enemy damage…");
        Console.WriteLine("4.Find enemy…");
        Console.WriteLine("5.Exit.");
        Console.Write("—----------------------------------------—-----");
        Console.Write("Nhap tuy chon: ");
        int key = Convert.ToInt32(Console.ReadLine());
        switch (key)
        {
            case 1:
                Console.WriteLine("Tạo 1 Enemy moi");

                var enemy = CreateEnemy();
                dict.Add(enemy.ID, enemy);
                Console.WriteLine("Da nhap thanh cong");
                Console.ReadLine();
                break;
            case 5:
                Console.WriteLine("Exi...");
                Console.ReadLine();

                return;
        }
    }

    public static Enemy CreateEnemy()
    {
        Console.Write("Nhap ID Enemy:");
        var ID = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nhap Name Enemy:");
        var Name = Convert.ToString(Console.ReadLine());
        Console.Write("Nhap TYPE Enemy:");
        var TYPE = (ENEMY_TYPE)Convert.ToInt32(Console.ReadLine());
        Console.Write("Nhap Health Enemy:");
        var Health = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nhap AttackType Enemy:");
        var ATTACK_TYPE = (ATTACK_TYPE)Convert.ToInt32(Console.ReadLine());
        Console.Write("Nhap Enemy damage count:");
        var count = Convert.ToInt32(Console.ReadLine());
        var damages = new List<float>();

        for (var i = 0; i < count; i++)
        {
            Console.Write($"Nhap Damage Enemy {i}:");
            damages.Add(Convert.ToInt32(Console.ReadLine()));
        }
        return new Enemy(ID, Name, TYPE, Health, ATTACK_TYPE, damages); ;
    }
}

