The demo from this nice article : https://www.c-sharpcorner.com/UploadFile/damubetha/solid-principles-in-C-Sharp/

The following are the design flaws that cause dammage to software, mostly : 
1- Putting more stress to the classes by adding more responsabilities to them (a lot of functionality not related to the classe)
2- Forcing the classes to depend to eachother (a change in one classe affect the other class)
3- Spreading duplicate code in the system/application.

Solution : 
----------
1- Choosing the correct architecture (MVC, 3-tier, Layered, MVP, MVVP, and so on).
2- Following Design Principles.
3- Choosing the correct Design Patterns to build the software based on its specifications.

SOLID principles are the design principles that enable us to manage software design problems. Robert Martin compiled these
principles in the 1990s. These principles provide us with ways to move from tightly coupled code and tightled encapsulation
to the desired software results of loosly coupled

SOLID is an acronym of the following : 
S : Single Responsibility Principle
O : Open Closed Principle
L : Liskov Substitution Principle
I : Interface Segregation Principle
D : Dependency Inversion Principle

1) Single Responsability Principle : 
************************************
SRP says "Every Software should have one reason to change". this means that every class or structure in your code should have only
one job.
Everything in the class should be related to a single purpose. 
Example : UserService class contains 3 methods : Register, ValidateEmail and SendEmail
This case doesn't repect SRP because ValidateEmail and SendEmail have nothing to do within the class UserService.
To refract it :  We create an other classe related to email : EmailServices where we put ValidateEmail and Send Email.

2) Open/Closed Principle : 
**************************
OCP says "A software Module/Class should be open for extension and closed for modification"
Example : Rectangle Class and AreaCalculator class (That contains TotalArea() method)

public class Rectangle{
   public double Height {get;set;}
   public double Wight {get;set; }
}
public class AreaCalculator {
   public double TotalArea(Rectangle[] arrRectangles)
   {
      double area;
      foreach(var objRectangle in arrRectangles)
      {
         area += objRectangle.Height * objRectangle.Width;
      }
      return area;
   }
}

We can extend our app so it can calculate not only the total area of the rectangle but also another shape like Circle.

public class Circle{
   public double Radius {get;set;}
}
public class AreaCalculator
{
   public double TotalArea(object[] arrObjects)
   {
      double area = 0;
      Rectangle objRectangle;
      Circle objCircle;
      foreach(var obj in arrObjects)
      {
         if(obj is Rectangle)
         {
            area += obj.Height * obj.Width;
         }
         else
         {
            objCircle = (Circle)obj;
            area += objCircle.Radius * objCircle.Radius * Math.PI;
         }
      }
      return area;
   }
}

Everytime, we introduce a new shape, we need to alter the TotalArea method. So the AreaCalculator class is not closed for modification
=> we can do better by referring to abstractions for dependencies like interfaces or abstract classes.

public class Rectangle : Shape {
   public double Height {get;set;}
   public double Wight {get;set; }
}
public class Circle : Shape {
   public double Radius {get;set;}
}

public abstract class Shape{
    public abstract double Area();
}

public class AreaCalculator
{
   public double TotalArea(shape[] arrShape)
   {
      double area = 0;
      foreach(var obj in arrShape)
      {
         area += obj.Area()
      }
      return area;
   }
}


3) Liskov substitution Principle : 
**********************************
LSP states "You should be able to use any derived class instead of a parent class and it behave the same manner without modification"
it ensures that the derived class doesn't affect the behaviour of the parent class.
Take a look on this example https://www.c-sharpcorner.com/UploadFile/damubetha/solid-principles-in-C-Sharp/


4) Interface Segregation Principle : 
************************************
ISP states "The client should not be forced to implement interfaces they don't use". Instead of one fat interface, many small interfaces
are preferred based on groups of methods, each one serving one submodule.

Good example : https://www.c-sharpcorner.com/UploadFile/damubetha/solid-principles-in-C-Sharp/
