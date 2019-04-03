(*
  Make sure you regenerate the Parser and Lexer
  every time you modify FunLex.fsl or FunPar.fsy

*)

// Windows only
#r "H:\Desktop\hw5\\bin\FsLexYacc.Runtime.dll"
#load "H:\Desktop\hw5\FunPair\Absyn.fs"
#load "H:\Desktop\hw5\FunPair\FunPar.fs"
#load "H:\Desktop\hw5\FunPair\FunLex.fs"
#load "H:\Desktop\hw5\FunPair\Parse.fs"
#load "H:\Desktop\hw5\FunPair\Fun.fs"


// Mac Os ony
#r "/Users/hbarbosa/Desktop/hw5/bin/FsLexYacc.Runtime.dll"
#load "/Users/hbarbosa/Desktop/hw5/FunPair/Absyn.fs"
#load "/Users/hbarbosa/Desktop/hw5/FunPair/FunPar.fs"
#load "/Users/hbarbosa/Desktop/hw5/FunPair/FunLex.fs"
#load "/Users/hbarbosa/Desktop/hw5/FunPair/Parse.fs"
#load "/Users/hbarbosa/Desktop/hw5/FunPair/Fun.fs"

// Linux example
#r "/home/hbarbosa/Desktop/hw5/bin/FsLexYacc.Runtime.dll"
#load "/home/hbarbosa/Desktop/hw5/FunPair/Absyn.fs"
#load "/home/hbarbosa/Desktop/hw5/FunPair/FunPar.fs"
#load "/home/hbarbosa/Desktop/hw5/FunPair/FunLex.fs"
#load "/home/hbarbosa/Desktop/hw5/FunPair/Parse.fs"
#load "/home/hbarbosa/Desktop/hw5/FunPair/Fun.fs"

open Absyn

let fromString = Parse.fromString // string parser function
let eval = Fun.eval               // Micro-ML interpreter
let run = Fun.run                 // execution function

(* Examples in concrete syntax *)

let e1 = fromString "
  let t = (1 + 2, 5 < 8)
  in
    if t#2 then t#1 else 14
  end
"
run e1


let e2 = fromString "
  let min p = if p#1 < p#2 then p#1 else p#2
  in
    min (3, 88)
  end
"
run e2

let e3 = fromString "
  let x = (1, (3, 4)) in
    x#2#1
  end
"
run e3


let e4 = fromString "
  let x = (1, 2) in
    (x, x)
  end
"
run e4


let e5 = fromString "
  let min p =
    let x = p#1 in
    let y = p#2 in
      if x < y then x else y
    end
    end
  in
    min(5, 1)
  end
"
run e5
