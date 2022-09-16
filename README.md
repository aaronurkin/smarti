# Smarti
## The system merging data received from different sources

### Try it
- Clone the code from the repo running the `git clone https://github.com/aaronurkin/smarti.git` command within the Git Bash
- Open the solution inside the Visual Studio 2019 or later
- Run Smarti pressing F5 button
- Expand MergePeople endpoint Post method within the opened Swagger UI:
![image](https://user-images.githubusercontent.com/36369007/190679947-19d73072-9239-40b6-af6a-84802724f755.png)
- Click the `Try it out` button
![image](https://user-images.githubusercontent.com/36369007/190680509-7c0c25a0-e9f4-48ca-b57c-2a7ae8f643df.png)
- Paste the following request body:
`
[
    {
        "source": "Webint",
        "entity": {
            "tz": "IST",
            "name" : "M",
            "age": 60,
            "address": {
                "city": "Tel Aviv",
                "region": "Tel Aviv"
            }
        }
    },
    {
        "source": "C2",
        "entity": {
            "tz": "EST",
            "name" : "Moshe",
            "age": 50,
            "address": {
                "city": "Boston",
                "region": "New England"
            }
        }
    }
]
`
into the `Request body` text area input.
![image](https://user-images.githubusercontent.com/36369007/190681469-c81a2025-9d00-47ef-9282-3673e145491d.png)
- Click the `Execute` button
![image](https://user-images.githubusercontent.com/36369007/190681905-aa4c4fa3-e0a9-4fa7-9eda-30d8a7581e7a.png)
- Check the result out scrolling down to the `Response body` section
![image](https://user-images.githubusercontent.com/36369007/190682260-b399c37a-b529-421f-86ef-fea9b43e3917.png)
