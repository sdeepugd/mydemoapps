# async def greet(name):
#     print("Hello, " + name)
#     await asyncio.sleep(1)  # Simulate asynchronous I/O
#     print("Goodbye, " + name)

# async def main():
#     await greet("Alice")
#     await greet("Bob")

# # Run the coroutine
# import asyncio
# loop = asyncio.get_event_loop()
# loop.run_until_complete(main())

def greet(name):
    print(f'Hello, {name}!')
    yield   # Yield control to the caller
    print(f'Goodbye, {name}!')

# Create a generator object
greeting = greet('Alice')

print('Start')
next(greeting)  # Start coroutine by calling next() on the generator
print('Middle')
next(greeting)  # Resume coroutine by calling next() again
print('End')