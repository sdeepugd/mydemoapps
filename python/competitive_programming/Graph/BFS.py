class graph():
    def __init__(self,n):
        self.g=[[0 for _ in range(n)]for _ in range(n)]

    def print_matrix(self):
        for i in self.g:
            print(i)

    def add_edge(self,src,dest):
        self.g[src][dest]=1
        self.g[dest][src]=1

    def bfsUtil(self,node):
        self.v.append(node)
        print(f"visited node {node}")
        for node,an in enumerate(self.g[node]):
            if an == 1 and node not in self.v:
                self.bfsUtil(node)

    def bfs(self):
        self.v=[]
        self.bfsUtil(0)

g=graph(5)
g.add_edge(0,1)
g.add_edge(0,2)
g.add_edge(2,1)
g.add_edge(3,1)
g.add_edge(2,4)
g.add_edge(3,4)

g.bfs()