# ProsjektStyring
- project to pass time - Hobbyproject. Under dev atm.
No guarantee that it will ever be finished, or given support.
Code is in english, but all front-end language is in norwegian. Build in asp.net core 2.2

### Current information available:  ###

SeedData.cs will create at first run the current data:
Roles(Listed in RoleOptions.cs):
AdminRole
TeamLeaderRole
MemberRole
UserRole

Users:
Admin -> username: admin@admin.com  Password: Password@123
TeamLeader -> username: teamleader@teamleader.com  Password: Password@123
Member -> username: member@member.com  Password: Password@123
User -> username: user@user.com  Password: Password@123

Project:
Testprosjekt	id=1	Unique_ProjectIdString=exampleprojectguid
ProjectCycle:
Mine Oppgaver	id=1	Unique_CycleIdString=examplecycleguid
ProjectCycleTask:
TestOppgave		id=1	Unique_TaskIdString=exampletaskguid

There is also comments to the different entitys added. As follows:
ProjectComment	id=1	Unique_IdString=exampleprojectcommentguid
ProjectCycleComment	id=1	Unique_IdString=exampleprojectcyclecommentguid
ProjectCycleTaskComment	id=1	Unique_IdString=exampleprojectcycletaskcommentguid


##  Idea:
Projects can have many projectcycles, and projectcycles can have many tasks. Think Sprints.
Every cycle have a planned start and end date. Every task have a planned start and end date. So does the project.

Every project, projectcycle and projectcycletask have their own commentfield.

Projects can have many Teams, and Team can have many Projects. Every Team have many team-members. Team-members should be able to lock a 
task to their user, and register time used.
Every task should track spent time vs planned time, and a proximity for % done based on userinput. 
Every cycle should track spent time vs planned time, and a estimated time based on completion. Should also track % completion.
Every project should track spent time vs planned time, and estimated time to completion.
... More elaberated details to come at some later point.

 - Since its a hobby project to pass time, there will be little to no css. Basic bootstrap design.

##  Currents status:
*	Basic functions for creating, deleting or updating Project, ProjectCycle and ProjectCycleTask are in place. Possibility to post commet to each is also implemented. 
*	Next is to create tables for teams, and link teams to projects. Then create tables for some sort of hour
registration towards every task from users. And diverse access to users belonging to teams assosiated with given project.

##  Future upgrade ideas:
- Include signalR for realtime update to all connected clients on update in projectdetails
- API service for android-app access.
