using System;
internal class Program
{
    public static void Main(string[] args)
    {
        igor igor = new igor();
        enemy enemy = new enemy();

        enemy.SetDamage(igor, 25);
        igor.SetDamage(enemy, 100);

        Console.ReadKey();
    }
}

public abstract class Character
{
    public int Health { get; private set; }

    public Character()
    {
        Health = 100;
    }

    public virtual void GetDamage(int damage)
    {
        Health -= damage;
        if (Health < 1)
        {

        }
    }

    public void SetDamage(Character character, int damage)
    {
        character.GetDamage(damage);
    }
}

public class igor : Character
{
    public override void GetDamage(int damage)
    {

        base.GetDamage(damage);
    }
}

public class enemy : Character
{
    public override void GetDamage(int damage)
    {

        base.GetDamage(damage);
    }
}
