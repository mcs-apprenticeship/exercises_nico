# Objektorienttierte Programmierung

## Switch

```c#
int myNumber = 2;
    switch(myNumber){
      case 1:
        //doSomething
        break;
      case 2:
      case 3:
        //is Executed when myNumber is either 2 or 3
        //doSomething 
        break;
      default:
        //doSomething
        break;
    }
```

```c#
int myNumber1 = -2;
int myNumber2 = 2;
Console.WriteLine(myNumber1 switch
{
    (< 0) => "negative",
    0 => "zero",
    (> 0) => "positive",
});

Console.WriteLine(myNumber2 switch
{
    (< 0) => "negative",
    0 => "zero",
    (> 0) => "positive",
});

//result:
negative
positive
```

## Functions

```C#
public static double Sum (params int[] numbers){
    return numbers.Sum();
  }

  public static void Main()
  {
    Console.WriteLine(Sum(1, 2, 3, 4));
  }
```

Tower of Hanoi
```C#
private void moveTowers (int amountOfPlates, char from, char to, char other)
    {
        if(amountOfPlates == 0)
        {
            return;
        }
        if(amountOfPlates == 1)
        {
            Console.WriteLine($"move from {from} to {to}");
            return;
        }
        ```

![[Pasted image 20220609162319.png]]
to
![[Pasted image 20220609162359.png]]

```
        moveTowers(amountOfPlates - 1, from, other, to);
```
![[Pasted image 20220609162359.png]]
to
![[Pasted image 20220609162448.png]]
```
        moveTowers(1, from, to, other);
```
![[Pasted image 20220609162448.png]]
to
![[Pasted image 20220609162520.png]]
```
        moveTowers(amountOfPlates - 1, other, to, from);
    }
```