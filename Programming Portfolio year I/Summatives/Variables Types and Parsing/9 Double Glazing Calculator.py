print("Double Glazing Cost Calculator")
height = int(input("What is the height of the window in cm?: "))
width = int(input("What is the width of the window in cm?: "))
wood = 3
glass = 40
woodCost =((height * 2) + (width * 2))/100 * wood
glassCost = (height/100 * width/100) * 2 * glass
totalCost = woodCost + glassCost
print(f"A widow that is {height}cm tall and {width}cm wide will cost total of {totalCost}")