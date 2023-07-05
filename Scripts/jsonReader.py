import json

# Read the JSON data from the file
with open('players.json', 'r') as file:
    data = json.load(file)

# Print the first element
print(len(data))
