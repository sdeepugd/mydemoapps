
def special_args(arg1,arg2,/,pos_or_kwargs,*,kwa1,kwa2):
    print(arg1,arg2,pos_or_kwargs,kwa1,kwa2)

# special_args("arg1",arg2="arg2",pos_or_kwargs="pora",kwa1="kwarg1",kwa2="kwarg2")
special_args("arg1","arg2","pora","kwarg1","kwarg2")