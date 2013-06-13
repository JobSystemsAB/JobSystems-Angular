/*

-- IN MASTER

SELECT * FROM sys.sql_logins

CREATE LOGIN readonlylogin WITH password='Danderydsgatan28';

CREATE USER readonlyuser FROM LOGIN readonlylogin;

-- IN EVERY DATABASE

CREATE USER readonlyuser FROM LOGIN readonlylogin;

EXEC sp_addrolemember 'db_datareader', 'readonlyuser'; -- GIVE READ ONLY PERMISSIONS

*/