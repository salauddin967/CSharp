using System;
public class Book{
 
  public int Minus(int a, int b){
     return a - b;
   }

   public double Minus(double a, double b){
    return a - b;
   }

   public int Minus(int a, int b, int c){
    return a - b - c;
   }

  public string name;
  public int age;
  public int roll;
  public string phone;
  

  public Book(){
    name = "Default";
    age = 0;
    roll = 0;
    phone = "015**-******";
  }

  public Book(string Name, int Age, int Roll, string Phone){
    name = Name;
    age = Age;
    roll = Roll;
    phone = Phone;
  }


  public void Display(){

    Console.WriteLine(" Personal Info ");
    Console.WriteLine("Name : " + name);
    Console.WriteLine("Age : " + age);
    Console.WriteLine("Roll : " + roll);
    Console.WriteLine("Phone : " + phone);
    Console.WriteLine();

  } 

}

public class LOki{
    public static void Main(string[] args){
    
    Book man = new Book();
    man.Display();
    
    Book man1 = new Book("Salauddin", 18, 1499, "01800-000000");
    man1.Display();  

    Book sum = new Book();
    Console.WriteLine(sum.Minus(15, 9));
    Console.WriteLine(sum.Minus(71, 18, 29));
    Console.WriteLine(sum.Minus(59.34, 34.97));
    Console.WriteLine();

   }  

}