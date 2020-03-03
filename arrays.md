 # Arrays and Lists

 **[You can find the completed code for this chapter here](https://github.com/weklund/learn-c-sharp-with-tests/tree/master/LearnCSharp/Solutions/Sum.cs)**

 **[and the completed tests for this chapter here](https://github.com/weklund/learn-c-sharp-with-tests/tree/master/WithTests/Solutions/SumTests.cs)**

Arrays allow you to store multiple elements of the same type in a variable in
a particular order.

When you have an array, it is very common to have to iterate over them. So let's
use [our new-found knowledge of `for`](iteration.md) to make a `Sum` function. `Sum` will
take an array of numbers and return the total.

Let's use our TDD skills

## Write the test first

In `/WithTests/SumTests.cs`

```c#
[Fact]
[Trait("Category", "Exercise")]
public void it_sums_any_size()
{
    var numbers = new[] {1, 2, 3};

    var expected = 6;
    var actual = Sum.Add(numbers);

    actual.Should().Be(expected);
}
```

[Arrays](https://www.geeksforgeeks.org/c-sharp-arrays/) have a _fixed capacity_ which you define when you declare the variable.
We can initialize an array in two ways:

* \[N\]type{value1, value2, ..., valueN} e.g. `var numbers = new int[5];`
* \[...\]type{value1, value2, ..., valueN} e.g. `var numbers = new[]{1, 2, 3, 4, 5, 6};`

## Try to run the test

By running `dotnet test --filter "SumTests&Category=Exercise" /nologo` we get `SumTests.cs(16,30): error CS0117: 'Sum' does not contain a definition for 'Add'`

## Write the minimal amount of code for the test to run and check the failing test output

In `/LearnCSharp/Sum.cs`

```c#
public static int Add(int[] numbers)
{
    return 0;
}
```

Your test should now fail with _a clear error message_

```text
[xUnit.net 00:00:00.83]     WithTests.SumTests.it_sums_any_size [FAIL]
  X WithTests.SumTests.it_sums_any_size [120ms]
  Error Message:
   Expected actual to be 6, but found 0.
  Stack Trace:
     at FluentAssertions.Execution.XUnit2TestFramework.Throw(String message)
   at FluentAssertions.Execution.TestFrameworkProvider.Throw(String message)
   at FluentAssertions.Execution.DefaultAssertionStrategy.HandleFailure(String message)
   at FluentAssertions.Execution.AssertionScope.FailWith(Func`1 failReasonFunc)
   at FluentAssertions.Execution.AssertionScope.FailWith(Func`1 failReasonFunc)
   at FluentAssertions.Execution.AssertionScope.FailWith(String message, Object[] args)
   at FluentAssertions.Numeric.NumericAssertions`1.Be(T expected, String because, Object[] becauseArgs)
   at WithTests.SumTests.it_sums_any_size() in /Users/weseklund/Projects/c-sharp/LearnCSharpWithTests/WithTests/SumTests.cs:line 18

Test Run Failed.
Total tests: 1
     Failed: 1
```

## Write enough code to make it pass

```c#
public static int Add(int[] numbers)
{
    var sum = 0;

    for (var i = 0; i < numbers.Length; i++)
    {
        sum += numbers[i];
    }

    return sum;
}
```

To get the value out of an array at a particular index, just use `array[index]`
syntax. In this case, we are using `for` to iterate 5 times to work through the
array and add each item onto `sum`.

## Refactor

Let's introduce [`foreach`](https://www.geeksforgeeks.org/c-sharp-foreach-loop/) to clean up our code a bit

```c#
public static int Add(int[] numbers)
{
    var sum = 0;
    foreach (var number in numbers)
    {
        sum += number;
    }

    return sum;
}
```

`foreach` lets you iterate over an array by the number of elements in that array.  It's easy to use, easy to read, and prevents off by one errors.

Our next requirement is to change `Add` to `AddTails`, where it now calculates the totals of the "tails" of each slice. The tail of a collection is all the items apart from the first one \(the "head"\)

## Write the test first

```c#
[Fact]
[Trait("Category", "Exercise")]
public void it_sums_tails()
{
    var expected = new[] {2, 9};
    var actual = Sum.AddTails(
        new[] {1, 2},
        new[] {0, 9}
    );

    actual.Should().Equal(expected);
}
```

You'll notice that we're now using `.Equal()` instead of `.Be()` in our assertion.  Fluent Assertion requires a different method to assert equality with collections of items versus a single value.

## Try and run the test

```sh
dotnet test --filter "SumTests&Category=Exercise" /nologo
```

We get

```text
SumTests.cs(26,30): error CS0117: 'Sum' does not contain a definition for 'AddTails'
```

## Write the minimal amount of code for the test to run and check the failing test output

Let's add our new method for adding up our array "tails"

```c#
public static int[] AddTails(params int[][] numbers)
{
    return new[] {0, 0};
}
```

```text
[xUnit.net 00:00:01.05]     WithTests.SumTests.it_sums_tails [FAIL]
  X WithTests.SumTests.it_sums_tails [268ms]
  Error Message:
   Expected actual to be equal to {2, 9}, but {0, 0} differs at index 0.
  Stack Trace:
     at FluentAssertions.Execution.XUnit2TestFramework.Throw(String message)
   at FluentAssertions.Execution.TestFrameworkProvider.Throw(String message)
   at FluentAssertions.Execution.DefaultAssertionStrategy.HandleFailure(String message)
   at FluentAssertions.Execution.AssertionScope.FailWith(Func`1 failReasonFunc)
   at FluentAssertions.Execution.AssertionScope.FailWith(Func`1 failReasonFunc)
   at FluentAssertions.Execution.AssertionScope.FailWith(String message, Object[] args)
   at FluentAssertions.Execution.GivenSelector`1.FailWith(String message, Object[] args)
   at FluentAssertions.Execution.GivenSelector`1.FailWith(String message, Func`2[] args)
   at FluentAssertions.Execution.GivenSelectorExtensions.AssertCollectionsHaveSameItems[TActual,TExpected](GivenSelector`1 givenSelector, ICollection`1 expected, Func`3 findIndex)
   at FluentAssertions.Collections.CollectionAssertions`2.AssertSubjectEquality[TActual,TExpected](IEnumerable expectation, Func`3 equalityComparison, String because, Object[] becauseArgs)
   at FluentAssertions.Collections.SelfReferencingCollectionAssertions`2.Equal(T[] elements)
   at WithTests.SumTests.it_sums_tails() in /Users/weseklund/Projects/c-sharp/LearnCSharpWithTests/WithTests/SumTests.cs:line 31

Test Run Failed.
Total tests: 2
     Passed: 1
     Failed: 1
```

We've also added a new C# keyword, `params`

### `params` keyword

Params allows a method to accept a variable number of arguments to be passed in as an array.   This is useful when you aren't sure how many arguments you are going to need for your method.  In our case, someone could pass as many arrays of numbers for our `AddTails` method.

## Write enough code to make it pass

```c#
public static int[] AddTails(params int[][] numbers)
{
    return new[] {2, 9};
}
```

## Refactor

Now let's make an implementation for adding tails from multiple arrays of numbers

```c#
public static int[] AddTails(params int[][] numbers)
{
    var sums = new int[numbers.Length];

    for (var i = 0; i <= sums.Length - 1; i++)
    {
        var tail = numbers[i][1..];
        sums[i] = Add(tail);
    }

    return sums;
}
```

We've also added another C# concept, slicing

### Slicing

Slicing is an easy way to fetch certain elements in an array without needing to make copy arrays.  The notation is represented within the collection and specifies the start and end indices separated by `..`.  In this example I've omitted the end index, which means it goes to the collection length:

`var tail = numbers[i][1..];`


## Refactor

Not a lot to refactor this time.

What do you think would happen if you passed in an empty array into our function? What is the "tail" of an empty array?

## Write the test first

```c#
[Fact]
[Trait("Category", "Exercise")]
public void it_sums_empty_collection()
{
    var expected = new[] {2, 9};
    var actual = Sum.AddTails(
        new int[] {},
        new[] {0, 9}
    );

    actual.Should().Equal(expected);
}
```

## Try to run the test

```text
[xUnit.net 00:00:00.76]     WithTests.SumTests.it_sums_empty_collections [FAIL]
  X WithTests.SumTests.it_sums_empty_collections [2ms]
  Error Message:
   System.ArgumentOutOfRangeException : Specified argument was out of the range of valid values. (Parameter 'length')
  Stack Trace:
     at System.Runtime.CompilerServices.RuntimeHelpers.GetSubArray[T](T[] array, Range range)
   at LearnCSharp.Sum.AddTails(Int32[][] numbers) in /Users/weseklund/Projects/c-sharp/LearnCSharpWithTests/LearnCSharp/Sum.cs:line 22
   at WithTests.SumTests.it_sums_empty_collections() in /Users/weseklund/Projects/c-sharp/LearnCSharpWithTests/WithTests/SumTests.cs:line 39

Test Run Failed.
Total tests: 3
     Passed: 2
     Failed: 1
```

Oh no! It's important to note the test has compiled, it is a runtime error. Compile time errors are our friend because they help us write software that works, runtime errors are our enemies because they affect our users.

## Write enough code to make it pass

```c#
public static int[] AddTails(params int[][] numbers)
{
    var sums = new int[numbers.Length];

    for (var i = 0; i <= sums.Length - 1; i++)
    {
        if (numbers[i].Length == 0)
        {
            sums[i] = Add(new[]{0});
        }
        else
        {
            var tail = numbers[i][1..];
            sums[i] = Add(tail);
        }
    }

    return sums;
}
```

## Wrapping up

We have covered

* Arrays
* `foreach`
* FluentAssertions `Be()` vs `Equal()`
* `params`
* Slicing
* `IEnumerable<>`
















