x=1
def outer():
    x=2
    def secondouter():
        x=3
        def inner():
            nonlocal x
            x=4
            print(f'inner sees x equal to {x}')
            return
        inner()
        print(f'secondouter sees x equal to {x}')
    secondouter()
    print(f'outer sees x equal to {x}')
    return 
outer()
print(f'global sees x equal to {x}')