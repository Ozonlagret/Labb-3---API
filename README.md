HttpGet("{personId}/Getinterests") - Hämta alla intressen per person  
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
  
HttpPost("{personId}/addInterest") - Lägg till intresse och länka till person  
curl -X 'POST' \  
  'https://localhost:7181/api/Interest/2/addInterest' \  
  -H 'accept: */*' \  
  -H 'Content-Type: application/json' \  
  -d '{  
  "title": "Skidåkning",  
  "description": "Åka skidor"  
}'  
