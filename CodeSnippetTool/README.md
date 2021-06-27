The following document is to provide an overview of all the features and correct usage of the application to maximise the user experience.
## Requirements:
The following section will give an overview of the minimum requirements for the application to run properly
* Xampp or another localhost service is running a mysql database for the application to access
* The local database should be named snippet_db and should import the files provided in the submitted package

## How to use:

* On the applications adding page, it will be possible to add code snippets to the database. A snippet name, description, and the snippet itself are required. 
	Optionally the user may enter if the snippet is a favourite by ticking the checkbox and add a hot key binding. The binding requires a key and a modefier! Note that the program is coded so that if the hotkey is taken, the snippet will be added regardless, without the entered hotkey binding.
* On the display page is a table with all snippets. To modefy one simply select a row, make the changes and then unselect the row OR select a different row for these changes to be applied.
* When updating a hotkey command, the refresh button has to be pressed to apply the hotkey command changes. 
* A snippet can be copied via the copy button or a hotkey combintion.
* The show snippet preview checkbox will allow a user to check what they have copied if they wish, and disable notifications when copying from the application when working on something else. 
* A user can simply sort the table by clicking on table headers. 
* The searching for snippets works by entering a name into the name field without a snippet selected and pressing the find button.