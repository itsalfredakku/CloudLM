# CloudLM
.Net Framework Windows Forms Sample Application integrated with cloud based licensing module

## Configuration
In project root directory 

```XML
<appSettings>
  <add key="apiKey" value="firebase-api-key" />
  <add key="basePath" value="realtime-database-path" />
</appSettings>
```
Update _**firebase-api-key**_ and _**realtime-database-path**_

### Note
If user gets message **"Please contact administration"**
1. Check user is enabled
2. Check user validity (validFrom/validTill in **Realtime Database**) _Date format should be like "yyyyMMdd"_

![Built with Firebase](https://github.com/itsalfredakku/CloudLM/raw/master/CloudLM/logo-built_white.jpg)
