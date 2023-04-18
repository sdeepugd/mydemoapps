import threading

# Define a generator function that uses a lock
def my_generator():
    for i in range(1, 6):
        with lock:  # Acquire the lock before yielding
            yield i

# Define a function that uses the generator
def process_data(thread_id):
    for item in my_generator():
        print(f"Thread {thread_id} got item: {item}")

# Create a lock
lock = threading.Lock()

# Create three threads that call the generator function
thread1 = threading.Thread(target=process_data, args=(1,))
thread2 = threading.Thread(target=process_data, args=(2,))
thread3 = threading.Thread(target=process_data, args=(3,))

# Start the threads
thread1.start()
thread2.start()
thread3.start()

# Wait for all threads to finish
thread1.join()
thread2.join()
thread3.join()

print("All threads finished.")

