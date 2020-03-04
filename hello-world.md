# Hello, World

**[You can find the completed code for this chapter here](https://github.com/weklund/learn-c-sharp-with-tests/tree/master/LearnCSharp/Solutions/HelloWorld.cs)**

**[and the completed tests for this chapter here](https://github.com/weklund/learn-c-sharp-with-tests/tree/master/WithTests/Solutions/HelloWorldTests.cs)**

It is traditional for your first program in a new language to be Hello, world.

Open up `HelloWorld.cs` at `LearnCSharp/HelloWorld.cs` and you should see:

```c#
namespace LearnCSharp
{
    public static class HelloWorld
    {

        private static void Main()
        {

        }
    }
}
```

Let's break down the different pieces of our code

## Namespaces

C# uses namespaces to help organize your code and the various classes you write.

```c#
namespace LearnCSharp
```

In this project in particular, we have separated out the chapters you'll be doing from the solutions.

So in addition of seeing the `LearnCSharp` namespace, you'll also see

```c#
namespace LearnCSharp.Solutions
```

## Classes

When you write a program in C#, you use classes as a basic building block for your code.  A class will contain variables (fields) and methods that relate to a single logical unit.

```c#
public static class HelloWorld
{

}
```

Here we are a creating a `HelloWorld` class that is `public`, which means that other classes (or our tests) can reference and use this class.

## Methods

Methods(or functions) are just code blocks with various code statements in it.  Everything you do will be writing functions to do certain things in code.  In C# projects, the `Main()` function is normally an entrypoint, or the first function that gets called by the project.

```c#
public static void Main()
{

}
```

Go ahead and add to your `HelloWorld.cs` file:

```c#
using System;

namespace LearnCSharp
{
    public static class HelloWorld
    {

        public static void Main()
        {
            Console.WriteLine("Hello, World");
        }
    }
}
```

Now run the project inside the `LearnCSharp` directory:

```sh
dotnet run
```

You've just written your first program!  Congrats!  :tada:

## Using directive

When we need to reference other classes, libraries, or packages, we use the `using` directive to bring them into our file.

In this case, we need to bring in `System` so we can use the Console class and print to the terminal.

## How to test

How do you test this? It is good to separate your "domain" code from the outside world \(side-effects\). The `Console.WriteLine` is a side effect \(printing to stdout\) and the string we send in is our domain.

So let's separate these concerns so it's easier to test

```c#
using System;

namespace LearnCSharp
{
    public static class HelloWorld
    {
        public static string Greet()
        {
            return "Hello, World";
        }

        public static void Main()
        {
            Console.WriteLine(Greet());
        }
    }
}
```

We have created a new function but this time we've also put `string` in the definition. This means this function returns a `string` instead of nothing (`void`).

Now navigate to `/WithTests/HelloWorldTests.cs` where we are going to write a test for our `Greet` function

```c#
using Xunit;
using LearnCSharp;
using FluentAssertions;

namespace WithTests
{
    public class HelloWorldTests
    {
        [Fact]
        [Trait("Category", "Exercise")]
        public void it_greets()
        {
            var expected = "Hello, World";
            var actual = HelloWorld.Greet();

            actual.Should().Be(expected);
        }
    }
}
```

Now before explaining, let's just run the code. Head to your terminal and navigate to `/WithTests` then:

```sh
dotnet test -v q --filter "HelloWorldTests&Category=Exercise" /nologo
```

It should've passed! Just to check, try deliberately breaking the test by changing the `expected` string.

### Hello, YOU

Now that we have a test we can iterate on our software safely.

In the last example we wrote the test _after_ the code had been written just so you could get an example of how to write a test and declare a function. From this point on we will be _writing tests first_.

Our next requirement is to let us specify the recipient of the greeting.

Let's start by capturing these requirements in a test. This is basic test driven development and allows us to make sure our test is _actually_ testing what we want. When you retrospectively write tests there is the risk that your test may continue to pass even if the code doesn't work as intended.

```c#
public void it_greets()
{
    var expected = "Hello, Wes";
    var actual = HelloWorld.Greet("Wes");

    actual.Should().Be(expected);
}
```

Now run `dotnet test -v q --filter "HelloWorldTests&Category=Exercise" /nologo`, you should have a compilation error

```text
HelloWorldTests.cs(14,37): error CS1501: No overload for method 'Hello' takes 1 arguments
```

Reading and understanding compiler errors is really helpful in figuring out what's wrong with your program.  With just a bit of practice you'll pick up on what these errors are telling you.

In this case the compiler is telling you what you need to do to continue. We have to change our function `Greet` to accept an argument.

Edit the `Hello` function to accept an argument of type string

```c#
public static string Greet(string name)
{
    return "Hello, World";
}
```

If you try and run your tests again it will fail to compile because you're not passing an argument. Send in "World" to make it pass.

```c#
public static void Main()
{
    Console.WriteLine(Greet("World"));
}
```

**Note:** We've been running tests in _quiet_ mode with the `-v q` argument.  Once you start to write tests, you'll want to see exactly what's missing.  Remove `-v q` for more detail in the test runner.

```sh
dotnet test --filter "HelloWorldTests&Category=Exercise" /nologo
```

Here's what we see now

```text
[xUnit.net 00:00:01.10]     WithTests.HelloWorldTests.it_greets [FAIL]

X WithTests.HelloWorldTests.it_greets [174ms]
  Error Message:
   Expected actual to be
"Hello, Wes", but
"Hello, World" differs near "Wor" (index 7).
```

We finally have a compiling program but it is not meeting our requirements according to the test.

Let's make the test pass by using the name argument and concatenate it with `Hello,`

```c#
public static string Greet(string name)
{
    return "Hello, " + name;
}
```

When you run the test they should now pass. Normally as part of the TDD cycle we should now _refactor_.

### A note on source control

At this point, if you are using source control \(which you should!\) I would
`commit` the code as it is. We have working software backed by a test.

I _wouldn't_ push to master though, because I plan to refactor next. It is nice
to commit at this point in case you somehow get into a mess with refactoring - you can always go back to the working version.

There's not a lot to refactor here

### Constants

Constants are defined like so:

```c#
private const string EnglishGreetPrefix = "Hello";
```

We can now refactor our code

```c#
private const string EnglishGreetPrefix = "Hello";

public static string Hello(string name)
{
    return $"{EnglishGreetPrefix}, {name}";
}
```

After refactoring, re-run your tests to make sure you haven't broken anything.

Constants should improve performance of your application as it saves you creating the `"Hello, "` string instance every time `Hello` is called.

To be clear, the performance boost is incredibly negligible for this example! But it's worth thinking about creating constants to capture the meaning of values and sometimes to aid performance.

## Hello, world ... again

The next requirement is when our function is called with an empty string it defaults to printing "Hello, World", rather than "Hello, ".

Start by writing a new failing test

```c#
[Fact]
[Trait("Category", "Exercise")]
public void it_greets_without_a_person()
{
    var expected = "Hello, World";
    var actual = HelloWorld.Greet("");

    actual.Should().Be(expected);
}
```

Now let's fix the code, with a `if`

```c#
public static string Greet(string name)
{
    if (name == ""){
        return $"{EnglishGreetPrefix}, World";
    }

    return $"{EnglishGreetPrefix}, {name}";
}
```

If we run our tests we should see it satisfies the new requirement and we haven't accidentally broken the other functionality.

### Back to source control

Now we are happy with the code I would amend the previous commit so we only
check in the lovely version of our code with its test.

### Discipline

Let's go over the cycle again

* Write a test
* Make the compiler pass
* Run the test, see that it fails and check the error message is meaningful
* Write enough code to make the test pass
* Refactor

On the face of it this may seem tedious but sticking to the feedback loop is important.

Not only does it ensure that you have _relevant tests_, it helps ensure _you design good software_ by refactoring with the safety of tests.

Seeing the test fail is an important check because it also lets you see what the error message looks like. As a developer it can be very hard to work with a codebase when failing tests do not give a clear idea as to what the problem is.

By ensuring your tests are _fast_ and setting up your tools so that running tests is simple you can get in to a state of flow when writing your code.

By not writing tests you are committing to manually checking your code by running your software which breaks your state of flow and you won't be saving yourself any time, especially in the long run.

## Keep going! More requirements

Goodness me, we have more requirements. We now need to support a second parameter, specifying the language of the greeting. If a language is passed in that we do not recognise, just default to English.

We should be confident that we can use TDD to flesh out this functionality easily!

Write a test for a user passing in Spanish. Add it to the existing suite.

```c#
[Fact]
[Trait("Category", "Exercise")]
public void it_greets_in_spanish()
{
    var expected = "Hola, Roberto";
    var actual = HelloWorld.Greet("Roberto", "Spanish");

    actual.Should().Be(expected);
}
```

Remember not to cheat! _Test first_. When you try and run the test, the compiler _should_ complain because you are calling `Greet` with two arguments rather than one.

```text
HelloWorldTests.cs(34,37): error CS1501: No overload for method 'Greet' takes 2 arguments
```

Fix the compilation problems by adding another string argument to `Greet`

```c#
public static string Greet(string name, string language)
{
    if (name == ""){
        return $"{EnglishGreetPrefix}, World";
    }

    return $"{EnglishGreetPrefix}, {name}";
}
```

When you try to run the tests again it will complain about not passing enough arguments

```text
HelloWorld.cs(20,31): error CS7036: There is no argument given that corresponds to the required formal parameter 'language' of 'HelloWorld.Greet(string, string)'
```

Fix them by passing through empty strings. Now all your tests should compile _and_ pass, apart from our new scenario

```text
[xUnit.net 00:00:00.98]     WithTests.HelloWorldTests.it_greets_in_spanish [FAIL]
  X WithTests.HelloWorldTests.it_greets_in_spanish [172ms]
  Error Message:
   Expected actual to be
"Hola, Roberto" with a length of 13, but
"Hello, Roberto" has a length of 14, differs near "ell" (index 1).
  Stack Trace:
     at FluentAssertions.Execution.XUnit2TestFramework.Throw(String message) in C:\projects\fluentassertions-vf06b\Src\FluentAssertions\Execution\XUnit2TestFramework.cs:line 32
   at FluentAssertions.Execution.AssertionScope.FailWith(Func`1 failReasonFunc) in C:\projects\fluentassertions-vf06b\Src\FluentAssertions\Execution\AssertionScope.cs:line 225
   at FluentAssertions.Primitives.StringEqualityValidator.ValidateAgainstLengthDifferences() in C:\projects\fluentassertions-vf06b\Src\FluentAssertions\Primitives\StringEqualityValidator.cs:line 31
   at FluentAssertions.Primitives.StringValidator.Validate() in C:\projects\fluentassertions-vf06b\Src\FluentAssertions\Primitives\StringValidator.cs:line 41
   at FluentAssertions.Primitives.StringAssertions.Be(String expected, String because, Object[] becauseArgs) in C:\projects\fluentassertions-vf06b\Src\FluentAssertions\Primitives\StringAssertions.cs:line 41
   at WithTests.HelloWorldTests.it_greets_in_spanish() in /Users/weseklund/Projects/c-sharp/LearnCSharpWithTests/WithTests/HelloWorldTests.cs:line 36

Test Run Failed.
Total tests: 3
     Passed: 2
     Failed: 1
```

We can use `if` here to check the language is equal to "Spanish" and if so change the message

```c#
public static string Greet(string name, string language)
{
    if (name == ""){
        return $"{EnglishGreetPrefix}, World";
    }

    if (language == "Spanish") {
        return "Hola, " + name;
    }

    return $"{EnglishGreetPrefix}, {name}";
}
```

The tests should now pass.

Now it is time to _refactor_. You should see some problems in the code, "magic" strings, some of which are repeated. Try and refactor it yourself, with every change make sure you re-run the tests to make sure your refactoring isn't breaking anything.

```c#
private const string EnglishGreetPrefix = "Hello";
private const string SpanishGreetPrefix = "Hola";
private const string Spanish = "Spanish";

public static string Greet(string name, string language)
{
    if (name == ""){
        return $"{EnglishGreetPrefix}, World";
    }

    if (language == "Spanish") {
        return $"{SpanishGreetPrefix}, {name}";
    }

    return $"{EnglishGreetPrefix}, {name}";
}
```

### French

* Write a test asserting that if you pass in `"French"` you get `"Bonjour, "`
* See it fail, check the error message is easy to read
* Do the smallest reasonable change in the code

You may have written something that looks roughly like this

```c#
private const string EnglishGreetPrefix = "Hello";
private const string SpanishGreetPrefix = "Hola";
private const string FrenchGreetPrefix = "Bonjour";
private const string Spanish = "Spanish";
private const string French = "French";

public static string Greet(string name, string language)
{
    if (name == ""){
        return $"{EnglishGreetPrefix}, World";
    }

    if (language == "Spanish") {
        return $"{SpanishGreetPrefix}, {name}";
    }

    if (language == "French") {
        return $"{FrenchGreetPrefix}, {name}";
    }

    return $"{EnglishGreetPrefix}, {name}";
}
```

## `switch`

When you have lots of `if` statements checking a particular value it is common to use a `switch` statement instead. We can use `switch` to refactor the code to make it easier to read and more extensible if we wish to add more language support later

```c#
public static string Greet(string name, string language)
{
    if (name == ""){
        return $"{EnglishGreetPrefix}, World";
    }

    var prefix = EnglishGreetPrefix;

    switch (language) {
        case "Spanish":
            prefix = SpanishGreetPrefix;
            break;
        case "French":
            prefix = FrenchGreetPrefix;
            break;
    }

    return $"{prefix}, {name}";
}
```

Write a test to now include a greeting in the language of your choice and you should see how simple it is to extend our _amazing_ function.

### one...last...refactor?

You could argue that maybe our function is getting a little big. The simplest refactor for this would be to extract out some functionality into another function.

```c#
public static string GreetingPrefix(string language)
{
    switch (language) {
        case "Spanish":
            return SpanishGreetPrefix;
        case "French":
            return FrenchGreetPrefix;
        default:
            return EnglishGreetPrefix;
    }
}

public static string Greet(string name, string language)
{
    if (name == ""){
        return $"{EnglishGreetPrefix}, World";
    }

    return $"{GreetingPrefix(language)}, {name}";
}
```

## Wrapping up

Who knew you could get so much out of `Hello, world`?

By now you should have some understanding of:

### Some of C#'s syntax around

* Writing tests
* Declaring functions, with arguments and return types
* `if`, `const` and `switch`
* Declaring variables and constants

### The TDD process and _why_ the steps are important

* _Write a failing test and see it fail_ so we know we have written a _relevant_ test for our requirements and seen that it produces an _easy to understand description of the failure_
* Writing the smallest amount of code to make it pass so we know we have working software
* _Then_ refactor, backed with the safety of our tests to ensure we have well-crafted code that is easy to work with

In our case we've gone from `Greet()` to `Greet("name")`, to `Greet("name", "French")` in small, easy to understand steps.

This is of course trivial compared to "real world" software but the principles still stand. TDD is a skill that needs practice to develop but by being able to break problems down into smaller components that you can test you will have a much easier time writing software.









