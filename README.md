<h1>Fitness Tracker App</h1>

<h3>Purpose</h3>
<p>Simple, easy to navigate for user. Allows user to track their fitness. User enters what exercise they completed and the date and 
time automatically appears underneath it. </p>

<h3>Consists of</h3>
<p>Two pages, a Fitness Information List Page and Fitness Information Page. </p>

<h3>The Fit Class</h3>
<p>This class defines the attributes of each item on the list and the filename where list will be stored. Each item on the list has a 
DateTime attribute and a string Attribute.  </p>

<h3>FITNESS INFORMATION LIST</h3>
<h4>(FitnessPage.xaml and fitnessPage.xaml.cs) </h4>
<p>This contains a toolbar and a listview. Toolbar contains item “Add”. 
Listview is binded to text and date. 
The xaml.cs file must have an onAppearing method. This creates a list of type Fit. (Fit.cs) Populates the list and saves to a txt file. 
This txt file is where the data is stored The onAppearing method will also contain a function to order the exercise (list items) by the 
date. 
When add Button is tapped, this calls the method which directs the user to FitnessInfoPage and creates a new instance of type Fit and binds it. 
When a list item is selected Navigates to FitnessInfoPage, binds to Fit instance. <p>

<h3> FITNESS INFORMATION PAGE</h3>
<h4>(FitnessInfoPage.xaml and FitnessInfoPage.xaml.cs)</h4>
<p>This page contains a box with a placeholder, telling the user to enter what ever exercise they did, and two buttons. A delete button and a 
save button. The text in the box is binding to the text attribute from the Fit class. 
The delete button calls a method which deletes the file if it existed and the user is brought back to the fitness Information List page. 
The save button calls a method which  will either (using if/else statement), save the details entered into a new file with a randomly 
generated name or an existing file, if the list item is being edited.  </p>
