# ProsjektStyring
- project to pass time - Hobbyproject. Under dev atm. 
Code is in english, but all front-end language is in norwegian. Build in asp.net core 2.2

### Current information available:  ###

Users:
Admin: username: admin@admin.com  Password: Password@123

##Idea:
Projects can have many projectcycles, and projectcycles can have many tasks. Think Sprints.
Every cycle have a planned start and end date. Every task have a planned start and end date. So does the project.

Every project, projectcycle and projectcycletask have their own commentfield.

Projects can have many Teams, and Team can have many Projects. Every Team have many team-members. Team-members should be able to lock a 
task to their user, and register time used.
Every task should track spent time vs planned time, and a proximity for % done based on userinput. 
Every cycle should track spent time vs planned time, and a estimated time based on completion.
Evvery project should track spent time vs planned time, and estimated time to completion.

##Currents status:
Still implementing Projects, projectcycles, projectcyclestasks, and projectcomments, projectcyclecomments and projectcycletaskcomments and
all corresponding functions (add, edit, create, delete).

##Future upgrade:
API service for android-app access.