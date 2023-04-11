def parrot(voltage, state='a stiff', action='voom',**kwargs):
    print("-- This parrot wouldn't", action, end=' ')
    print("if you put", voltage, "volts through it.", end=' ')
    print("E's", state, "!")
    print(kwargs)

d = {"voltage": "four million", "state": "bleedin' demised", "a":"a","action": "VOOM","b":"c"}
parrot(**d)