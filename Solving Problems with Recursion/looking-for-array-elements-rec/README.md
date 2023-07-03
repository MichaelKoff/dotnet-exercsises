# Looking for Array Elements (Recursion)

An intermediate level task for practicing recursion and branches.

The task is to implement six methods using recursive algorithm.


## Get the Project

* [Open a project from your remote repository](https://docs.microsoft.com/en-us/visualstudio/get-started/tutorial-open-project-from-repo) or [get your local copy](https://docs.microsoft.com/en-us/azure/devops/repos/git/clone#clone-from-another-git-provider) with Visual Studio.


## Complete the Task

You are allowed to use [Array.Length](https://docs.microsoft.com/en-us/dotnet/api/system.array.length) and [Array.IList.Item](https://docs.microsoft.com/en-us/dotnet/api/system.array.system-collections-ilist-item) properties only. It's **not allowed** to use other static or instance methods of the [Array class](https://docs.microsoft.com/en-us/dotnet/api/system.array) or any extension method from [System.Linq namespace](https://docs.microsoft.com/en-us/dotnet/api/system.linq).

Also, avoid using loop statements (for, foreach, while, do..while) - only recursion calls. You can create your private [static methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members) or [local functions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions).

1. Implement "GetIntegersCount(int[], int[])" method in the [IntegersCounter.cs](LookingForArrayElementsRecursion/IntegersCounter.cs) file. See the method documentation and TODO.
1. Implement "GetIntegersCount(int[], int[], int, int)" method in the [IntegersCounter.cs](LookingForArrayElementsRecursion/IntegersCounter.cs) file. See the method documentation and TODO.
1. Implement "GetFloatsCount(float[], float[], float[])" method in the [FloatCounter.cs](LookingForArrayElementsRecursion/FloatCounter.cs) file. See the method documentation and TODO.
1. Implement "GetFloatsCount(float[], float[], float[], int, int)" method in the [FloatCounter.cs](LookingForArrayElementsRecursion/FloatCounter.cs) file. See the method documentation and TODO.
1. Implement "GetDecimalsCount(decimal[], decimal[][])" method in the [DecimalCounter.cs](LookingForArrayElementsRecursion/DecimalCounter.cs) file. See the method documentation and TODO.
1. Implement "GetDecimalsCount(decimal[], decimal[][], int, int)" method in the [DecimalCounter.cs](LookingForArrayElementsRecursion/DecimalCounter.cs) file. See the method documentation and TODO.


## Fix Compiler Issues

Additional style and code checks are enabled for the projects in this solution to help you maintaining consistency of the project source code and avoiding silly mistakes. [Review the Error List](https://docs.microsoft.com/en-us/visualstudio/ide/find-and-fix-code-errors#review-the-error-list) in Visual Studio to see all compiler warnings and errors.

If a compiler error or warning message is not clear, [review errors details](https://docs.microsoft.com/en-us/visualstudio/ide/find-and-fix-code-errors#review-errors-in-detail) or google the error or warning code to get more information about the issue.


## Save Your Work

* [Rebuild your solution](https://docs.microsoft.com/en-us/visualstudio/ide/building-and-cleaning-projects-and-solutions-in-visual-studio) in Visual Studio.
* Check out the [Error List window](https://docs.microsoft.com/en-us/visualstudio/ide/reference/error-list-window) for compiler errors and warnings. If you have any of those issues, **fix issues** and rebuild the solution again.
* [Run all unit tests with Test Explorer](https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer) and make sure there are **no failed unit tests**. Fix your code to [make all your unit tests GREEN](https://stackoverflow.com/questions/276813/what-is-red-green-testing).
* Review all your changes **before** saving your work.
    * Open "Changes" view in [Team Explorer](https://docs.microsoft.com/en-us/visualstudio/ide/reference/team-explorer-reference).
    * Click with your right mouse button on a modified file.
    * Click on "Compare with Unmodified" menu item to open a comparison window.
* [Stage your changes](https://docs.microsoft.com/en-us/azure/devops/repos/git/commits#stage-your-changes) and [create a commit](https://docs.microsoft.com/en-us/azure/devops/repos/git/commits#create-a-commit).
* Share your changes by [pushing them to remote repository](https://docs.microsoft.com/en-us/azure/devops/repos/git/pushing).


## See also

* .NET API
  * [Array.Length Property](https://docs.microsoft.com/en-us/dotnet/api/system.array.length)
  * [Array.IList.Item Property](https://docs.microsoft.com/en-us/dotnet/api/system.array.system-collections-ilist-item)
