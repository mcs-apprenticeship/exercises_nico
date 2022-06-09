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

