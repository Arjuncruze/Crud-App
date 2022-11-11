using System;
using System.Data.SqlClient;

namespace Crud

{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=INBAWN170217\SQLEXPRESS;Initial Catalog=Capp;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            try
            {
                Console.WriteLine("Connection Established");
                string answer;
                do
                {
                    //Create
                    Console.WriteLine("Choose the type of crud operation that you would like to perform\n1.Creation\n2.Retrieve\n3.Update\n4.Delete");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Your Name");
                            string userName = Console.ReadLine();
                            Console.WriteLine("Enter Your Age");
                            int userAge = int.Parse(Console.ReadLine());
                            string insertQuery = "INSERT INTO DETAIL(User_Name,User_Age) Values('" + userName + "' , " + userAge + ")";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Data Inserted Successfuly");
                            sqlConnection.Close();
                            break;
                        //Retrieve
                        case 2:
                            string displayQuery = "SELECT * FROM DETAIL";
                            SqlCommand displayCommand = new SqlCommand(displayQuery, sqlConnection);
                            SqlDataReader dataReader = displayCommand.ExecuteReader();
                            while (dataReader.Read())
                            {
                                Console.WriteLine("ID: " + dataReader.GetValue(0).ToString());
                                Console.WriteLine("Name: " + dataReader.GetValue(1).ToString());
                                Console.WriteLine("Age: " + dataReader.GetValue(2).ToString());
                            }
                            dataReader.Close();
                            break;
                        //Update
                        case 3:
                            int userId;
                            int user_Age;
                            Console.WriteLine("Enter the user id that you would like to update");
                            userId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the user age");
                            user_Age = Convert.ToInt32(Console.ReadLine());
                            string updateQuery = "UPDATE DETAIL SET User_Age = " + user_Age + "WHERE User_Id = " + userId + "";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                            updateCommand.ExecuteNonQuery();
                            Console.WriteLine("Data updated Successfully");
                            sqlConnection.Close();
                            break;
                        //Delete
                        case 4:
                            Console.WriteLine("Enter the user id that you would like to DELETE");
                            userId = Convert.ToInt32(Console.ReadLine());
                            string deleteQuery = "DELETE FROM DETAIL WHERE User_Id = " + userId;
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                            deleteCommand.ExecuteNonQuery();
                            Console.WriteLine("User deleted succesfully");
                            break;
                        default:
                            Console.WriteLine("invalid input");
                            break;
                    }
                    Console.WriteLine("Do you want to continue");
                    answer = Console.ReadLine();
                } while (answer! == "yes");


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}