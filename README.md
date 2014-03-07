SpellChecker
============

SpellCheckerConsole is a c# console application thats achitected 
into single responsibility, easily testable code. Each class is coded
to an interface to allow meaningful unit testing of classes using mocking
and injection techniques.

a few notes:

 - classes can be found in the Classes folder
 - interfaces can be found in the Interfaces Folder
 - Tests can be found in the test project
 - SpellChecker uses the Moq framework for unit testing as a nuget package
 - SpellChecker relies on a file called dictionary.txt in the Resources folder

