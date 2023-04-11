class MyClass:
    i=123
    def f():
        print("hello")

x=MyClass()
x.counter=1
x.i=0
print(x.i)
print(MyClass.i)