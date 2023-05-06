visited=[]
d=[float('inf')]*5
d[0]=0
def dijkstra(adj_matrix,node):
    visited.append(node)
    curwht=d[node]
    for neighbor,wht in enumerate(adj_matrix[node]):
        if wht != 0 and neighbor not in visited:
            print(curwht,node)
            if curwht+wht<=d[neighbor]:
                d[neighbor]=curwht+wht
    smallwht=float('inf')
    smallnode=None
    for node,wht in enumerate(d):
        #find smallest dist and not in visited
        if node not in visited and wht != float('inf'):
            if smallwht > wht:
                smallwht=wht
                smallnode=node
    if smallnode:
        print("calling node:",smallnode,visited)
        dijkstra(adj_matrix,smallnode)

adj_matrix = [
    [0, 2, 0, 3, 0],
    [2, 0, 4, 0, 0],
    [0, 4, 0, 1, 5],
    [3, 0, 1, 0, 2],
    [0, 0, 5, 2, 0]
]

start_vertex = 0
dijkstra(adj_matrix, start_vertex)
print(d)