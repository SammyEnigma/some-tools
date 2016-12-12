# A Tools to Archive files to Dropbox

Supposed to be run in Windows Server Task Scheduler.

Just a simple tools to 

 - Get the latest N file(s) from a folder and archive them to a Dropbox's folder
 - Keep only a no of latest file(s) in the folder and move old files to a trash folder


## How to use

1. Setup Dropbox app

[https://www.dropbox.com/developers/apps](https://www.dropbox.com/developers/apps "https://www.dropbox.com/developers/apps")

2. Get Access Token from your Dropbox App

3. Fill in the configs

	    <add key="ArchiveFolder" value="c:\archive\"/> <!-- Folder that stores the files to be archived -->
	    <add key="TrashFolder" value="c:\archive-trash\"/> <!-- Folder that stores the files to be trashed -->
	    <add key="SimulateOnly" value="true"/> <!-- Simulate only logs but do nothing -->
	
	    <add key="NoOfLatestFileToArchive" value="1"/> <!-- Get the latest N file(s) to archive to dropbox -->
	    <add key="NoOfLatestFileToKeep" value="5"/> <!-- No of latest files to still be keeping in Archive Folder, those old files will be moved to Trash Folder -->
	    <add key="DropboxAccessToken" value="accessToken"/> <!-- Dropbox's app access token -->
	    <add key="DropboxFolderToArchive" value="backup"/> <!-- Dropbox's folder to be storing the update -->
	
	    
	
