// arr = [1,2,3,4,]
// const pi=3.14



// function f1(arr)
// {
//     f1var = "assigned"
//     console.log("arr " + arr)
// }

// function f2(){
//     f1var += "changed"
// }

// f1()
// f2()
// console.log(f1var)

// var x=5
// function f3()
// {
//     var x = 6
// }
// console.log(x)

// a=3
// b="3"

// if (a==b)
// {
//     console.log(`a==b is true`)
// }

// if (a===b)
// {
//     console.log(`a===b is true`)
// }
// else{
//     console.log(`a===b is false`)
// }

// var obj = {
//     "name":"deepak",
//     "age" : 29,
//     "skills":["java","C","python"]
// }

// console.log(obj.name)

// function nameobj(objt){
//     console.log(objt.name)
// }

// nameobj(a)


// let cat=10
// function f5(){
//     "use strict";
//     cat=100
// }
// f5()


// var magic = () =>  console.log("hello magic")
// magic()

// var vowel = {x:3.14,y:5.1,z:[1,2]}
// const {x:a,y:b,z:[a1,a2]} = vowel // a=:3.14,b=5.1,c=2
// console.log(a,b,a1)

// var vowel = {x:3.14,y:5.1,z:{v:1,g:2}}
// const {x:a,y:b,z:{v:a1,g:a2}} = vowel // a=:3.14,b=5.1,c=2
// console.log(a,b)

// const [a,x,,,y]=[1,2,3,4,5,6]

const bicycle = {
    gear:2,
    setGear(newGear){
        this.gear = newGear
    }
}
bicycle.setGear(5)