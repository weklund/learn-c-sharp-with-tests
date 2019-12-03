 # Iteration
 
**[You can find the completed code for this chapter here](https://github.com/weklund/learn-c-sharp-with-tests/tree/master/LearnCSharp/Solutions/Iteration.cs)**

**[and the completed tests for this chapter here](https://github.com/weklund/learn-c-sharp-with-tests/tree/master/WithTests/Solutions/IterationTests.cs)**

To do stuff repeatedly in C#, you'll need `for`.  Which is a good thing!

Let's write a test for a function that repeats a character 5 times.

There's nothing new so far, so try and write it yourself for practice.

## Write the test first

```c#
[Fact]
[Trait("Category", "Exercise")]
public void it_repeats()
{
    var expected = "aaaa";
    var actual = Iteration.Repeat("a");

    actual.Should().Be(expected);
}
```

## Try and run the test

Run in `/WithTests`

```sh 
dotnet test --filter "IterationTests&Category=Exercise" /nologo
```

And we have our compilation error

```text
Solutions/IterationTests.cs(14,36): error CS0117: 'Iteration' does not contain a definition for 'Repeat'
```

## Write the minimal amount of code for the test to run and check the failing test output

_Keep the discipline!_ You don't need to know anything new right now to make the test fail properly.

All you need to do right now is enough to make it compile so you can check your test is written well.

```c#
public static string Repeat(string character)
{
    return "";
}
```

Isn't it nice to know you already know enough C# to write tests for some basic problems? This means you can now play with the production code as much as you like and know it's behaving as you'd hope.

```text
[xUnit.net 00:00:01.16]     WithTests.IterationTests.it_repeats [FAIL]                                                                                                                                                                                                          
  X WithTests.IterationTests.it_repeats [232ms]                                                                                                                                                                                                                                 
  Error Message:
   Expected actual to be "aaaa" with a length of 4, but "" has a length of 0, differs near "" (index 0).
  Stack Trace:
     at FluentAssertions.Execution.XUnit2TestFramework.Throw(String message) in C:\projects\fluentassertions-vf06b\Src\FluentAssertions\Execution\XUnit2TestFramework.cs:line 32
   at FluentAssertions.Execution.AssertionScope.FailWith(Func`1 failReasonFunc) in C:\projects\fluentassertions-vf06b\Src\FluentAssertions\Execution\AssertionScope.cs:line 225
   at FluentAssertions.Primitives.StringEqualityValidator.ValidateAgainstLengthDifferences() in C:\projects\fluentassertions-vf06b\Src\FluentAssertions\Primitives\StringEqualityValidator.cs:line 31
   at FluentAssertions.Primitives.StringValidator.Validate() in C:\projects\fluentassertions-vf06b\Src\FluentAssertions\Primitives\StringValidator.cs:line 41
   at FluentAssertions.Primitives.StringAssertions.Be(String expected, String because, Object[] becauseArgs) in C:\projects\fluentassertions-vf06b\Src\FluentAssertions\Primitives\StringAssertions.cs:line 41
   at WithTests.IterationTests.it_repeats() in /Users/weseklund/Projects/c-sharp/LearnCSharpWithTests/WithTests/IterationTests.cs:line 16
                                                                                                                                                                                                                                                                                
Test Run Failed.
Total tests: 1
     Failed: 1
```

## Write enough code to make it pass

The `for` syntax is very unremarkable and follows most C-like languages.

```c#
public static string Repeat(string character)
{
    var repeated = "";

    for (var i = 0; i < 4; i++)
    {
        repeated = repeated + character;
    }

    return repeated;
}
```

## Refactor

Now it's time to refactor and introduce another construct `+=` assignment operator.

```c#
private const int RepeatCount = 3;

public static string Repeat(string character)
{
    var repeated = "";

    for (var i = 0; i < 4; i++)
    {
        repeated += character;
    }

    return repeated;
}
```

`+=` the Add AND assignment operator, adds the right operand to the left operand and assigns the result to left operand. It works with other types like integers.

## Practice exercises

* Change the test so a caller can specify how many times the character is repeated and then fix the code

## Wrapping up

* More TDD practice
* Learned `for`
