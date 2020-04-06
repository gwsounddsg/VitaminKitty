# VitaminKitty
Web API for your daily dose of kitties.

# Description
This is a basic RESTful API that will post an image of a kitty with a random cat fact to your Twitter. Use the following POST call: `https://localhost:{port}/api/VitaminKitty/tweet`. In the body it must contain 4 parameters which are created in your Twitter Developer account: APIKey, APISecret, AccessToken, AccessSecret. If successful, it will return the cat fact it posted.

Here's an example of the body in json format:
```
{
	"apikey": "xxxx",
	"apisecret": "xxxx",
	"accesstoken": "xxxx",
	"accesssecret": "xxxx"
}
```

# Other Calls

- `/api/VitaminKitty/catfact` will return a random cat fact as a string.
- `/api/VitaminKitty/catimage` will return a `Bitmap` of the daily cat image.
