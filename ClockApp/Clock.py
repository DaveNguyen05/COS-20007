from Counter import Counter
class Clock:
    def __init__(self, is_24_hour=True): #Initialize clock with hour, minute, and second counters.
        self._hour = Counter("Hours")
        self._min = Counter("Minutes")
        self._sec = Counter("Seconds")
        self._is_24_hour = is_24_hour

    def get_time(self): #Return the current time as a string in hh:mm:ss format.
        h = self._hour.ticks
        display_hour = h
        
        if not self._is_24_hour: #Convert to 12-hour format if needed.
            if h == 0:
                display_hour = 12
            elif h > 12:
                display_hour = h - 12
        
        hour_str = f"{display_hour:02d}" #Build time string.
        min_str = f"{self._min.ticks:02d}"
        sec_str = f"{self._sec.ticks:02d}"
        
        time_str = f"{hour_str}:{min_str}:{sec_str}"
        
        if not self._is_24_hour: #Add AM/PM for 12-hour format.
            period = "AM" if h < 12 else "PM"
            time_str += f" {period}"
        return time_str
    
    def restart(self): #Reset all counters to zero.
        self._hour.reset()
        self._min.reset()
        self._sec.reset()
    
    def tick(self):  #Advance the clock by one second.
        self._sec.increment()
        
        if self._sec.ticks == 60: #When seconds reach 60, reset and increment minutes.
            self._sec.reset()
            self._min.increment()
        
        if self._min.ticks == 60: #When minutes reach 60, reset and increment hours.
            self._min.reset()
            self._hour.increment()
        
        if self._hour.ticks == 24: #When hours reach 24, reset.
            self._hour.reset()