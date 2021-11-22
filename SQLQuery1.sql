CREATE PROCEDURE UpdateReviewerPicture
@ReviewId int,
@AppointmentId int,
@FileName varchar(255),
@ImagePath varchar(255),
@Id int 
AS
update ReviewerPicture set ReviewId = @ReviewId, AppointmentId = @AppointmentId, FileName = @FileName, ImagePath = @ImagePath where Id = @Id;