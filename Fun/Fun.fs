

module Fun

open Absyn

(* Environment operations *)

type 'v env = (string * 'v) list

let rec lookup env x =
    match env with 
    | []          -> failwith (x + " undefined")
    | (y, v) :: r -> if x = y then v else lookup r x

(* A runtime value is an integer or a function closure *)

type value = 
  | Int of int
  | Closure of string * string * expr * value env   (* (f, x, fBody, fDeclEnv) *)



let rec eval (e : expr) (env : value env) : int =
    match e with 
    | CstI i -> i
    | CstB b -> if b then 1 else 0

    | Var x  ->
      match lookup env x with
      | Int i -> i 
      | _     -> failwith "eval Var"
    
    | Prim (op, e1, e2) -> 
      let i1 = eval e1 env in
      let i2 = eval e2 env in
      match op with
      | "*" -> i1 * i2
      | "+" -> i1 + i2
      | "-" -> i1 - i2
      | "=" -> if i1 = i2 then 1 else 0
      | "<" -> if i1 < i2 then 1 else 0
      | _   -> failwith ("unknown primitive " + op)
    
    | Let (x, e1, e2) -> 
      let v = Int (eval e1 env) in
      let env2 = (x, v) :: env in
      eval e2 env2
    
    | If (e1, e2, e3) -> 
      let b = eval e1 env in
      if b <> 0 then eval e2 env else eval e3 env
    
    | Letfun (f, x, e1, e2) -> 
      let env2 = (f, Closure(f, x, e1, env)) :: env in
      eval e2 env2

    | Call (Var f, e) -> 
      let c = lookup env f in
      match c with
      | Closure (f, x, e1, fenv) ->
        let v = Int (eval e env) in
        let env1 = (x, v) :: (f, c) :: fenv in
        eval e1 env1
      | _ -> failwith "eval Call: not a function"
    
    | Call _ -> failwith "eval Call: not first-order function"


(* Evaluate in empty environment: program must have no free variables: *)

let run e = eval e []



