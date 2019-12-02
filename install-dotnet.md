# Install .NET Core, set up environment for productivity

The official installation instructions for .NET Core SDK are available [here](https://dotnet.microsoft.com/download).

## Installation

You can verify the installation with:

```sh
dotnet --version
```

## C# Text Editor

Editor preference is very individualistic, you may already have a preference that supports C# development. If you don't you should consider an Editor such as [Visual Studio Code](https://code.visualstudio.com).

VS Code is shipped with very little software enabled, you can enable new software by installing extensions. To add C# support you must install an extension at [C# for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)

## Running Tests

Using `dotnet test` can be very helpful in your project, and you'll be running the command very often during each project.  I personally don't like all the boilerplate it adds when running tests, so I run a paired down version:

```sh
dotnet test -v q /nologo
```

I also run only the tests I need for the particular logic I'm building, so I use filters:

```sh
dotnet test -v q --filter "HelloWorldTests&Category=Exercise" /nologo
```

**Note:** VS Code does have an extension for running tests called [.NET Core Test Explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer) which you may have success using, however I personally find that it breaks workflow having to click and wait for test, instead of just rerunning the last command in terminal.  

I also find that the runner can take about 2-3x longer than `dotnet test`

*For this testing flow to be beneficial (and fun!), you should be able to make a change to your code, and see the results from a test _within five seconds or less_*

For me personally, even five seconds is a long time.  My point is that you should iterate on your workflow to ensure your feedback loops are as quick as possible.  Keyboard shortcuts, different windows, whatever it takes.


## Refactoring and your tooling

A big emphasis of this book is around the importance of refactoring.

Your tools can help you do bigger refactoring with confidence.

You should be familiar enough with your editor to perform the following with a simple key combination:

- **Extract/Inline variable**. Being able to take magic values and give them a name lets you simplify your code quickly
- **Extract method/function**. It is vital to be able to take a section of code and extract functions/methods
- **Rename**. You should be able to confidently rename symbols across files.
- **Run tests**. It goes without saying that you should be able to do any of the above and then quickly re-run your tests to ensure your refactoring hasn't broken anything

In addition, to help you work with your code you should be able to:

- **View function signature** - You should never be unsure how to call a function in C#. Your IDE should describe a function in terms of its documentation, its parameters and what it returns.
- **View function definition** - If it's still not clear what a function does, you should be able to jump to the source code and try and figure it out yourself.
- **Find usages of a symbol** - Being able to see the context of a function being called can help your decision process when refactoring.

Mastering your tools will help you concentrate on the code and reduce context switching.

## Wrapping up

At this point you should have `dotnet` installed, an editor available and some basic tooling in place.
