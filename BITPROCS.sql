--	STORED PROCS		--
CREATE OR ALTER PROCEDURE usp_NewJobStatus

@Status NVARCHAR(14)

AS
BEGIN

DECLARE @Job_Id INT = @@IDENTITY
INSERT INTO JOB_STATUS (Job_Id,[Status])
VALUES (@Job_Id,@Status);

END
GO