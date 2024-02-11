unsafe
{
  // Number of integers.
  const int size = 5;

  // Allocate a block of memory on the stack.
  // numbers is a pointer to the first element of the block.
  int* numbers = stackalloc int[size];

  // Initialize the array.
  for (int i = 0; i < size; i++)
  {
    *(numbers + i) = i + 1;
  }

  // Sum the array using pointer arithmetic.
  int sum = 0;
  for (int* ptr = numbers; ptr < numbers + size; ptr++)
  {
    sum += *ptr; // Dereference the pointer to get the value.
  }

  WriteLine($"The sum is: {sum}");
}
