CSCI 4711 Software Engineering

Assignment: Deliverable No. 5
Deadline: See D2L Assignment folder
Description:
For this assignment, you should:
1.	Make corrections to the previous version of RAD based on the received feedback. It is important that all corrections are made as indicated.
2.	Update Chapter 6 (Appendix): Include implementation of the following:
a.	all entity objects
b.	database connector
c.	login controller
3.	Submit in D2L: RAD version 5 and entire source code of the implementation (as zip archive)
The structure of RAD for this version is described below. The bullets represent the unnumbered sections before Chapter 1 (Introduction). The numbers on the left represent the corresponding chapters and numbered sections.
•	Cover page – Should include:
o	Name of system
o	Name of document and version number
o	Name of course, semester, and name of university
o	Names of team members 
See cover page template in D2L. There should be no page number on the cover page.
•	Table of Contents
Table of contents should be correctly numbered. See this link for how to insert a table of contents in Microsoft Word. You could also search for it on the web.
1.	Introduction
1.1.	Scope of System: An overview of system (three or four paragraphs, including purpose). Describe scope of system, focusing on what is inside and outside the boundary of the system.
2.	Requirements of system
2.1.	Functional Requirements: Use a bulleted list with a brief description of each functional requirement.
2.2.	Non-functional Requirements: These should include the given non-functional requirements for the project. Non-functional requirement should be organized by category.
2.3.	Use Cases: This should be a use case diagram. The use case should be big and legible. Allowed colors are a white background and a black foreground. The diagram should be labeled.
2.4.	Use Case descriptions: A use case description for each use case in a tabular format. Alternate flows should be captured using more than one use case description. Each flow should have its own description. Each use case description should be on a separate page (one page). Each table should be labeled.
2.5.	Requirement Analysis (draw sequence diagrams for the use cases). 
­	Your system should have and make use of at least 3 entity objects. All data that is retrieved from the database must be in the form of an entity object.
­	Your system should have at least one distinct controller for each use case (i.e., do not use the same controller across multiple use cases). You should not have more than two controllers per sequence diagram.
­	Your system must make use of a database connector (it is a controller) object to interact with a database. All data that is retrieved from the database must be in the form of an entity object.
­	Every user’s log in and log out session should be saved to the database. The session data should capture the user, the event (login or logout), and the time of the event.
­	Your sequence diagrams should not include activation boxes.
­	Each object must be unambiguously named to indicate its type. Except for the database connector, each controller object should have the word “Control” appended to its name. Similarly, every boundary object should have the “Form” or “Menu” appended to its name. An object must not have more than two words as part of its name.
3.	User Interface Mockups (insert mockups of user interfaces for the uses where a user interface is required to facilitate the interaction. See ATM example in D2L)
4.	Object Design
4.1.	Object Interaction: Create class diagrams (without attributes and operations) that captures the association between objects. Organize your class diagrams into groups that show the associations between:
­	Boundary objects
­	Control objects
­	Entity objects
­	Boundary, Entity, and Control objects (where applicable)
Be sure to capture any optimizations (e.g., generalizations) that are necessary to enhance the design and implementation of the system.
4.2.	Class Design: Create individual class diagrams that show important attributes & operations for every class.
4.3.	Database Design: Using the TerraER tool, create an ER Diagram of your database schema.
­	Show relationships that might exist between entities in addition to how user logout event information would be captured.
­	Relational model of your database schema: Show how the ER model is mapped to the relational model. Use the following format for the relational model: 
NAME (Attibute1, Attribute2, Attribute3FK)
Where:
NAME is the name of the relation
Attribute1 is the primary key (indicated by underscore)
Attribute3FK is a foreign key (indicated by FK superscript)
All foreign keys should be named unambiguously to correctly indicate the attributes to which they reference.
5.	System Design
5.1.	Subsystem Decomposition
6.	Appendix
6.1.	Appendix A – Source Code (implementation of the six classes listed at the top of this document). The source code should be in font style courier new (10-point size).

Document Formatting:
Your document should adhere to the following formatting rules:
•	Start each chapter (not subsection) on a new page.
•	Use Times New Roman font 
•	Use single-line spacing.
•	Chapter headings should be 16-point size and bold style (all CAPS).
•	Section headings should be 14-point size and bold style (all CAPS).
•	Text should be 12-point size.
•	Use black foreground color over white background
•	All UML diagrams be drawn with Microsoft Visio
•	ER Diagram is created using TerraER tool.
•	Each diagram and table should be labeled
•	Use font Courier New, 10-point size for source code
•	Start each Appendix on a new page.

Grading Rubric 

Category	Possible	Points
Writing and format: 
•	Quality of grammar and neatness
•	Adhere to given document format
•	Artifacts are formatted correctly in a uniformed way.
•	RAD is submitted in PDF format	10	
Chapter 1: Introduction
Chapter 2: Requirements of System 
Chapter 3: User Interface Mockups 	10	
Chapter 4: Object Design 
•	Overview
•	Object Interaction
•	Detailed class diagram	20	
Chapter 5: System Design 
•	Architectural design (Subsystem decomposition)	10	
Entire Source Code
•	Completeness, Correctness, Consistency (against models)	50	
TOTAL:	100	
		

