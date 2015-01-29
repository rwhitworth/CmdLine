# CmdLine
.NET library to parse command line parameters.  Includes a demo application.

CmdLine v1.1<br>
A command line parsing library for C# / VB.Net

Ryan Whitworth<br>
lithron@gmail.com || me@ryanwhitworth.com

This software is licensed under the GPL v3.  Contact the author for additional licensing options.


Example usage:<br>
c:\nifty-program.exe /a --b -infile=input.dat /outfile="output file.dat"

Add 'using CmdLine;' to the top of the project and add this to the project:
```
CmdLineParser cmd = new CmdLineParser(Environment.CommandLine);
var results = cmd.commands;
foreach (var item in results)
{
	// do something with item.ToString()
}
```

See the included test program for more and better example code.



ChangeLog:<br>
08/01/2011 - v1.0 released<br>
08/06/2011 - v1.1 released with fixes to the parsing rules and now using regular expressions and support for "long file names"
