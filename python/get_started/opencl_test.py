import pyopencl as cl
import numpy as np

# Define the OpenCL kernel code as a string
kernel_code = """
__kernel void add_vectors(__global float* a, __global float* b, __global float* c)
{
    int i = get_global_id(0);
    c[i] = a[i] + b[i];
}
"""

# Create the OpenCL context and command queue
ctx = cl.create_some_context()
queue = cl.CommandQueue(ctx)

# Define the size of the arrays
n = 10000000

# Create the input arrays on the CPU and fill them with data
a = np.array(range(n), dtype=np.float32)
b = np.array(range(n, 2*n), dtype=np.float32)

# Create the output array on the GPU
c = cl.Buffer(ctx, cl.mem_flags.WRITE_ONLY, a.nbytes)

# Compile the OpenCL kernel code and create the kernel function
prg = cl.Program(ctx, kernel_code).build()
add_vectors = prg.add_vectors

# Enqueue the OpenCL kernel with the input and output buffers
add_vectors(queue, a.shape, None, cl.Buffer(ctx, cl.mem_flags.READ_ONLY | cl.mem_flags.COPY_HOST_PTR, hostbuf=a),
            cl.Buffer(ctx, cl.mem_flags.READ_ONLY | cl.mem_flags.COPY_HOST_PTR, hostbuf=b),
            c)

# Copy the output data from the GPU to the CPU and print it
cl.enqueue_copy(queue, a, c)
print("Result: ", a)
