(*
  Make sure you regenerate the Parser and Lexer
  every time you modify FunLex.fsl or FunPar.fsy

*)

// Windows example
#r "H:\Desktop\hw5\\bin\FsLexYacc.Runtime.dll"
#load "H:\Desktop\hw5\Fun\Absyn.fs"
#load "H:\Desktop\hw5\Fun\FunPar.fs"
#load "H:\Desktop\hw5\Fun\FunLex.fs"
#load "H:\Desktop\hw5\Fun\Parse.fs"
#load "H:\Desktop\hw5\Fun\Fun.fs"


// Mac Os example
#r "/Users/hbarbosa/Desktop/hw5/bin/FsLexYacc.Runtime.dll"
#load "/Users/hbarbosa/Desktop/hw5/Fun/Absyn.fs"
#load "/Users/hbarbosa/Desktop/hw5/Fun/FunPar.fs"
#load "/Users/hbarbosa/Desktop/hw5/Fun/FunLex.fs"
#load "/Users/hbarbosa/Desktop/hw5/Fun/Parse.fs"
#load "/Users/hbarbosa/Desktop/hw5/Fun/Fun.fs"

// Linux example
#r "/home/hbarbosa/Desktop/hw5/bin/FsLexYacc.Runtime.dll"
#load "/home/hbarbosa/Desktop/hw5/Fun/Absyn.fs"
#load "/home/hbarbosa/Desktop/hw5/Fun/FunPar.fs"
#load "/home/hbarbosa/Desktop/hw5/Fun/FunLex.fs"
#load "/home/hbarbosa/Desktop/hw5/Fun/Parse.fs"
#load "/home/hbarbosa/Desktop/hw5/Fun/Fun.fs"

open Absyn

let fromString = Parse.fromString // string parser function
let eval = Fun.eval               // Micro-ML interpreter
let run = Fun.run                 // execution function



(* Examples in concrete syntax *)

let e1 = fromString "
[fun next y = y + 1;
 next 6
]
"
run e1

let e2 = fromString "
[var y = 4;
 [fun f x = if x = 0 then 0 else x + f (x-1);
  f y
 ]
]
"
run e2

let e3 = fromString "
[fun f x = x + 1 ;
 [fun g x = 2 * x ;
  (f 2) + (g 5)
 ]]
"
run e3

let e4 = fromString "
 [fun fact x =
    if x = 0 then 1
    else x * fact (x - 1) ;
  fact n
 ]
"
eval e4 [("n", Fun.Int 4)]

let e5 = fromString "
 [var x = true;
  if x then 10 else 20
 ]
"
run e5

let e6 = fromString "
 [var in = 5;
  [fun f x = if in < 0 then -1 else if in = 0 then 0 else 1;
   f in
  ]
 ]
"
run e6

let e7 = fromString "
[var let = 100; [var end = let + 1; end]]
"
run e7


let ex1 = fromString "[var x = 5+7; x]"
run ex1

let ex2 = fromString "[ fun f x = x + 7; f 2 ]"
run ex2

let ex3 = fromString "[ var y = 5; [fun f1 x = x + y; f1 22 ] ]"
run ex3

let ex4 = fromString "
  [ var y = 11 ;
    [ fun f x = x + y ;
      [ var y = 22 ;
        f 3
      ]
    ]
  ]
"
run ex4


let ex5 = fromString "
[ fun inc x = x + 1;
  [ fun fib n =
    [ fun ge2 x = 1 < x ;
      if ge2 n then fib (n-1) + fib (n-2) else 1
    ] ;
  fib 25
  ]
]
"
run ex5


let ex6 = fromString "
  [ fun f x =
    [ fun g y = 2 * y ;
      (g x) + 1
    ]
  ;
    f 3
  ]
"
run ex6


let ex7 = fromString "
[ fun f x = x + 1
  ;
  [ fun g y = 2 * y ;
      (g (f 4)) + 1
  ]
]
"
run ex7
