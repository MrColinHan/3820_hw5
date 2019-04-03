---------------------------------------------------------------------------
Compiling and loading the micro-ML evaluator and parser (README.TXT)
---------------------------------------------------------------------------


--------------------
Windows Instructions
--------------------

1.
Move the whole folder containing this file (Fun) to a folder of
your choice. Here we assume that you have put it on the Desktop.

2.
To generate and compile the lexer and parser for the micro-ML language, run
the Command Prompt application. At the prompt, enter the following commands,
one at time:

   cd H:\Desktop\hw5\FunPair
   ..\bin\fslex --unicode FunLex.fsl
   ..\bin\fsyacc --module FunPar FunPar.fsy

This assumes that your Desktop folder is in drive H, which is the case for the
CS Windows server. If it is in another drive, use the name of that drive instead.

3.
To use the parser inside F# interactive, enter the following at the prompt

   #r "H:\Desktop\hw5\\bin\FsLexYacc.Runtime.dll"
   #load "H:\Desktop\hw5\FunPair\Absyn.fs"
   #load "H:\Desktop\hw5\FunPair\FunPar.fs"
   #load "H:\Desktop\hw5\FunPair\FunLex.fs"
   #load "H:\Desktop\hw5\FunPair\Parse.fs"
   #load "H:\Desktop\hw5\FunPair\Fun.fs"

   open Parse
   open Fun
   fromString "{var x = 2 + 4; x * 3}"

The last line is just an example, you can find more in file main.fsx


-----------------
MacOS instructions
-----------------
1.
Move the whole folder containing this file (hw5) to a folder of
your choice.

2.
To generate and compile the lexer and parser for the mini-ML language, run
the Terminal application. Enter the following commands at the terminal prompt,
one at time, replacing "me" with your user name:

   cd /Users/me/Desktop/hw5/FunPair
   mono ../bin/fslex.exe --unicode FunLex.fsl
   mono ../bin/fsyacc.exe --module FunPar FunPar.fsy

3.
To use the parser inside F# interactive, enter the following at its prompt,
replacing "me" with your user name.

   #r "/Users/me/Desktop/hw5/bin/FsLexYacc.Runtime.dll" ;;
   #load "/Users/me/Desktop/hw5/FunPair/Absyn.fs" ;;
   #load "/Users/me/Desktop/hw5/FunPair/FunPar.fs" ;;
   #load "/Users/me/Desktop/hw5/FunPair/FunLex.fs" ;;
   #load "/Users/me/Desktop/hw5/FunPair/Parse.fs" ;;
   #load "/Users/me/Desktop/hw5/FunPair/Fun.fs" ;;

   open Parse
   open Fun
   fromString "{var x = 2 + 4; x * 3}"

The last line is just an example, you can find more in file main.fsx
