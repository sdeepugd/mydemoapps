# A Python program to demonstrate that a function
# can be defined inside another function and a
# function can be passed as parameter.

# Adds a welcome message to the string
def messageWithWelcome(fun):
	def wrapper(arg):
		return "something else"
	return wrapper

# To get site name to which welcome is added
@messageWithWelcome
def site(site_name):
	return site_name

print(site("GeeksforGeeks"))
