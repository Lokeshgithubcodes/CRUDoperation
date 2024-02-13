using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnectionSQltoSSMS
{
    public class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con;
            string connectionstring = @"Data Source=LOKESH\SQLEXPRESS;Initial Catalog=CoDB;Integrated Security=True";
            con = new SqlConnection(connectionstring);
            con.Open();
           

            
            
            try
            {


                Console.WriteLine("Connection successfully ");
                string answer;
                do
                {
                    Console.WriteLine("Select from the options below\n 1. insert\n 2. Retrieve\n 3. update\n 4. delete");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        

                        //insert data
                        case 1:
                            Console.WriteLine("Enter the name");
                            string userName = Console.ReadLine();
                            Console.WriteLine("Enter the Age");
                            int userAge = int.Parse(Console.ReadLine());
                            string insertQuery = "insert into Details(user_name, user_age) values('" + userName + "'," + userAge + ")";

                            SqlCommand insertCommand = new SqlCommand(insertQuery, con);
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Data is successfully Inserted into table!");

                            break;
                        // Retrieve

                        case 2:
                            string displayQuery = "select * from Details";
                            SqlCommand displayCommand = new SqlCommand(displayQuery, con);
                            SqlDataReader dataReader = displayCommand.ExecuteReader();
                            while (dataReader.Read())
                            {
                                Console.WriteLine("Id: " + dataReader.GetValue(0).ToString());
                                Console.WriteLine("Name: " + dataReader.GetValue(1).ToString());
                                Console.WriteLine("Age: " + dataReader.GetValue(2).ToString());
                            }
                            dataReader.Close();
                            break;

                        // Update
                        case 3:
                            int u_id;
                            int u_age;
                            Console.WriteLine("Enter the user id that u want to update");
                            u_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the age of the user to update");
                            u_age = int.Parse(Console.ReadLine());
                            string updateQuery = "update Details set user_age= " + u_age + "where user_id= " + u_id + " ";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, con);
                            updateCommand.ExecuteNonQuery();
                            Console.WriteLine("Data Updated successufully");
                            break;
                        // Delete
                        case 4:
                            Console.WriteLine("Enter the id of the record that is to be deleted");
                            int d_id = int.Parse(Console.ReadLine());
                            string deleteQuery = "delete from Details where user_id= " + d_id;
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, con);
                            deleteCommand.ExecuteNonQuery();
                            Console.WriteLine("Deleted Successfully");
                            break;

                        default:
                            Console.WriteLine("Invalid option");
                            break;



                    }
                    Console.WriteLine("Do you want to Continue");
                    answer = Console.ReadLine();

                } while (answer != "No");
                
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally { 

                con.Close();
              }
        }
    }
}
