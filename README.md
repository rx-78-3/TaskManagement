# Instructions

## Structure
All the project's items are located in **src\task-1\TaskManagement** directory. The frontend isn't added to main solution and is placed in **task-management-web-ui** directory and can be opened separately.

Results of task 2 and task 3 are placed in the corresponding folders (task-2 and task-3).

## Running
You can run the project by selecting **docker-compose** Startup Item and **Run** clicking. Database initializes automatically for ease of checking the task. After starting you will be redirected to **http://localhost:3000** page which is the root page of frontend.

## Testing and documentation
- The TaskManagement has exported Postman collection and Postman environment and can be imported for testing. You can find Postman files at the address **src\task-1\TaskManagement\TaskManagement.Api\Postman\**.
- **TaskManagement.Api**, have a connected swagger and it can be reached via addresses **http://localhost:5000/swagger**.

# Solutions justification

- The project structure is simplified, everything is in one project. I don't see any point in complicating the structure since the requirements are quite simple.
- For the same reason, the project does not use logging.
- For the same reason, the project is not documented.
- The same goes for resource files and localization.

I indicate this because some test task examiners require all of this (and even more).
