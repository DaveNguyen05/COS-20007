from Counter import Counter
from Clock import Clock
import time
import tracemalloc

class Program: #Main program class to run the clock simulation.
    def main(self): #Determine clock format (change last_student_id as needed).
        last_student_id = 0  #Change this value: <=5 for 12-hour, >5 for 24-hour.
        is_24_hour = last_student_id > 5
        
        tracemalloc.start() #Start memory monitoring.
        
        start_time = time.time() #Start timing.

        my_clock = Clock(is_24_hour=is_24_hour) #Create clock and tick 59 times.

        for i in range(59):
            my_clock.tick()
        
        end_time = time.time() #End timing.
        execution_time = end_time - start_time
        
        print(my_clock.get_time()) #Display current time.
        
        my_clock.restart() #Restart clock and display time.
        print(my_clock.get_time())
        
        current, peak = tracemalloc.get_traced_memory() #Get memory usage.

        print("\nMemory Usage") #Display performance metrics.
        print(f"Execution Time: {execution_time:.6f} seconds")
        print(f"Current Memory Usage: {current / 1024 / 1024:.2f} MB")
        print(f"Peak Memory Usage: {peak / 1024 / 1024:.2f} MB")
        print(f"Memory Allocated: {peak / 1024:.2f} KB")

        tracemalloc.stop() #Stop memory monitoring.

if __name__ == "__main__":
    program = Program() #Create an instance first.
    program.main() #Then call the instance to run the program.