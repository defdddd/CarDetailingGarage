CREATE PROCEDURE SearchAppointmentById
@Id int
AS 
BEGIN
select * from Appointment where Id = @Id;
END