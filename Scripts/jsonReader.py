import json

# Read the JSON data from the file
with open('players.json', 'r') as file:
    data = json.load(file)

# Convert string values of "weight" property to integers
i = 1
for player in data:
    player['id'] = i
    i = i + 1

# Write the modified data back to the JSON file with indentation
with open('players.json', 'w') as file:
    json.dump(data, file, indent=4)

# Print the length of the data
print(len(data))
