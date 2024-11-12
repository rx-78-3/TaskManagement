-- Write a query to select all users with unconfirmed emails.
SELECT *
FROM Users
WHERE EmailConfirmed = 0

-- Write a query to get count of users with unconfirmed emails.
SELECT COUNT(UserId)
FROM Users
WHERE EmailConfirmed = 0

-- Write a query to get all uncompleted tasks (todos).
SELECT *
FROM Todos
WHERE IsCompleted = 0

-- Write a query to get users who have at least 3 uncompleted tasks.
SELECT u.UserId, u.UserName --, Anything else.
FROM Users u
JOIN Todos t ON u.UserId = t.UserId
WHERE t.IsCompleted = 0
GROUP BY u.UserId, u.UserName --, Anything else.
HAVING COUNT(t.Id) >= 3