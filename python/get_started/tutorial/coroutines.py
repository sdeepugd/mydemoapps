async def greet(name):
    print("Hello, " + name)
    await asyncio.sleep(1)  # Simulate asynchronous I/O
    print("Goodbye, " + name)

async def main():
    await greet("Alice")
    await greet("Bob")

# Run the coroutine
import asyncio
loop = asyncio.get_event_loop()
loop.run_until_complete(main())
