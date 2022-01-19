CREATE PROCEDURE CheckDateAvailability
@Date DateTime
AS 
select * from Appointment where CAST(Appointment.Date as DATE) = CAST(@Date as DATE)
