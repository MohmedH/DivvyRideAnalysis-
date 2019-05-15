# DivvyRideAnalysis-
Divvy Ride Analysis In F#

The goal in this assignment is to input ride data for one day, and perform some analysis of the data: # of rides, the % of riders that identify as male and female, the average ride duration, etc.

For divvy1.csv: 

• 243 riders

• 177 identified as male (72.84%)

• 45 identified as female (18.52%)

• Average rider’s age: 38.99

• Histogram of ride durations

• Histogram of starting hour


When computing the histogram of ride durations, the categories are the following:

	  0 < duration <= 30 minutes
  
	  30 < duration <= 60 minutes
  
	  60 < duration <= 120 minutes
  
	  120 < duration <= 24 hours
  
The “Ride Start Time” histogram categorizes the rides based on their start time (0 => midnight, 1 => 1am, … and 23 => 11pm). The number of stars output = # of rides starting that hour / 10. For example, there were 37 rides starting in the 8am hour. So the histogram display for 8am is 3 stars followed by the count: ***37.

EX OUT PUTS:

<img width="649" alt="Screen Shot 2019-05-15 at 7 48 20 AM" src="https://user-images.githubusercontent.com/23105576/57776756-e8fd1800-76e5-11e9-8c9d-30898efc2275.png">
<img width="408" alt="Screen Shot 2019-05-15 at 7 48 34 AM" src="https://user-images.githubusercontent.com/23105576/57776759-e995ae80-76e5-11e9-8ef0-27b89ba6ece0.png">
