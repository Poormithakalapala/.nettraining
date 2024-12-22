using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    public class UserOperations
    {
        public static void UserMenu(int userId)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("*              USER MENU               *");

                    Console.WriteLine();
                    Console.WriteLine("1. Search Trains");
                    Console.WriteLine("2. Book Tickets");
                    Console.WriteLine("3. Cancel Tickets");
                    Console.WriteLine("4. View Bookings");
                    Console.WriteLine("5. Exit");
                    Console.Write("Choose an option: ");
                    var choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        SearchTrain();
                    }
                    else if (choice == "2")
                    {
                        BookTickets(userId);
                    }
                    else if (choice == "3")
                    {
                        CancelTickets(userId);
                    }
                    else if (choice == "4")
                    {
                        ViewBookings(userId);
                    }
                    else if (choice == "5")
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a valid Input");
                }
            }
        }
        private static void SearchTrain()
        {
            Console.Clear();
            Console.Write("Enter Source Station: ");
            var fromStation = Console.ReadLine();

            Console.Write("Enter Destination Station: ");
            var destStation = Console.ReadLine();

            Console.Write("Enter Date of Travel (yyyy-mm-dd): ");
            var dateOfTravel = DateTime.Parse(Console.ReadLine());

            var query = "SELECT Tno, Tname, ClassOfTravel, SeatsAvailable, Price, TrainStatus, DateOfTravel FROM Trains WHERE FromStation = @FromStation AND DestStation = @DestStation AND DateOfTravel = @DateOfTravel";
            var parameters = new[] {
            new SqlParameter("@FromStation", fromStation),
            new SqlParameter("@DestStation", destStation),
            new SqlParameter("@DateOfTravel", dateOfTravel)
        };

            var table = Database.ExecuteQuery(query, parameters);

            if (table.Rows.Count == 0)
            {
                Console.WriteLine("No trains found for the specified route and date.");
            }
            else
            {
                Console.WriteLine("Train Number | Train Name | Class of Travel | Seats Available | Price | Train Status | Date of Travel");
                foreach (DataRow row in table.Rows)
                {
                    var tno = row["Tno"];
                    var tname = row["Tname"];
                    var classOfTravel = row["ClassOfTravel"];
                    var seatsAvailable = row["SeatsAvailable"];
                    var price = row["Price"];
                    var trainStatus = row["TrainStatus"];
                    var date = row["DateOfTravel"];

                    Console.WriteLine($"{tno} | {tname} | {classOfTravel} | {seatsAvailable} | {price} | {trainStatus} | {date:d}");
                }
            }

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
        private static void BookTickets(int userId)
        {
            Console.Clear();
            Console.Write("Enter Train Number: ");
            var tno = int.Parse(Console.ReadLine());

            Console.Write("Enter Class of Travel: ");
            var classOfTravel = Console.ReadLine();

            Console.Write("Enter Date of Travel (yyyy-mm-dd): ");
            var dateOfTravel = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Number of Seats: ");
            var numberOfSeats = int.Parse(Console.ReadLine());

            if (numberOfSeats > 10)
            {
                Console.WriteLine("You can book a maximum of 10 tickets at a time.");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                return;
            }

            var query = "SELECT SeatsAvailable, TrainStatus, Price FROM Trains WHERE Tno = @Tno AND ClassOfTravel = @ClassOfTravel AND DateOfTravel = @DateOfTravel";
            var parameters = new[] {
            new SqlParameter("@Tno", tno),
            new SqlParameter("@ClassOfTravel", classOfTravel),
            new SqlParameter("@DateOfTravel", dateOfTravel)
        };

            var table = Database.ExecuteQuery(query, parameters);
            if (table.Rows.Count == 0)
            {
                Console.WriteLine("Train or class of travel not found.");
                Console.ReadLine();
                return;
            }

            var seatsAvailable = (int)table.Rows[0]["SeatsAvailable"];
            var trainStatus = table.Rows[0]["TrainStatus"].ToString();
            var pricePerSeat = (decimal)table.Rows[0]["Price"];

            if (trainStatus.ToLower() != "active")
            {
                Console.WriteLine("The train is not active and cannot be booked.");
                Console.ReadLine();
                return;
            }

            if (numberOfSeats > seatsAvailable)
            {
                Console.WriteLine("Not enough seats available.");
                Console.ReadLine();
                return;
            }

            var insertBookingQuery = "INSERT INTO Bookings (Tno, ClassOfTravel, UserId, NumberOfSeats, BookingDate, DateOfTravel) VALUES (@Tno, @ClassOfTravel, @UserId, @NumberOfSeats, @BookingDate, @DateOfTravel)";
            var insertBookingParameters = new[] {
            new SqlParameter("@Tno", tno),
            new SqlParameter("@ClassOfTravel", classOfTravel),
            new SqlParameter("@UserId", userId),
            new SqlParameter("@NumberOfSeats", numberOfSeats),
            new SqlParameter("@BookingDate", DateTime.Now),
            new SqlParameter("@DateOfTravel", dateOfTravel)
        };

            var updateSeatsQuery = "UPDATE Trains SET SeatsAvailable = SeatsAvailable - @NumberOfSeats WHERE Tno = @Tno AND ClassOfTravel = @ClassOfTravel AND DateOfTravel = @DateOfTravel";
            var updateSeatsParameters = new[] {
            new SqlParameter("@NumberOfSeats", numberOfSeats),
            new SqlParameter("@Tno", tno),
            new SqlParameter("@ClassOfTravel", classOfTravel),
            new SqlParameter("@DateOfTravel", dateOfTravel)
        };

            try
            {
                Database.ExecuteNonQuery(insertBookingQuery, insertBookingParameters);
                Database.ExecuteNonQuery(updateSeatsQuery, updateSeatsParameters);
                Console.WriteLine("Booking successful.");

                var bookingDetailsQuery = "SELECT TOP 1 BookingId, Tno, ClassOfTravel, UserId, NumberOfSeats, BookingDate, DateOfTravel FROM Bookings WHERE Tno = @Tno AND ClassOfTravel = @ClassOfTravel AND UserId = @UserId ORDER BY BookingId DESC";
                var bookingDetailsParameters = new[] {
                new SqlParameter("@Tno", tno),
                new SqlParameter("@ClassOfTravel", classOfTravel),
                new SqlParameter("@UserId", userId)
            };

                var bookingTable = Database.ExecuteQuery(bookingDetailsQuery, bookingDetailsParameters);
                if (bookingTable.Rows.Count > 0)
                {
                    var booking = bookingTable.Rows[0];
                    var bookingId = (int)booking["BookingId"];
                    var bookedTno = (int)booking["Tno"];
                    var bookedClassOfTravel = booking["ClassOfTravel"].ToString();
                    var bookedUserId = (int)booking["UserId"];
                    var bookedNumberOfSeats = (int)booking["NumberOfSeats"];
                    var bookedBookingDate = (DateTime)booking["BookingDate"];
                    var bookedDateOfTravel = (DateTime)booking["DateOfTravel"];
                    var totalAmount = bookedNumberOfSeats * pricePerSeat;

                    Console.WriteLine("Booking Details:");
                    Console.WriteLine($"Booking ID: {bookingId}");
                    Console.WriteLine($"Train Number: {bookedTno}");
                    Console.WriteLine($"Class of Travel: {bookedClassOfTravel}");
                    Console.WriteLine($"User ID: {bookedUserId}");
                    Console.WriteLine($"Number of Seats: {bookedNumberOfSeats}");
                    Console.WriteLine($"Booking Date: {bookedBookingDate}");
                    Console.WriteLine($"Date of Travel: {bookedDateOfTravel}");
                    Console.WriteLine($"Total Amount: {totalAmount}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }


        private static void CancelTickets(int userId)
        {
            Console.Clear();
            Console.Write("Enter Booking ID: ");
            var bookingId = int.Parse(Console.ReadLine());

            Console.Write("Enter Number of Seats to Cancel: ");
            var numberOfSeats = int.Parse(Console.ReadLine());

            var query = "SELECT NumberOfSeats, Tno FROM Bookings WHERE BookingId = @BookingId AND UserId = @UserId";
            var parameters = new[] {
            new SqlParameter("@BookingId", bookingId),
            new SqlParameter("@UserId", userId)
        };

            var table = Database.ExecuteQuery(query, parameters);
            if (table.Rows.Count == 0)
            {
                Console.WriteLine("Booking not found or you do not have permission to cancel it.");
                Console.ReadLine();
                return;
            }

            var bookedSeats = (int)table.Rows[0]["NumberOfSeats"];
            var tno = (int)table.Rows[0]["Tno"];
            if (numberOfSeats > bookedSeats)
            {
                Console.WriteLine("Cannot cancel more seats than booked.");
                Console.ReadLine();
                return;
            }

            var updateSeatsQuery = "UPDATE Trains SET SeatsAvailable = SeatsAvailable + @NumberOfSeats WHERE Tno = @Tno";
            var updateSeatsParameters = new[] {
            new SqlParameter("@NumberOfSeats", numberOfSeats),
            new SqlParameter("@Tno", tno)
        };

            var updateBookingQuery = "UPDATE Bookings SET NumberOfSeats = NumberOfSeats - @NumberOfSeats WHERE BookingId = @BookingId AND UserId = @UserId";
            var updateBookingParameters = new[] {
            new SqlParameter("@NumberOfSeats", numberOfSeats),
            new SqlParameter("@BookingId", bookingId),
            new SqlParameter("@UserId", userId)
        };

            var insertCancellationQuery = "INSERT INTO Cancellations (BookingId, NumberOfSeatsCancelled, CancellationDate) VALUES (@BookingId, @NumberOfSeatsCancelled, @CancellationDate)";
            var insertCancellationParameters = new[] {
            new SqlParameter("@BookingId", bookingId),
            new SqlParameter("@NumberOfSeatsCancelled", numberOfSeats),
            new SqlParameter("@CancellationDate", DateTime.Now)
        };

            try
            {
                Database.ExecuteNonQuery(updateSeatsQuery, updateSeatsParameters);
                Database.ExecuteNonQuery(updateBookingQuery, updateBookingParameters);
                Database.ExecuteNonQuery(insertCancellationQuery, insertCancellationParameters);

                if (bookedSeats == numberOfSeats)
                {
                    var deleteCancellationsQuery = "DELETE FROM Cancellations WHERE BookingId = @BookingId";
                    var deleteCancellationsParameters = new[] {
                new SqlParameter("@BookingId", bookingId)
            };

                    Database.ExecuteNonQuery(deleteCancellationsQuery, deleteCancellationsParameters);


                    var deleteBookingQuery = "DELETE FROM Bookings WHERE BookingId = @BookingId AND UserId = @UserId";
                    var deleteBookingParameters = new[] {
                new SqlParameter("@BookingId", bookingId),
                new SqlParameter("@UserId", userId)
            };

                    Database.ExecuteNonQuery(deleteBookingQuery, deleteBookingParameters);
                }

                Console.WriteLine("Cancellation successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");//need to change-----
            }

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        private static void ViewBookings(int userId)
        {
            Console.Clear();
            var query = "SELECT * FROM Bookings WHERE UserId = @UserId";
            var parameters = new[] {
            new SqlParameter("@UserId", userId)
        };

            var table = Database.ExecuteQuery(query, parameters);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"Booking ID: {row["BookingId"]}, Train No: {row["Tno"]}, Seats: {row["NumberOfSeats"]}, Date: {row["BookingDate"]}");
                }
            }
            else
            {
                Console.WriteLine("No bookings found.");
            }

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
}
