1. HttpGet("{personId}/Getinterests") - Get all interests by person  
Response body  
[  
  {  
    "id": 2,  
    "title": "Programmering",  
    "description": "Att skriva kod i olika språk"  
  },  
  {  
    "id": 3,  
    "title": "Matlagning",  
    "description": "Laga nya och spännande rätter"  
  },  
  {  
    "id": 4,  
    "title": "sdfsdf",  
    "description": "234235"  
  }  
]  
  
2. HttpPost("{personId}/addInterest") - Add an interest and link it to a person  
curl -X 'POST' \  
  'https://localhost:7181/api/Interest/2/addInterest' \  
  -H 'accept: */*' \  
  -H 'Content-Type: application/json' \  
  -d '{  
  "title": "Skidåkning",  
  "description": "Åka skidor"  
}'  
Responses code 200

3. HttpGet("{personId}/getLinksByPerson") - Get all links by person  
200  	 
Response body  
[  
  {  
    "id": 3,  
    "url": "https://www.stackoverflow.com",  
    "personId": 2,  
    "interestId": 2  
  },  
  {  
    "id": 4,  
    "url": "https://www.tasteline.se",  
    "personId": 2,  
    "interestId": 3  
  },  
  {  
    "id": 5,  
    "url": "www.exempel.nu",  
    "personId": 2,  
    "interestId": 4  
  }  
]  

4. HttpGet (Name = "GetAllPeople") - Get all people  
   200	  
Response body  
[  
  {  
    "id": 1,  
    "name": "Anna Svensson",  
    "phone": "0701234567"  
  },  
  {  
    "id": 2,  
    "name": "Erik Karlsson",  
    "phone": "0737654321"  
  }  

]  

5. HttpPost("{personId}/linkToPersonInterest") - Add link to person and interest  
   curl -X 'POST' \  
  'https://localhost:7181/api/Link/2/linkToPersonInterest' \  
  -H 'accept: */*' \  
  -H 'Content-Type: application/json' \  
  -d '{  
  "url": "www.exempelvis.se",  
  "interestId": 2  

response ok 
