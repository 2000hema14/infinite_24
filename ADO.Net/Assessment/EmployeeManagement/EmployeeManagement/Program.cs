using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementA
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=ICS-LT-68Q0LQ3;Database=EmployeeManagementDB;Integrated Security=True;";

            Console.WriteLine("Enter Employee_name:");
            string empName = Console.ReadLine();

            Console.WriteLine("Enter Employee_Salary:");
            decimal empSal = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter employee type ( Permanent (P),Contract(C)):");
            char empType = Console.ReadLine()[0];

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("AddEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EmpName", empName);
                        command.Parameters.AddWithValue("@Empsal", empSal);
                        command.Parameters.AddWithValue("@Emptype", empType);
                        command.ExecuteNonQuery();

                        Console.WriteLine("Employee Management details added successfully!");
                    }

                    
                    Console.WriteLine("All Employee Rows:");
                    using (SqlCommand selectCommand = new SqlCommand("SELECT * FROM Employee_Details", connection))
                    {
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"Empno: {reader["Empno"]}, EmpName: {reader["EmpName"]}, Empsal: {reader["Empsal"]}, Emptype: {reader["Emptype"]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
