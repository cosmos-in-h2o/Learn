import sys
import os
import chardet

# Get the suffixes and directory from the command line arguments
suffixes = sys.argv[1].split(",")
directory = sys.argv[2]

# Initialize a counter for total lines
total_lines = 0

# Define a function to count the lines of a file
def count_lines(file):
    with open(file, "rb") as f:
        cur_encoding = chardet.detect(f.read())["encoding"]

    # Open the file in read mode
    with open(file, "r",encoding=cur_encoding) as f:
        # Read all the lines
        lines = f.readlines()
        # Return the number of lines
        return len(lines)

# Define a function to traverse a directory and its subdirectories
def traverse_dir(dir):
    # Use a global variable to access the total lines
    global total_lines
    # Get the list of files and directories in the current directory
    items = os.listdir(dir)
    # Loop through each item
    for item in items:
        # Get the full path of the item
        path = os.path.join(dir, item)
        # If the item is a file and has one of the specified suffixes
        if os.path.isfile(path) and path.endswith(tuple(suffixes)):
            # Count the lines of the file
            lines = count_lines(path)
            # Print the file name and the number of lines
            print(f"{path}: {lines}")
            # Add the number of lines to the total lines
            total_lines += lines
        # If the item is a directory
        elif os.path.isdir(path):
            # Recursively traverse the subdirectory
            traverse_dir(path)

# Call the traverse_dir function with the given directory
traverse_dir(directory)

# Print the total number of lines
print(f"Total: {total_lines}")
