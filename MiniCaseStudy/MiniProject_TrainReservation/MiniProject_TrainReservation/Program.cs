﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MiniProject_TrainReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                        WELCOME TO RAILWAYS                    ");
            Console.ResetColor();
            Console.WriteLine();



            // Assume admin login details
            string adminUsername = "admin";
            string adminPassword = "admin@123";

            // User login details
            string userLoginId = "user";
            string userPassword = "user@123";

            Console.WriteLine("Select Option:");
            Console.WriteLine("1. Admin Login");
            Console.WriteLine("2. User Login");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AdminLogin(adminUsername, adminPassword);
                    break;
                case "2":
                    UserLogin(userLoginId, userPassword);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.ReadKey();
        }

        static void AdminLogin(string adminUsername, string adminPassword)
        {
            Console.WriteLine("\nAdmin Login:");
            Console.Write("Username: ");
            string usernameInput = Console.ReadLine();
            Console.Write("Password: ");
            string passwordInput = Console.ReadLine();

            if (usernameInput == adminUsername && passwordInput == adminPassword)
            {
                Console.Clear();
                Console.WriteLine("Admin logged in successfully.");

                while (true)
                {
                    Console.WriteLine("Select Option:");
                    Console.WriteLine("1. Add Train");
                    Console.WriteLine("2. Update Train");
                    Console.WriteLine("3. Delete Train");
                    Console.WriteLine("4. View Bookings");
                    Console.WriteLine("5. View Cancellations");
                    Console.WriteLine("6. Exit");
                    Console.Write("Enter your choice: ");
                    string adminChoice = Console.ReadLine();

                    switch (adminChoice)
                    {
                        case "1":
                            AddTrain();
                            break;
                        case "2":
                            UpdateTrain();
                            break;
                        case "3":
                            Console.Write("Enter Train ID to delete: ");
                            int trainIdToDelete = Convert.ToInt32(Console.ReadLine());
                            DeleteTrain(trainIdToDelete);
                            break;
                        case "4":
                            ViewBookings();
                            break;
                        case "5":
                            ViewCancellations();
                            break;
                        case "6":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }

                    Console.Write("Do you want to perform another action? (yes/no): ");
                    string continueChoice = Console.ReadLine();
                    if (continueChoice.ToLower() != "yes")
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid admin login credentials.");
            }
        }

        static void AddTrain()
        {
            Console.Clear();
            Console.WriteLine("\nAdd Train:");

            // Prompt the user for train details

            Console.Write("Enter Train ID: ");
            int trainId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Class: ");
            string trainClass = Console.ReadLine();
            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();
            Console.Write("Enter From Station: ");
            string fromStation = Console.ReadLine();
            Console.Write("Enter To Station: ");
            string toStation = Console.ReadLine();
            Console.Write("Enter Total Berths: ");
            int totalBerths = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Available Berths: ");
            int availableBerths = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Fare: ");
            decimal fare = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Is Active (Active/Inactive): ");
            string isActive = Console.ReadLine();


            using (var context = new MiniCaseStudyDBEntities1())
            {
                // Check if the train already exists
                var existingTrain = context.trains.FirstOrDefault(t => t.Train_Id == trainId);
                if (existingTrain != null)
                {
                    Console.WriteLine("Error: Train with the same ID already exists.");
                    return;
                }

                // Create a new train entity
                var newTrain = new train
                {
                    Train_Id = trainId,
                    Class = trainClass,
                    TrainName = trainName,
                    FromStation = fromStation,
                    ToStation = toStation,
                    TotalBerths = totalBerths,
                    AvailableBerths = availableBerths,
                    Fare = fare,
                    IsActive = isActive
                };

                // Add the new train to the database
                context.trains.Add(newTrain);
                context.SaveChanges();

                Console.WriteLine("Train added successfully.");
            }
        }
        static void UpdateTrain()
        {
            Console.Clear();
            Console.WriteLine("\nUpdate Train:");

            // Prompt the user for train details to update

            Console.Write("Enter Train ID to update: ");
            int trainId = Convert.ToInt32(Console.ReadLine());

            using (var context = new MiniCaseStudyDBEntities1())
            {
                // Check if the train exists
                var train = context.trains.FirstOrDefault(t => t.Train_Id == trainId);
                if (train != null)
                {
                    Console.WriteLine("Enter new details:");

                    Console.Write("New Train Name: ");
                    string newTrainName = Console.ReadLine();
                    Console.Write("New From Station: ");
                    string newFromStation = Console.ReadLine();
                    Console.Write("New To Station: ");
                    string newToStation = Console.ReadLine();
                    Console.Write("New Total Berths: ");
                    int newTotalBerths = Convert.ToInt32(Console.ReadLine());
                    Console.Write("New Available Berths: ");
                    int newAvailableBerths = Convert.ToInt32(Console.ReadLine());
                    Console.Write("New Fare: ");
                    decimal newFare = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Is Active (Active/Inactive): ");
                    string newIsActive = Console.ReadLine();

                    // Update train details
                    train.TrainName = newTrainName;
                    train.FromStation = newFromStation;
                    train.ToStation = newToStation;
                    train.TotalBerths = newTotalBerths;
                    train.AvailableBerths = newAvailableBerths;
                    train.Fare = newFare;
                    train.IsActive = newIsActive;

                    // Save changes to the database
                    context.SaveChanges();

                    Console.WriteLine("Train details updated successfully.");
                }
                else
                {
                    Console.WriteLine("Error: Train not found.");
                }
            }
        }

        static void DeleteTrain(int trainId)
        {
            Console.Clear();
            Console.Clear();
            using (var context = new MiniCaseStudyDBEntities1())
            {
                var trainToDelete = context.trains.FirstOrDefault(t => t.Train_Id == trainId);
                if (trainToDelete != null)
                {
                    if (trainToDelete.IsActive.Equals("Active", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("This train is active. Are you sure you want to delete it? (yes/no): ");
                        string confirmation = Console.ReadLine();
                        if (confirmation.ToLower() == "yes")
                        {
                            // Soft delete by setting IsActive to "Inactive"
                            trainToDelete.IsActive = "Inactive";
                            context.SaveChanges();
                            Console.WriteLine("Train deactivated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Train deactivation cancelled.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Train is already inactive.");
                    }
                }
                else
                {
                    Console.WriteLine("Train not found.");
                }
            }
        }





        static void ViewBookings()
        {
            Console.Clear();
            using (var context = new MiniCaseStudyDBEntities1())
            {
                var bookings = context.ViewBookings().ToList();
                Console.WriteLine("Bookings:");
                foreach (var booking in bookings)
                {
                    Console.WriteLine($"Booking ID: {booking.Booking_Id}, Train ID: {booking.Train_Id}, Class: {booking.Class}, Passenger Name: {booking.PassengerName}");
                }
            }
        }

        static void ViewCancellations()
        {
            Console.Clear();
            using (var context = new MiniCaseStudyDBEntities1())
            {
                var cancellations = context.ViewCancellations().ToList();
                Console.WriteLine("Cancellations:");
                foreach (var cancellation in cancellations)
                {
                    Console.WriteLine($"Cancellation ID: {cancellation.Cancellation_Id}, Booking ID: {cancellation.BookingId}, Seats Cancelled: {cancellation.SeatsCancelled}");
                }
            }
        }


        static void UserLogin(string userLoginId, string userPassword)
        {
            Console.Clear();
            Console.WriteLine("\nUser Login:");
            Console.Write("Login ID: ");
            string loginIdInput = Console.ReadLine();
            Console.Write("Password: ");
            string passwordInput = Console.ReadLine();

            if (loginIdInput == userLoginId && passwordInput == userPassword)
            {
                Console.WriteLine("User logged in successfully.");

                while (true)
                {
                    Console.WriteLine("\nSelect Option:");
                    Console.WriteLine("1. Book Ticket");
                    Console.WriteLine("2. Cancel Ticket");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice: ");
                    string userChoice = Console.ReadLine();

                    switch (userChoice)
                    {
                        case "1":
                            Console.WriteLine("\nAvailable Trains:");
                            DisplayAvailableTrainsForBooking();
                            Console.WriteLine("\nPassenger Booking:");
                            BookTicket();
                            break;
                        case "2":
                            Console.WriteLine("\nPassenger Cancellation:");
                            CancelTicket();
                            break;
                        case "3":
                            return;
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid user login credentials.");
            }
        }

        static void DisplayAvailableTrainsForBooking()
        {
            using (var context = new MiniCaseStudyDBEntities1())
            {
                var trains = context.trains.Where(t => t.IsActive.Equals("Active", StringComparison.OrdinalIgnoreCase)).ToList();
                if (trains.Any())
                {
                    Console.WriteLine("Available Trains:");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("| Train ID |   Class   |     Train Name          |   From     |    To      | Available Berths   |      Fare                    |");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------- -------------");
                    foreach (var train in trains)
                    {
                        Console.WriteLine($"| {train.Train_Id,-9} | {train.Class,-9}  | {train.TrainName,-12}   | {train.FromStation,-8}  | {train.ToStation,-8} | {train.AvailableBerths,-17} | {train.Fare,-8:C}   |");
                    }
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("No available trains for booking.");
                }
            }
        }

        static void BookTicket()
        {
            Console.WriteLine("Booking a ticket...");

            // Prompt the user for necessary details
            Console.Write("Enter Train ID: ");
            int trainId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Class: ");
            string trainClass = Console.ReadLine();
            Console.Write("Enter Number of Seats to Book: ");
            int numberOfSeats = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Departure Date (yyyy-MM-dd): ");
            DateTime departureDate = DateTime.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSeats; i++)
            {
                Console.WriteLine($"Ticket {i + 1}:");
                Console.Write("Enter Passenger Name: ");
                string passengerName = Console.ReadLine();
               

                using (var context = new MiniCaseStudyDBEntities1())
                {
                    // Check if the train is active
                    var train = context.trains.FirstOrDefault(t => t.Train_Id == trainId && t.Class == trainClass);

                    if (train != null && train.IsActive.Equals("Active", StringComparison.OrdinalIgnoreCase))
                    {
                        // Check if there are enough available berths
                        if (train.AvailableBerths > 0)
                        {
                            // Book the ticket
                            decimal totalAmount = (decimal)train.Fare;
                            var booking = new Booking
                            {
                                Train_Id = trainId,
                                Class = trainClass,
                                PassengerName = passengerName,
                                SeatsBooked = 1, // Book one seat at a time
                                BookingDate = DateTime.Now,
                                DepartureDate = departureDate,
                                TotalAmount = totalAmount // Calculate total amount
                            };

                            // Update available berths
                            train.AvailableBerths--;

                            // Add booking to the database
                            context.Bookings.Add(booking);
                            context.SaveChanges();

                            // Display booking details
                            Console.WriteLine($"Ticket {i + 1} booked successfully!");
                            Console.WriteLine();
                            Console.WriteLine("Ticket Details:");
                            Console.WriteLine($"Booking ID: {booking.Booking_Id}");
                            Console.WriteLine($"Train ID: {booking.Train_Id}");
                            Console.WriteLine($"Class: {booking.Class}");
                            Console.WriteLine($"Passenger Name: {booking.PassengerName}");
                            Console.WriteLine($"Departure Date: {booking.DepartureDate}");
                            Console.WriteLine($"Total Amount: {booking.TotalAmount:C}");
                        }
                        else
                        {
                            Console.WriteLine("Error: Not enough available berths.");
                            break; // Stop booking if there are no available berths
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: The selected train is not active or does not exist.");
                        break; // Stop booking if the train is not active or does not exist
                    }
                }
            }
        }

        static void CancelTicket()
        {
            Console.WriteLine("Canceling a ticket...");

            // Prompt the user for the booking details
            Console.Write("Enter Booking ID: ");
            int bookingId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Number of Seats to Cancel: ");
            int seatsToCancel = Convert.ToInt32(Console.ReadLine());

            using (var context = new MiniCaseStudyDBEntities1())
            {
                // Retrieve the booking
                var booking = context.Bookings.FirstOrDefault(b => b.Booking_Id == bookingId);
                if (booking != null)
                {
                    // Calculate refund amount
                    decimal refundAmount = (decimal)(seatsToCancel * booking.train.Fare);

                    // Cancel the ticket
                    // Check if the requested number of seats to cancel is less than or equal to the booked seats
                    if (seatsToCancel <= booking.SeatsBooked)
                    {
                        // Add cancellation details to the CancellationDetails table
                        var cancellationDetails = new CancellationDetail
                        {
                            BookingId = bookingId,
                            SeatsCancelled = seatsToCancel,
                            RefundAmount = refundAmount,
                            CancellationDate = DateTime.Now
                        };

                        context.CancellationDetails.Add(cancellationDetails);

                        // Update the booked seats
                        booking.SeatsBooked -= seatsToCancel;

                        // Soft delete if all seats are canceled
                        if (booking.SeatsBooked == 0)
                        {
                            context.Bookings.Remove(booking);
                        }

                        _ = context.SaveChanges();
                        Console.WriteLine($"Ticket canceled successfully! Refund Amount: {refundAmount:C}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid number of seats to cancel.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Booking ID not found.");
                }
            }
        }
    }
}