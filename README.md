# BitrateCalculator

Before starting solution you will need to:

Create database with these commands:
1. add-migration database-init
2. update-database

Start application

GetAll endpint will print all Transcoder data

UploadVideo endpoint will upload wideo with calculate the requested bitrates for both Rx and Tx considering a polling rate of 2Hz. 

Test data: Json in string
"{\"Device\":\"Arista\",\"Model\":\"X-Video\",\"NIC\":[{\"Description\":\"LinksysABR\",\"MAC\":\"14:91:82:3C:D6:7D\",\"Timestamp\":\"2020-03-23T18:25:43.511Z\",\"Rx\":\"3698574500\",\"Tx\":\"122558800\"}]}"
