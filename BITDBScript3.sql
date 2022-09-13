
USE master;
GO
IF EXISTS	(	SELECT	name
	    		FROM	master..sysdatabases
				WHERE	name = 'BIT_Services'
			)
DROP PROCEDURE IF EXISTS dbo.usp_ChkLocation
GO
DROP PROCEDURE IF EXISTS dbo.usp_usp_ChkSkill 
GO
DROP PROCEDURE IF EXISTS dbo.usp_ChkDateAvailable
GO
DROP PROCEDURE IF EXISTS dbo.usp_ChkDoubleJob
GO
DROP DATABASE BIT_Services;
GO
CREATE DATABASE BIT_Services;
GO
USE BIT_Services;
GO

--	TABLES		--


CREATE TABLE SKILL (
                Skill NVARCHAR(30) NOT NULL                
                CONSTRAINT SKILL_pk PRIMARY KEY (Skill)
)

CREATE TABLE COORDINATOR (
                Coordinator_Id INT IDENTITY NOT NULL,
                First_Name NVARCHAR(30) NOT NULL,
                Last_Name NVARCHAR(30) NOT NULL,
                Phone NCHAR(10) NOT NULL,
                Email NVARCHAR(255) NOT NULL,
                [Password] NVARCHAR(30) NOT NULL,
                IsAdmin BIT NOT NULL,
				IsActive BIT NOT NULL,
                CONSTRAINT COORDINATOR_pk PRIMARY KEY (Coordinator_Id)
)

CREATE TABLE CLIENT (
                Client_Id INT IDENTITY NOT NULL,
                [Name] NVARCHAR(30) NOT NULL,
                Phone NCHAR(10) NOT NULL,
                Email NVARCHAR(255) NOT NULL, 				
                [Password] NVARCHAR(30) NOT NULL, 
				IsActive BIT NOT NULL,
                CONSTRAINT CLIENT_pk PRIMARY KEY (Client_Id)
)

CREATE TABLE CONTRACTOR (
                Contractor_Id INT IDENTITY NOT NULL,
                First_Name NVARCHAR(30) NOT NULL,
                Last_Name NVARCHAR(30) NOT NULL,
                Phone NCHAR(10) NOT NULL,
                Email NVARCHAR(255) NOT NULL,
                Experience NCHAR(12) NOT NULL,
                [Password] NVARCHAR(30) NOT NULL,
				IsActive BIT NOT NULL,
                CONSTRAINT CONTRACTOR_pk PRIMARY KEY (Contractor_Id)
)

CREATE TABLE PREFFERED_LOCATIONS (
                Postcode NCHAR(4) NOT NULL,
                Suburb NVARCHAR(30) NOT NULL,
                Contractor_Id INT NOT NULL,
                CONSTRAINT PREFFERED_LOCATIONS_pk PRIMARY KEY (Postcode, Suburb, Contractor_Id)
)

CREATE TABLE JOB (
                Job_Id INT IDENTITY NOT NULL,
                Client_Id INT NOT NULL,
                Contractor_Id INT,
                [Date] DATE NOT NULL,               
                [Priority] NCHAR(12) NOT NULL,
                Skill NVARCHAR(30) NOT NULL,
				[Status] NVARCHAR(14) NOT NULL,
				Distance INT,
                Street NVARCHAR(30) NOT NULL,
                Suburb NVARCHAR(30) NOT NULL,
                Postcode NCHAR(4) NOT NULL,
				[Description] NVARCHAR(255) NOT NULL,
                CONSTRAINT JOB_pk PRIMARY KEY (Job_Id)
)

CREATE TABLE HISTORY (
				Job_Id INT NOT NULL,
				Contractor_Id INT NOT NULL,
				CONSTRAINT HISTORY_pk PRIMARY KEY (Job_Id,Contractor_Id)
				
)

CREATE TABLE FEEDBACK (
                Job_Id INT NOT NULL,				
                Feedback NVARCHAR(255) NOT NULL,
                CONSTRAINT FEEDBACK_pk PRIMARY KEY (Job_Id)
)

CREATE TABLE [AVAILABILITY] (
                Contractor_Id INT NOT NULL,
                [Date] DATE NOT NULL,
                CONSTRAINT AVAILABILITY_pk PRIMARY KEY (Contractor_Id, [Date])
)

CREATE TABLE CONTRACTOR_SKILL (
                Skill NVARCHAR(30) NOT NULL,
                Contractor_Id INT NOT NULL,
                CONSTRAINT CONTRACTOR_SKILL_pk PRIMARY KEY (Skill, Contractor_Id)
)



ALTER TABLE CONTRACTOR_SKILL ADD CONSTRAINT SKILL_CONTRACTOR_SKILL_fk
FOREIGN KEY (Skill)
REFERENCES SKILL (Skill)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE JOB ADD CONSTRAINT SKILL_JOB_fk
FOREIGN KEY (Skill)
REFERENCES SKILL (Skill)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE HISTORY ADD CONSTRAINT JOB_HISTORY_fk
FOREIGN KEY (Job_Id)
REFERENCES JOB (Job_Id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE JOB ADD CONSTRAINT CLIENT_JOB_fk
FOREIGN KEY (Client_Id)
REFERENCES CLIENT (Client_Id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE CONTRACTOR_SKILL ADD CONSTRAINT CONTRACTOR_CONTRACTOR_SKILL_fk
FOREIGN KEY (Contractor_Id)
REFERENCES CONTRACTOR (Contractor_Id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE AVAILABILITY ADD CONSTRAINT CONTRACTOR_AVAILABILITY_fk
FOREIGN KEY (Contractor_Id)
REFERENCES CONTRACTOR (Contractor_Id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE JOB ADD CONSTRAINT CONTRACTOR_JOB_fk
FOREIGN KEY (Contractor_Id)
REFERENCES CONTRACTOR (Contractor_Id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE PREFFERED_LOCATIONS ADD CONSTRAINT CONTRACTOR_PREFFERED_LOCATIONS_fk
FOREIGN KEY (Contractor_Id)
REFERENCES CONTRACTOR (Contractor_Id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE FEEDBACK ADD CONSTRAINT JOB_FEEDBACK_fk
FOREIGN KEY (Job_Id)
REFERENCES JOB (Job_Id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

--	Delimits	--
ALTER TABLE JOB ADD CONSTRAINT CK_JOB_Priority CHECK ([Priority] IN ('Low','Medium','High','Urgent'));

ALTER TABLE JOB ADD CONSTRAINT CK_JOB_Status CHECK ([Status] IN ('Unassigned','Assigned', 'Accepted', 'Complete', 'PaymentPending', 'Rejected'));

ALTER TABLE COORDINATOR ADD CONSTRAINT CK_COORDINATOR_Active CHECK (IsActive IN (1, 0));

ALTER TABLE COORDINATOR ADD CONSTRAINT CK_COORDINATOR_Admin CHECK (IsAdmin IN (1, 0));

ALTER TABLE CONTRACTOR ADD CONSTRAINT CK_CONTRACTOR_Active CHECK (IsActive IN (1, 0));

ALTER TABLE CONTRACTOR ADD CONSTRAINT CK_CONTRACTOR_Experience CHECK ([Experience] IN ('Beginner', 'Intermediate', 'Advanced', 'Expert'));

ALTER TABLE CLIENT ADD CONSTRAINT CK_CLIENT_Active CHECK (IsActive IN (1, 0));
--	INSERTS		--
SET DATEFORMAT DMY
INSERT INTO [dbo].SKILL (Skill)
VALUES
('C# Programmer'),
('Database Administrator'),
('Java Programmer'),
('Front End Developer'),
('SQL Programmer'),
('Systems Architect'),
('HTML/CSS Developer'),
('ASP.Net Developer'),
('Entity Framework Developer'),
('SQL Server Administrator'),
('C++ Programmer'),
('C Programmer'),
('Network Administrator'),
('Windows Server Administrator');
GO
INSERT INTO [dbo].COORDINATOR (First_Name,Last_Name,Phone,Email,[Password],IsAdmin,IsActive)
VALUES
('Holly','Stevens','0418354416','HollyS@BIT.com','Access',1,1),
('Mike','Showman','0493126945','MikeS@BIT.com','Access',0,1);
GO
INSERT INTO [dbo].CLIENT ([Name],Phone,Email,[Password],IsActive)
VALUES
('AllenInc','0483866959','AllenInc@Gmail.com','Welcome',1),
('Kortain','0493307195','Mike@Kortain.com','Welcome',1),
('KFC','0493503310','Chik@KFC.com','Welcome',1),
('WayneTech','0456647517','Bats@Wayne.com','Welcome',1);
GO
INSERT INTO [dbo].CONTRACTOR (First_Name,Last_Name,Phone,Email,Experience,[Password],IsActive)
VALUES
('Benson','Stonehall','0455271331','BensonS@Gmail.com','Beginner','Work',0),
('Jenna','Pearson','0483264975','JennaP@Gmail.com','Intermediate','Work',1),
('Gilbert','Godfrey','0452935930','GilbertG@Gmail.com','Advanced','Work',1),
('Edna','Mode','0420135564','EdnaM@Gmail.com','Expert','Work',1);
GO
INSERT INTO [dbo].PREFFERED_LOCATIONS (Contractor_Id,Postcode,Suburb)
VALUES

(1,'2096','Freshwater'),
(1,'2096','Queenscliff'),
(1,'2100','North Manly'),
(2,'2101','Narrabeen'),
(2,'2100','Brookvale'),
(2,'2099','Narraweena'),
(3,'2085','Belrose'),
(3,'2084','Terrey Hills'),
(3,'2100','Oxford Falls'),
(4,'2087','Killarney Heights'),
(4,'2087','Forestville'),
(4,'2086','Frenchs Forest');
GO
INSERT INTO [dbo].JOB (Client_Id,Contractor_Id,[Date],[Priority],Skill,[Status],Distance,street,suburb,postcode,[Description])
VALUES
(4,NULL,'24/05/2022','Urgent','Network Administrator','Unassigned',1,'88 Starkey St','Killarney Heights','2087','An issue has happend in our network'),
(4,4,'28/06/2018','Urgent','SQL Server Administrator','PaymentPending',5,'16 Harmston Ave','Frenchs Forest','2086','An issue has happend in our network'),
(1,4,'28/05/2022','High','Windows Server Administrator','PaymentPending',4,'79 Ferguson St','Forestville','2087','Issues with windows server stopping printers from working'),
(2,3,'24/05/2022','Medium','Systems Architect','PaymentPending',3,'33 Forest Way Rd','Belrose','2085','Need help with our system'),
(3,2,'26/05/2022','Low','HTML/CSS Developer','Complete',6,'210 Wakehurst Pkwy','Oxford Falls','2100','Website has bugs with layout');
GO
INSERT INTO [dbo].FEEDBACK (Job_Id, Feedback)
VALUES
(1,'Client Explained issue well'),
(2,'Client Explained issue well'),
(4,'Found it very difficult to fix this issue, please assign more experienced contractors'),
(5,'Would like to be assigned to a job closer to me');
GO
INSERT INTO [dbo].[AVAILABILITY] (Contractor_Id,[Date])
VALUES
(1,'23/06/2022'),
(1,'24/06/2022'),
(1,'25/06/2022'),
(2,'23/06/2022'),
(2,'26/06/2022'),
(2,'27/06/2022'),
(3,'24/06/2022'),
(3,'25/06/2022'),
(3,'28/06/2022'),
(4,'24/06/2022'),
(4,'26/06/2022'),
(4,'28/06/2022');
GO
INSERT INTO [dbo].CONTRACTOR_SKILL (Skill,Contractor_Id)
VALUES
('HTML/CSS Developer',1),
('C# Programmer',1),
('C++ Programmer',2),
('Front End Developer',2),
('ASP.Net Developer',2),
('Systems Architect',3),
('C Programmer',3),
('Java Programmer',3),
('SQL Programmer',3),
('Entity Framework Developer',3),
('Database Administrator',4),
('Network Administrator',4),
('SQL Server Administrator',4),
('Windows Server Administrator',4);
GO
--	STORED PROCS		--
CREATE OR ALTER PROCEDURE usp_ChkPrefLocation 

@Suburb NVARCHAR(30),
@Postcode NCHAR(4)

AS
BEGIN

SELECT c.Contractor_Id
FROM CONTRACTOR c
INNER JOIN LOCATIONS l ON c.Contractor_Id = l.Contractor_Id 
WHERE(@Suburb)  IN(l.Suburb) 
AND(@Postcode) IN(l.postcode)

END
GO

CREATE OR ALTER PROCEDURE usp_ChkSkill 

@Skill NVARCHAR(30)

AS
BEGIN

SELECT cs.Contractor_Id
FROM CONTRACTOR_SKILL cs					
WHERE cs.Skill = @Skill					
				
END
GO

CREATE OR ALTER PROCEDURE usp_ChkDateAvailable 

@Date DATE

AS
BEGIN
	
SELECT a.Contractor_Id
FROM [AVAILABILITY] a					
WHERE a.[Date] = @Date
			
END
GO

CREATE OR ALTER PROCEDURE usp_ChkDoubleJob 

@Date DATE,
@Contractor_Id INT,
@Result NVARCHAR(11) OUTPUT

AS
BEGIN

IF EXISTS	(
				SELECT j.Contractor_Id
				FROM JOB j
				WHERE j.[Date] = @Date 
				AND j.Contractor_Id = @Contractor_Id
			)
			SET @Result = 'Unavailable'
		ELSE
			SET @Result = 'Available'
END
GO
