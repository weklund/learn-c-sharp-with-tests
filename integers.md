# Integers

**[You can find the completed code for this chapter here](https://github.com/weklund/learn-c-sharp-with-tests/tree/master/LearnCSharp/Solutions/Integers.cs)**

**[and the completed tests for this chapter here](https://github.com/weklund/learn-c-sharp-with-tests/tree/master/WithTests/Solutions/IntegersTests.cs)**

Integers work as you would expect. Let's write an add function in to try things out.

## Write the test first

In `WithTests/IntegersTests.cs`

```c#
[Fact]
[Trait("Category", "Exercise")]
public void it_adds()
{
    var expected = 4;
    var actual = Integers.Add(2, 2);

    actual.Should().Be(expected);
}
``` 

## Try and run the test

Run the test 

```sh
dotnet test --filter "IntegersTests&Category=Exercise" /nologo 
```

Inspect the compilation error

```text
IntegersTests.cs(14,35): error CS0117: 'Integers' does not contain a definition for 'Add' 
```

## Write the minimal amount of code for the test to run and check the failing test output

Write enough code to satisfy the compiler _and that's all_ - remember we want to check that our tests fail for the correct reason.

```c#
public static int Add(int numberOne, int numberTwo)
{
    return 0;
}
```

Now run the tests and we should be happy that the test is correctly reporting what is wrong.

```text
[xUnit.net 00:00:01.69]     WithTests.IntegersTests.it_adds [FAIL]                                                                                                                                                                                                                         
  X WithTests.IntegersTests.it_adds [287ms]                                                                                                                                                                                                                                                
  Error Message:
   Expected actual to be 4, but found 0.
  Stack Trace:
     at FluentAssertions.Execution.XUnit2TestFramework.Throw(String message) in C:\projects\fluentassertions-vf06b\Src\FluentAssertions\Execution\XUnit2TestFramework.cs:line 32
   at FluentAssertions.Execution.AssertionScope.FailWith(Func`1 failReasonFunc) in C:\projects\fluentassertions-vf06b\Src\FluentAssertions\Execution\AssertionScope.cs:line 225
   at FluentAssertions.Numeric.NumericAssertions`1.Be(T expected, String because, Object[] becauseArgs) in C:\projects\fluentassertions-vf06b\Src\FluentAssertions\Numeric\NumericAssertions.cs:line 51
   at WithTests.IntegersTests.it_adds() in /Users/weseklund/Projects/c-sharp/LearnCSharpWithTests/WithTests/IntegersTests.cs:line 16
                                                                                                                                                                                                                                                                                           
Test Run Failed.
Total tests: 1
     Failed: 1
```

If you have noticed we learnt about _named return value_ in the [last](hello-world.md) section but aren't using the same here. It should generally be used when the meaning of the result isn't clear from context, in our case it's pretty much clear that `Add` function will add the parameters. You can refer [this](https://github.com/golang/go/wiki/CodeReviewComments#named-result-parameters) wiki for more details.

## Write enough code to make it pass

In the strictest sense of TDD we should now write the _minimal amount of code to make the test pass_. A pedantic programmer may do this

```c#
public static int Add(int numberOne, int numberTwo)
{
    return 4;
}
```

Ah hah! Foiled again, TDD is a sham right?

We could write another test, with some different numbers to force that test to fail but that feels like a game of cat and mouse.

Once we're more familiar with Go's syntax I will introduce a technique called Property Based Testing, which would stop annoying developers and help you find bugs.

For now, let's fix it properly

```c#
public static int Add(int numberOne, int numberTwo)
{
    return numberOne + numberTwo;
}
```


## Wrapping up

What we have covered:

* More practice of the TDD workflow
* Integers, addition
