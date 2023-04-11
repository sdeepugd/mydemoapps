class Point():
    x: int
    y: int
    def __init__(self,x,y) -> None:
        self.x=x
        self.y=y    

def where_is(point):
    match point:
        case Point(x=0, y=0):
            print("Origin")
        case Point(x=0, y=y):
            print(f"Y={y}")
        case Point(x=x, y=0):
            print(f"X={x}")
        case Point():
            print("Somewhere else")
        case _:
            print("Not a point")

var=0

where_is(Point(0, var))
where_is(Point(1, y=var))
where_is(Point(x=1, y=var))
where_is(Point(y=var, x=1))
