from selenium import webdriver
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.by import By
from bs4 import BeautifulSoup, NavigableString, Tag
import sys
from datetime import datetime
import re
from selenium.common.exceptions import TimeoutException
import json

# Get additional Player information for player profile on NFL.com
def checkPlayerProfile(player):	

	# Set URL given that there are no special characters
	if (('.' not in player['first_name'] and '.' not in player['last_name']) and 
		('\'' not in player['first_name'] and '\'' not in player['last_name'])):		
		url = 'https://www.nfl.com/players/' + player['first_name'] + '-' + player['last_name'] + '/'

	# convert special characters to a dash
	else:

		first_name = ''
		last_name = ''

		name_checks = ['first_name', 'last_name']

		for i in range(len(name_checks)):

			if '.' in player[name_checks[i]] or '\'' in player[name_checks[i]]:

				parts = re.split('\.|\'', player[name_checks[i]])

				if parts[0] == '':
					parts.pop(0)
				if parts[-1] == '':
					parts.pop(-1)

				for j in range(len(parts)):

					if name_checks[i] == 'first_name':
						first_name = first_name + parts[j] 

						if (j + 1) != len(parts):
							first_name = first_name + '-'
						

					elif name_checks[i] == 'last_name' and (j + 1) != len(parts):
						last_name = last_name + (parts[j] + "-")
			else:
				if name_checks[i] == 'first_name':
					first_name = player['first_name']
				elif name_checks[i] == 'last_name':
					last_name = player['last_name']

		url =  'https://www.nfl.com/players/' + first_name + '-' + player['last_name'] + '/'


	# get URL
	browser.get(url)

	# wait for data 
	timeout = False
	try:
		WebDriverWait(browser, 20).until(EC.visibility_of_all_elements_located((By.CLASS_NAME, "nfl-c-player-info__content")))
	except TimeoutException:
		timeout = True
	if not timeout:
		

		soup = BeautifulSoup(browser.page_source, "html.parser")

		# get desired data
		content = soup.find("div", {"class" : "nfl-c-player-info__content"})
		data = content.findAll("div")
		m = data


		for i in range(len(m)):
			if m[i].text == "Height" and m[i+1].text != '':
				player['height'] = m[i+1].text 
			elif m[i].text == "Weight" and m[i+1].text != '':
				player['weight'] = m[i+1].text 
			elif m[i].text == "Arms" and m[i+1].text != '':
				player['arms'] = m[i+1].text 
			elif m[i].text == "Hands" and m[i+1].text != '':
				player['hands'] = m[i+1].text 
			elif m[i].text == "Age" and m[i+1].text != '':
				player['age'] = int(m[i+1].text)


# Get additional Player information for player combin3profile 
def checkPlayerCombineProfile(player, year):	

	url = player['player_info']

	browser.get(url)

	timeout = False

	try: 
		if year > 2021:
			WebDriverWait(browser, 20).until(EC.visibility_of_all_elements_located((By.CLASS_NAME, "css-moz91h")))
		else:
			WebDriverWait(browser, 20).until(EC.visibility_of_all_elements_located((By.CLASS_NAME, "css-k9c8dc")))
	except TimeoutException:
		timeout = True

	if not timeout:

		soup = BeautifulSoup(browser.page_source, "html.parser")

		if year > 2021:

			info = soup.find("div", {"class" : "css-moz91h"})

			data = info.find_all("div", {"class" : "css-w9rpyh"})


			combine_results = soup.find_all("div", {"class" : "css-1962qwu"})

			forty = combine_results[0].find("div", {"class" : "css-w1k723"}).text
			bench = combine_results[1].find("div", {"class" : "css-w1k723"}).text

			player['forty'] = forty
			player['bench'] = bench

			vertical = combine_results[2].find("div", {"class" : "css-w1k723"}).text
			broad = combine_results[3].find("div", {"class" : "css-w1k723"}).text

			player['vertical_jump'] = int(vertical)
			player['broad_jump'] = broad
			three_cone = combine_results[4].find("div", {"class" : "css-w1k723"}).text
			player['three_cone'] = three_cone


			twenty_yard_shuttle = combine_results[5].find("div", {"class" : "css-w1k723"}).text
			player['twenty_yard_shuttle'] = twenty_yard_shuttle

			sixty_yard_shuttle = combine_results[6].find("div", {"class" : "css-w1k723"}).text
			player['sixty_yard_shuttle'] = sixty_yard_shuttle
	

		scout_report = soup.find("div", {"class" : "css-k9c8dc"})

		for tag in scout_report:
			if isinstance(tag, NavigableString):
				continue
			tag.decompose()

		player['scout_report'] = scout_report.text
	


# Get additional Player information for player combin3profile 
def checkCombineData(players, year):

	
	url = 'https://www.pro-football-reference.com/draft/' + str(year) + '-combine.htm'

	print("Get URL")
	browser.get(url)

	print("begin wait")
	WebDriverWait(browser, 30).until(EC.visibility_of_all_elements_located((By.CLASS_NAME, "table_wrapper")))
	print("end wait")
	soup = BeautifulSoup(browser.page_source, "html.parser")

	
	for player in players:
		

		player_tag = player['last_name'] + ',' + player['first_name']

		print("check for --> " + str(player_tag))
		info = 1

		try: 
			info = soup.find("th", {"csk" : player_tag})
		except Exception:
			continue
		
		print("found info: " + str(info))
		
		row = ""

		try: 
			row = info.parent
		except Exception:
			continue
			

		print("add data")

		if row.find("td", {"data-stat" : "shuttle"}).text != "":
			player['twenty_yard_shuttle'] = float(row.find("td", {"data-stat" : "shuttle"}).text)

		if row.find("td", {"data-stat" : "forty_yd"}).text != "":
			player['forty'] = float(row.find("td", {"data-stat" : "forty_yd"}).text)

		if row.find("td", {"data-stat" : "vertical"}).text != "":
			player['vertical_jump'] = float(row.find("td", {"data-stat" : "vertical"}).text)

		if row.find("td", {"data-stat" : "bench_reps"}).text != "":
			player['bench'] = float(row.find("td", {"data-stat" : "bench_reps"}).text)

		if row.find("td", {"data-stat" : "broad_jump"}).text != "":
			player['broad_jump'] = float(row.find("td", {"data-stat" : "broad_jump"}).text)

		if row.find("td", {"data-stat" : "cone"}).text != "":
			player['three_cone'] = float(row.find("td", {"data-stat" : "cone"}).text)
	

		print("end add data")



# set current page of prospects
curr_page = 1

# get player year inputted on command line
year = 0

try:
	year = int(sys.argv[1])
except ValueError:
	"Please enter a number between "



# data isn't going to be available
if year < 2014:
	print("This year is too early")
	quit()

# set browser
browser = webdriver.Chrome() 

players = []

# Read the JSON data from the file
with open('players.json', 'r') as file:
    players = json.load(file)


		

#i = int(sys.argv[2])
#while i < int(sys.argv[3]):
	#checkPlayerCombineProfile(players[i], year)
	#checkPlayerProfile(players[i])
	#print(players[i])
	#i = i + 1



	#checkPlayerProfile(player)
	#checkPlayerCombineProfile(player, year)

checkCombineData(players, year)

# Write the updated data back to the JSON file
with open('players.json', 'w') as file:
	json.dump(players, file, indent=4)