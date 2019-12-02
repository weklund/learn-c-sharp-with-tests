# Contributing

Contributions are very welcome. I hope for this to become a great home for guides of how to learn Go by writing tests. Consider submitting a PR or creating an issue which you can do [here](https://github.com/weklund/learn-c-sharp-with-tests).

## What we're looking for

* Teaching C# / .NET Core features \(e.g things like `if`, `select`, structs, methods, etc\).
* Showcase interesting functionality within the standard library. Show off how easy it is to TDD a HTTP server for instance.

If you don't feel confident to submit your own guide, submitting an issue for something you want to learn is still a valuable contribution.

## Style guide

* Always be reinforcing the TDD cycle. Take a look at the [Chapter Template](template.md).
* Emphasis on iterating over functionality driven by tests. The Hello, world example works well because we gradually make it more sophisticated and learning new techniques _driven_ by the tests. For example:
  * `Greet()` &lt;- how to write functions, return types.
  * `Greet(name string)` &lt;- arguments, constants.
  * `Greet(name string)` &lt;- default to "world" using `if`.
  * `Hello(name, language string)` &lt;- `switch`.
* Try and minimise the surface area of required knowledge.
  * Thinking of examples that showcase what you're trying to teach without confusing the reader with other features is important.
  * Brevity is king.
* Follow the [Code Review Comments style guide](https://github.com/golang/go/wiki/CodeReviewComments). It's important for a consistent style across all the sections.
* Your section should have a runnable application at the end so users can see it in action and play with it.
* All tests should pass.
