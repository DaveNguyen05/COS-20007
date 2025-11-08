class Counter: #Counter class to track individual time units.
    def __init__(self, name):
        self._name = name
        self._count = 0
    
    @property
    def ticks(self): #Get the current tick count value.
        return self._count
    
    @property
    def name(self): #Get the counter name.
        return self._name
    
    @name.setter
    def name(self, value): #Set the counter name.
        self._name = value
    
    def increment(self): #Increment the counter by 1.
        self._count += 1

    def reset(self): #Reset the counter to 0.
        self._count = 0