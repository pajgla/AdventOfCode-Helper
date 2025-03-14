This is a very simple program that can help you organize and quickly run C# solutions for Advent of Code.

<h1>How to use</h1>
- Create your solution .cs file in Solution directory <i>(AoCHelper/Solutions)</i><br>
- Use root namespace <b>AoCHelper</b><br>
- Create a new Solver for your solution and add a <b>Solver</b> attribute to it with a corresponding year and day properties<br>
- Create your solution class with that will derive from <b>BaseSolution</b> class<br>
- Override <b>Initialize</b>, <b>Reset</b> methods and <b>Solve</b> methods<br>
- Create a .txt and name it <b>Input</b> (case sensitive) in the same directory as your solution. Paste the input provided from the Advent of Code website there. It will be used to feed your solution with a proper input.<br>
<br>
You can take a look at the example class <b>SolutionExample</b> to better understand the solution template<br>
<br>
Run the <b>AoCHelper</b> program and write year and day of the advent of code problem. For example "2024 11".<br>
<br>
AoCHelper will search for a Solver that has correct year and day set in the Solver attribute.<br>
<br>
<h1>How to use BaseSolution method overrides</h1>
BaseSolution class has 3 abstract methods: Initialize, Reset and Solve.<br>
<br>
- <b>Initialize</b>: Used to initialize your solution/program. You will be provided with ESolutionPart enum that you can use to determine which part of the excercise your program will run. If the excercise requires different configurations, you can easily tweak your solution there.<br>
-  <b>Reset</b>: Used to reset your program after one part of the excercise is done. You should reset any member variables from your class, so the values do not get reused in the next part.<br>
- <b>Solve</b>: Used to solve the problem. You are provided with the input as an argument. At the end, you should return the solution as string.<br>
- You can also use <b>DebugPrint</b> method which will print debug info if you enable it before starting the solution.<br>
