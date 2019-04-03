(*
   CS:3820 Programing Language Concepts
   
   Homework 5

   Team:  
*)

(* even : int -> bool *)
let even x = (x / 2) * 2 = x

(* map: ('a -> 'b) -> 'a list -> 'b list *)
let rec map f l = 
  match l with
    | []     -> []
    | h :: t -> (f h) :: (map f t)

(* (foldL f x [x1; ...; xn])
   = (f (... (f (f x x1) x2) ...) xn)
*)
(* foldL : ('a -> 'b -> 'a) -> 'a -> 'b list *)
let rec foldL f x l =
  match l with
  | []     -> x
  | h :: t -> foldL f (f x h) t

(* (foldR f [x1; ...; xn] x)
   = (f x1 (f x2 (... (f xn x)...))))
*)
(* foldR : ('a -> 'b -> 'b) -> 'a list -> 'b -> 'b *)
let rec foldR f l x =
  match l with
  | []     -> x
  | h :: t -> f h (foldR f t x)

(* all : ('a -> bool) -> 'a list -> bool *)
let rec all p l = 
  match l with
  | []     -> true
  | h :: t -> (p h) && (all p t)

(* some : ('a -> bool) -> 'a list -> bool *)
let rec some p l = 
  match l with
  | []     -> false
  | h :: t -> (p h) || (some p t)

(* filter : ('a -> bool) -> 'a list -> 'a list *)
let rec filter p l = 
  match l with 
  | []     -> []
  | h :: t -> if (p h) then h :: (filter p t)
                       else (filter p t) 


(* vsum : (float * float) list -> float * float *)
let take_x (t: (float * float)) : float = 
  match t with 
  | (x , y) -> x

let take_y (t: (float * float)) : float = 
  match t with 
  | (x , y) -> y

let addf (x : float) (y : float) : float = 
  x + y

//map take_x [(9.8,6.1);(3.5,8.2);(0.4,0.01);(1.2,5.7)]
//foldL add 0.0 (map take_x [(2.0,6.0);(3.0,8.0);(0.4,0.01);(1.0,5.7)])

let vsum (l: (float * float) list) : float * float = 
  match l with 
  | h :: t -> ( (foldL addf 0.0 (map take_x l)) , (foldL addf 0.0 (map take_y l)))
  | []     -> failwith "The input list is empty"

// vsum [(9.8,6.1);(3.5,8.2);(0.4,0.01);(1.2,5.7)]
// vsum [(1.2,4.5)]

(* length : ’a list -> int *)

let convert_to_one l = 
  match l with 
  | _ -> 1

let addi (x : int) (y : int) : int = 
  x + y

//map convert_to_one [3;7;8;5;7;3]
//map convert_to_one ['y';'3']
// foldL addi 0 (map convert_to_one [])

let length l : int = 
  match l with 
  | []     -> 0
  | h :: t -> foldL addi 0 (map convert_to_one l)

//length [0;0;0;0;0]

(* llength : ’a list list -> int list *)


(* remove : ’a -> (’a list -> ’a list) when ’a : equality *)


(* lmin : ’a list -> ’a when 'a : comparison *)


(* isIn : ’a -> (’a list -> bool) when ’a : equality *)


(* leven : int list -> bool *)


(* append : ’a list -> ’a list -> ’a list *)


