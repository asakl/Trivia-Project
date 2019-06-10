import os

file_extensions = set(input("Please enter the file extensions to look for split with a space between: ").split(" "))
try:
    file_extensions = list(file_extensions).remove(" ")
except: pass

path = input("Please enter the path to the directory of the code: ")

files = []

lines = 0



files_read = []

largest_file = ["",0]

for r, d, f in os.walk(path):
    for file in f:
        for extension in file_extensions:
            if "." not in extension:
                extension = "." + extension
            if file.endswith(extension) and "sqlite3" not in file:
                files_read.append(os.path.join(r, file))
                lines_in_file = len(open(os.path.join(r, file), errors='ignore').read().split(('\n')))
                lines += lines_in_file
                if lines_in_file > largest_file[1]:
                    largest_file[1] = lines_in_file
                    largest_file[0] = os.path.join(r, file)
                break
print("The number of lines of code in that directory is " + str(lines))
print(largest_file)