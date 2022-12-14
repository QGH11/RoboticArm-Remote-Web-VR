from turtle import degrees
import serial
from flask import Flask, request
from flask_cors import CORS
from threading import Thread

# set up connection with HC-06
ser = serial.Serial("COM9", 9600, timeout = 1) #Change your port name COM... and your baudrate

def ifRetrieveData(degreeList):
   degreeList = [int(x) for x in degreeList]
   print(degreeList)
   ser.write(degreeList)
    

#Set up Flask:
app = Flask(__name__)

#Set up Flask to bypass CORS:
cors = CORS(app)

#Create the receiver API POST endpoint:
@app.route("/receiver", methods=["GET","POST"])
def postME():
   degreeList = request.json['degree']
   thread = Thread(target= ifRetrieveData, args = [degreeList])
   thread.daemon = True
   thread.start()
   return degreeList

if __name__ == "__main__": 
   app.run()





   

