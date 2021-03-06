using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace Database_gui_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillCombo();
            FillCombo1();
            FillCombo2();
            FillCombo4();
            FillCombo5();
            RundemoHotel();
            RundemoGuest();
            RunDemoBooking();
            RunDemoFacilities();
            RunDemoRooms();
            label6.Text = "";
            label7.Text = "";
            label18.Text = "";
            label19.Text = "";
            label24.Text = "";
            label25.Text = "";
            label22.Text = "";
            label23.Text = "";
            label31.Text = "";
            label30.Text = "";
            label32.Text = "";
            label33.Text = "";
        }

        string connectionString =
            "Data Source=178.155.224.44;Initial Catalog=Hotel;User ID=sa;Password=2021Sommer";

        private int sec = 3000;

        #region RunTables

        void RundemoHotel()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter data1 = new SqlDataAdapter("Select * from DemoHotel", connection);
                connection.Open();
                DataTable diagram1 = new DataTable();
                data1.Fill(diagram1);

                dgv1.DataSource = diagram1;
                connection.Close();
            }
        }

        void RundemoGuest()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter data2 = new SqlDataAdapter("Select * from  DemoGuest ", connection);
                connection.Open();
                DataTable diagram2 = new DataTable();
                data2.Fill(diagram2);

                dgv2.DataSource = diagram2;
                connection.Close();
            }
        }

        void RunDemoBooking()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter data3 = new SqlDataAdapter("Select * from  DemoBooking ", connection);
                connection.Open();
                DataTable diagram3 = new DataTable();
                data3.Fill(diagram3);

                dgv3.DataSource = diagram3;
                connection.Close();
            }
        }

        void RunDemoFacilities()
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                SqlDataAdapter data4 = new SqlDataAdapter("Select * from  DemoFacilities ", connection);
                connection.Open();
                DataTable diagram4 = new DataTable();
                data4.Fill(diagram4);

                dgv4.DataSource = diagram4;
                connection.Close();
            }
        }

        void RunDemoRooms()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter data5 = new SqlDataAdapter("Select * from  DemoRoom ", connection);
                connection.Open();
                DataTable diagram5 = new DataTable();
                data5.Fill(diagram5);

                dgv5.DataSource = diagram5;
                connection.Close();
            }
        }

        #endregion

        #region FillCombo

        void FillCombo()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command6 = new SqlCommand("Select * from DemoHotel; ", con);
                SqlDataReader myReader;
                con.Open();

                myReader = command6.ExecuteReader();

                while (myReader.Read())
                {
                    string sName = myReader.GetString("Name");
                    comboBox2.Items.Add(sName);
                }

                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy-dd-MM";

                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = "yyyy-dd-MM";
            }
        }

        void FillCombo1()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command7 = new SqlCommand("Select * from DemoHotel; ", con);
                SqlDataReader myReader;
                con.Open();
                myReader = command7.ExecuteReader();
                while (myReader.Read())
                {
                    int sName = myReader.GetInt32("Hotel_No");
                    //string sName = myReader.GetString("Name");
                    comboBox3.Items.Add(sName);
                }
            }

        }

        void FillCombo2()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command8 = new SqlCommand("Select * from DemoGuest; ", con);
                SqlDataReader myReader;
                con.Open();
                myReader = command8.ExecuteReader();
                while (myReader.Read())
                {
                    int sName = myReader.GetInt32("Guest_No");
                    comboBox4.Items.Add(sName);
                }
            }
        }

        void FillCombo3()
        {
            SqlConnection con = new SqlConnection(
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Hotel; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            SqlCommand command9 = new SqlCommand("Select * from DemoRoom; ", con);
            SqlDataReader myReader;
            con.Open();
            myReader = command9.ExecuteReader();
            while (myReader.Read())
            {
                int sName = myReader.GetInt32("Room_No");
                comboBox5.Items.Add(sName);
            }
        }

        void FillCombo4()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command7 = new SqlCommand("Select * from DemoHotel; ", con);
                SqlDataReader myReader;
                con.Open();
                myReader = command7.ExecuteReader();
                while (myReader.Read())
                {
                    int sName = myReader.GetInt32("Hotel_No");
                    //string sName = myReader.GetString("Name");
                    comboBox1.Items.Add(sName);
                }
            }
        }

        void FillCombo5()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command7 = new SqlCommand("Select * from DemoHotel; ", con);
                SqlDataReader myReader;
                con.Open();
                myReader = command7.ExecuteReader();
                while (myReader.Read())
                {
                    int sName = myReader.GetInt32("Hotel_No");
                    //string sName = myReader.GetString("Name");
                    comboBox6.Items.Add(sName);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "Select Room_No from DemoRoom Where Hotel_No = " + comboBox3.Text + "; ";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                SqlDataReader myReader;
                con.Open();
                myReader = cmd.ExecuteReader();
                comboBox5.Items.Clear();
                while (myReader.Read())
                {
                    int sName = myReader.GetInt32("Room_No");
                    //string sName = myReader.GetString("Name");
                    comboBox5.Items.Add(sName);
                }
            }
        }

        #endregion

        #region Hotel

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlException exception1 = new SqlException($"ID {textBox1.Text} eksistere allerede");

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                label6.Text = "Udfyld venligst felterne";

                var t = new Timer();
                t.Interval = sec; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    label6.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else
            {
                string query = "INSERT INTO DemoHotel (Hotel_No, Name, Address) VALUES(" + textBox1.Text + ",'" +
                               textBox2.Text + "', '" + textBox3.Text + "');";
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        object o = cmd.ExecuteReader();

                        RundemoHotel();

                        label7.Text = "Tabel er blevet indsat";

                        var t = new Timer();
                        t.Interval = sec; // it will Tick in 3 seconds
                        t.Tick += (s, e) =>
                        {
                            label7.Text = "";
                            t.Stop();
                        };
                        t.Start();

                        con.Close();
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        label6.Text = $"{exception1.Message}";

                        var t = new Timer();
                        t.Interval = sec; // it will Tick in 3 seconds
                        t.Tick += (s, e) =>
                        {
                            label6.Text = "";
                            t.Stop();
                        };
                        t.Start();

                        con.Close();

                    }
                }
            }
        }

        void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                label6.Text = "Udfyld venligst felterne";

                var t = new Timer();
                t.Interval = sec; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    label6.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else
            {
                string query = "Update DemoHotel SET Hotel_No = " + this.textBox1.Text + ", Name =  '" +
                               this.textBox2.Text +
                               "', Address =  '" + this.textBox3.Text + "'  WHERE Hotel_No =" + this.textBox1.Text +
                               ";";
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    object o = cmd.ExecuteReader();

                    RundemoHotel();

                    label7.Text = $"{textBox2.Text} Tabel er blevet opdateret";

                    var t = new Timer();
                    t.Interval = sec; // it will Tick in 3 seconds
                    t.Tick += (s, e) =>
                    {
                        label7.Text = "";
                        t.Stop();
                    };
                    t.Start();
                    con.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                label6.Text = "Udfyld venligst ID feltet";

                var t = new Timer();
                t.Interval = sec; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    label6.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else
            {
                string query = "DELETE FROM DemoHotel WHERE Hotel_No = (" + textBox1.Text + ");";
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    object o = cmd.ExecuteReader();

                    RundemoHotel();

                    label7.Text = "Tabel er blevet slettet";

                    var t = new Timer();
                    t.Interval = sec; // it will Tick in 3 seconds
                    t.Tick += (s, e) =>
                    {
                        label7.Text = "";
                        t.Stop();
                    };
                    t.Start();

                    con.Close();
                }
            }
        }
        #endregion

        #region Guest

        private void button21_Click(object sender, EventArgs e)
        {
            SqlException exception3 = new SqlException($"Der skete en fejl, prøv igen");

            if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                label23.Text = "Udfyld venligst felterne";

                var t = new Timer();
                t.Interval = sec; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    label23.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else
            {
                try
                {
                    string query = "Update DemoGuest SET Guest_No = " + this.textBox4.Text +
                                   ", Name =  '" + this.textBox5.Text +
                                   "', Address =  '" + this.textBox6.Text +
                                   "' WHERE Guest_No =" + this.textBox4.Text + ";";
                    using (SqlConnection con = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        object o = cmd.ExecuteReader();

                        RundemoGuest();

                        label22.Text = $"{textBox4.Text} Tabel er blevet opdateret";

                        var t = new Timer();
                        t.Interval = sec; // it will Tick in 3 seconds
                        t.Tick += (s, e) =>
                        {
                            label22.Text = "";
                            t.Stop();
                        };
                        t.Start();
                        con.Close();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    label23.Text = $"{exception3.Message}";

                    var t = new Timer();
                    t.Interval = sec; // it will Tick in 3 seconds
                    t.Tick += (s, e) =>
                    {
                        label23.Text = "";
                        t.Stop();
                    };
                    t.Start();
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SqlException exception3 = new SqlException($"Der skete en fejl, prøv igen");

            if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                label23.Text = "Udfyld venligst felterne";

                var t = new Timer();
                t.Interval = sec; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    label23.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else
            {

                try
                {
                    string query = "INSERT INTO DemoGuest (Guest_No, Name, Address) VALUES(" + textBox4.Text + ",'" +
                                   textBox5.Text + "', '" + textBox6.Text + "');";
                    using (SqlConnection con = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        object o = cmd.ExecuteReader();

                        RundemoGuest();

                        label22.Text = "Tabel er blevet indsat";

                        var t = new Timer();
                        t.Interval = sec; // it will Tick in 3 seconds
                        t.Tick += (s, e) =>
                        {
                            label22.Text = "";
                            t.Stop();
                        };
                        t.Start();
                        con.Close();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {

                    label23.Text = $"{exception3.Message}";

                    var t = new Timer();
                    t.Interval = sec; // it will Tick in 3 seconds
                    t.Tick += (s, e) =>
                    {
                        label23.Text = "";
                        t.Stop();
                    };
                    t.Start();
                }
            }
        }
        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                label23.Text = "Udfyld venligst ID feltet";

                var t = new Timer();
                t.Interval = sec; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    label23.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else
            {
                string query = "DELETE FROM DemoGuest WHERE Guest_No = (" + textBox4.Text + ");";
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    object o = cmd.ExecuteReader();

                    RundemoGuest();

                    label22.Text = "Tabel er blevet slettet";

                    var t = new Timer();
                    t.Interval = sec; // it will Tick in 3 seconds
                    t.Tick += (s, e) =>
                    {
                        label22.Text = "";
                        t.Stop();
                    };
                    t.Start();
                    con.Close();
                }
            }

        }

        #endregion

        #region Booking
        
        private void button14_Click(object sender, EventArgs e)
        {
            SqlException exception2 = new SqlException($"Der skete en fejl, prøv igen");

            if (textBox7.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "")
            {
                label18.Text = "Udfyld venligst felterne";

                var t = new Timer();
                t.Interval = sec; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    label18.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else
            {
                if (dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date)
                {
                    if (dateTimePicker1.Value.Date == dateTimePicker2.Value.Date)
                    {
                        label18.Text = "Fra og til dato må ikke være den samme";

                        var t = new Timer();
                        t.Interval = sec; // it will Tick in 3 seconds
                        t.Tick += (s, e) =>
                        {
                            label18.Text = "";
                            t.Stop();
                        };
                        t.Start();
                    }
                    else
                    {
                        try
                        {
                            string query =
                                "SET IDENTITY_INSERT DemoBooking ON INSERT INTO DemoBooking (Booking_id, Hotel_No, Guest_No, Date_From, Date_To, Room_No) VALUES(" +
                                textBox7.Text + "," + comboBox3.Text + ", " + comboBox4.Text + ", '" +
                                dateTimePicker1.Value.Date.ToString() + "' , '" +
                                dateTimePicker2.Value.Date.ToString() +
                                "', " + comboBox5.Text + ") SET IDENTITY_INSERT DemoBooking OFF;";
                            using (SqlConnection con = new SqlConnection(connectionString))
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                con.Open();
                                object o = cmd.ExecuteReader();

                                RunDemoBooking();

                                label19.Text = "Tabel er blevet indsat";

                                var t = new Timer();
                                t.Interval = sec; // it will Tick in 3 seconds
                                t.Tick += (s, e) =>
                                {
                                    label19.Text = "";
                                    t.Stop();
                                };
                                t.Start();
                                con.Close();
                            }
                        }
                        catch (System.Data.SqlClient.SqlException)
                        {
                            label18.Text = $"{exception2.Message}";

                            var t = new Timer();
                            t.Interval = sec; // it will Tick in 3 seconds
                            t.Tick += (s, e) =>
                            {
                                label18.Text = "";
                                t.Stop();
                            };
                            t.Start();
                        }
                    }
                }
                else
                {
                    label18.Text = "Til dato skal være større end fra dato";

                    var t = new Timer();
                    t.Interval = sec; // it will Tick in 3 seconds
                    t.Tick += (s, e) =>
                    {
                        label18.Text = "";
                        t.Stop();
                    };
                    t.Start();
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                label18.Text = "Udfyld venligst ID feltet";

                var t = new Timer();
                t.Interval = sec; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    label18.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else
            {
                string query = "DELETE FROM DemoBooking WHERE Booking_id = (" + textBox7.Text + ");";
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    object o = cmd.ExecuteReader();

                    RunDemoBooking();

                    label19.Text = "Tabel er blevet slettet";

                    var t = new Timer();
                    t.Interval = sec; // it will Tick in 3 seconds
                    t.Tick += (s, e) =>
                    {
                        label19.Text = "";
                        t.Stop();
                    };
                    t.Start();
                    con.Close();
                }
            }
        }

        #endregion

        #region Facilities

        private void button23_Click(object sender, EventArgs e)
        {
            SqlException exception3 = new SqlException($"Der skete en fejl, prøv igen");

            if (textBox10.Text == "" || comboBox6.Text == "" || textBox12.Text == "" || textBox13.Text == "")
            {
                label31.Text = "Udfyld venligst felterne";

                var t = new Timer();
                t.Interval = sec; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    label31.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else
            {

                try
                {
                    string query = "INSERT INTO DemoFacilities (Facilities_No, Hotel_No, Facilities, Price) VALUES(" +
                                   textBox10.Text + "," +
                                   comboBox6.Text + ", '" + textBox12.Text + "', " + textBox13.Text + ");";
                    using (SqlConnection con = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        object o = cmd.ExecuteReader();

                        RunDemoFacilities();

                        label30.Text = "Tabel er blevet indsat";

                        var t = new Timer();
                        t.Interval = sec; // it will Tick in 3 seconds
                        t.Tick += (s, e) =>
                        {
                            label30.Text = "";
                            t.Stop();
                        };
                        t.Start();
                        con.Close();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {

                    label31.Text = $"{exception3.Message}";

                    var t = new Timer();
                    t.Interval = sec; // it will Tick in 3 seconds
                    t.Tick += (s, e) =>
                    {
                        label31.Text = "";
                        t.Stop();
                    };
                    t.Start();
                }
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            SqlException exception3 = new SqlException($"Der skete en fejl, prøv igen");

            if (textBox10.Text == "" || comboBox6.Text == "" || textBox12.Text == "" || textBox13.Text == "")
            {
                label31.Text = "Udfyld venligst felterne";

                var t = new Timer();
                t.Interval = sec; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    label31.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else
            {
                try
                {
                    string query = "Update DemoFacilities SET Facilities_No = " +
                                   this.textBox10.Text + ", Hotel_No =  " +
                                   this.comboBox6.Text +
                                   ", Facilities = '" + this.textBox12.Text + "', Price = " +
                                   this.textBox13.Text + " WHERE Facilities_No =" +
                                   this.textBox10.Text + ";";
                    using (SqlConnection con = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        object o = cmd.ExecuteReader();

                        RunDemoFacilities();

                        label30.Text = $"{textBox10.Text} Tabel er blevet opdateret";

                        var t = new Timer();
                        t.Interval = sec; // it will Tick in 3 seconds
                        t.Tick += (s, e) =>
                        {
                            label30.Text = "";
                            t.Stop();
                        };
                        t.Start();
                        con.Close();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    label31.Text = $"{exception3.Message}";

                    var t = new Timer();
                    t.Interval = sec; // it will Tick in 3 seconds
                    t.Tick += (s, e) =>
                    {
                        label31.Text = "";
                        t.Stop();
                    };
                    t.Start();
                }
            }
        }
        private void button25_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                label31.Text = "Udfyld venligst ID feltet";

                var t = new Timer();
                t.Interval = sec; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    label31.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else
            {
                string query = "DELETE FROM DemoFacilities WHERE Facilities_No = (" + textBox10.Text + ");";
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    object o = cmd.ExecuteReader();

                    RunDemoFacilities();

                    label30.Text = "Tabel er blevet slettet";

                    var t = new Timer();
                    t.Interval = sec; // it will Tick in 3 seconds
                    t.Tick += (s, e) =>
                    {
                        label30.Text = "";
                        t.Stop();
                    };
                    t.Start();

                    con.Close();
                }
            }
        }
        #endregion

        #region Rooms

        private void button17_Click(object sender, EventArgs e)
        {
            SqlException exception3 = new SqlException($"Der skete en fejl, prøv igen");

            if (textBox11.Text == "" || comboBox1.Text == "" || textBox9.Text == "" || textBox8.Text == "")
            {
                label25.Text = "Udfyld venligst felterne";

                var t = new Timer();
                t.Interval = sec; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    label25.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else
            {
                try
                {
                    if (textBox9.Text == "S" || textBox9.Text == "D" || textBox9.Text == "F")
                    {
                        string query = "INSERT INTO DemoRoom (Room_No, Hotel_No, Types, Price) VALUES(" +
                                       textBox11.Text +
                                       "," + comboBox1.Text + ", '" + textBox9.Text + "', " + textBox8.Text + ");";
                        using (SqlConnection con = new SqlConnection(connectionString))
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            con.Open();
                            object o = cmd.ExecuteReader();

                            RunDemoRooms();

                            label24.Text = "Tabel er blevet indsat";

                            var t = new Timer();
                            t.Interval = sec; // it will Tick in 3 seconds
                            t.Tick += (s, e) =>
                            {
                                label24.Text = "";
                                t.Stop();
                            };
                            t.Start();

                            con.Close();
                        }

                    }
                    else
                    {
                        label25.Text = "Type skal enten være S, D eller F";

                        var t = new Timer();
                        t.Interval = sec; // it will Tick in 3 seconds
                        t.Tick += (s, e) =>
                        {
                            label25.Text = "";
                            t.Stop();
                        };
                        t.Start();
                    }

                }
                catch (System.Data.SqlClient.SqlException)
                {

                    label25.Text = $"{exception3.Message}";

                    var t = new Timer();
                    t.Interval = sec; // it will Tick in 3 seconds
                    t.Tick += (s, e) =>
                    {
                        label25.Text = "";
                        t.Stop();
                    };
                    t.Start();
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SqlException exception3 = new SqlException($"Der skete en fejl, prøv igen");

            if (textBox11.Text == "" || comboBox1.Text == "" || textBox9.Text == "" || textBox8.Text == "")
            {
                label25.Text = "Udfyld venligst felterne";

                var t = new Timer();
                t.Interval = sec; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    label25.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else
            {

                if (textBox9.Text == "S" || textBox9.Text == "D" || textBox9.Text == "F")
                {
                    try
                    {
                        string query = "Update DemoRoom SET Room_No = " + this.textBox11.Text + ", Hotel_No =  '" +
                                       this.comboBox1.Text + "', Types =  '" + this.textBox9.Text + "', Price = " +
                                       this.textBox8.Text +
                                       "  WHERE Room_No =" + this.textBox1.Text + ";";
                        using (SqlConnection con = new SqlConnection(connectionString))
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            con.Open();
                            object o = cmd.ExecuteReader();

                            RunDemoRooms();

                            label24.Text = $"{textBox11.Text} Tabel er blevet opdateret";

                            var t = new Timer();
                            t.Interval = sec; // it will Tick in 3 seconds
                            t.Tick += (s, e) =>
                            {
                                label24.Text = "";
                                t.Stop();
                            };
                            t.Start();
                            con.Close();
                        }
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {

                        label25.Text = $"{exception3.Message}";

                        var t = new Timer();
                        t.Interval = sec; // it will Tick in 3 seconds
                        t.Tick += (s, e) =>
                        {
                            label25.Text = "";
                            t.Stop();
                        };
                        t.Start();
                    }
                }
                else
                {
                    label25.Text = "Type skal enten være S, D eller F";

                    var t = new Timer();
                    t.Interval = sec; // it will Tick in 3 seconds
                    t.Tick += (s, e) =>
                    {
                        label25.Text = "";
                        t.Stop();
                    };
                    t.Start();
                }
            }
        }
        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                label25.Text = "Udfyld venligst ID feltet";

                var t = new Timer();
                t.Interval = sec; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    label25.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else
            {
                string query = "DELETE FROM DemoRoom WHERE Room_No = (" + textBox11.Text + ");";
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    object o = cmd.ExecuteReader();

                    RunDemoRooms();

                    label24.Text = "Tabel er blevet slettet";

                    var t = new Timer();
                    t.Interval = sec; // it will Tick in 3 seconds
                    t.Tick += (s, e) =>
                    {
                        label24.Text = "";
                        t.Stop();
                    };
                    t.Start();

                    con.Close();
                }
            }
        }


        #endregion

        #region CustomSql

        private void button15_Click(object sender, EventArgs e)
        {
            
            string input = textBox14.Text.TrimStart();
            string query = input;
            
            //string queryins = textBox14.Text;
            SqlException exception3 = new SqlException($"Fejl i SQL, ret i teksten og prøv igen :)");
            SqlException exception4 = new SqlException($"Fejl i SQL, ret i teksten og prøv igen :)");
            if (textBox14.Text == "")
            {
                label32.Text = "Udfyld venligst feltet";
                var t = new Timer();
                t.Interval = sec; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    label32.Text = "";
                    t.Stop();
                };
                t.Start();
            }
            else
            {
                if(input.Contains("drop"))
                {
                    label32.Text = "Drop er ikke et tilladt ord at bruge";
                    var t = new Timer();
                    t.Interval = sec; // it will Tick in 3 seconds
                    t.Tick += (s, e) =>
                    {
                        label32.Text = "";
                        t.Stop();
                    };
                    t.Start();
                }
                else
                {
                    if (input.Contains("Delete") || input.StartsWith("delete"))
                    {
                        if (input.Contains("where") || input.Contains("Where"))
                        {
                            try
                            {
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd1 = new SqlCommand(query, connection))
                                        cmd1.ExecuteNonQuery();

                                    RundemoHotel();
                                    RundemoGuest();
                                    RunDemoBooking();
                                    RunDemoFacilities();
                                    RunDemoRooms();

                                    SqlDataAdapter data2 = new SqlDataAdapter(query, connection);
                                    DataTable diagram2 = new DataTable();
                                    data2.Fill(diagram2);

                                    dataGridView1.DataSource = diagram2;
                                    connection.Close();

                                    label33.Text = "Tabel er blevet slettet";
                                    var t = new Timer();
                                    t.Interval = sec; // it will Tick in 3 seconds
                                    t.Tick += (s, e) =>
                                    {
                                        label33.Text = "";
                                        t.Stop();
                                    };
                                    t.Start();
                                }
                            }
                            catch (System.Data.SqlClient.SqlException)
                            {

                                label32.Text = $"{exception3.Message}";

                                var t = new Timer();
                                t.Interval = sec; // it will Tick in 3 seconds
                                t.Tick += (s, e) =>
                                {
                                    label32.Text = "";
                                    t.Stop();
                                };
                                t.Start();
                            }
                        }
                        else
                        {
                            label32.Text = "Delete sætning Skal indholde where";
                            var t = new Timer();
                            t.Interval = sec; // it will Tick in 3 seconds
                            t.Tick += (s, e) =>
                            {
                                label32.Text = "";
                                t.Stop();
                            };
                            t.Start();

                        }
                    }
                    else
                    {

                        if (input.StartsWith("Greate") || input.StartsWith("greate"))
                        {
                            label32.Text = "Det er ikke tilladt at lave en ny tabel";

                            var t = new Timer();
                            t.Interval = sec; // it will Tick in 3 seconds
                            t.Tick += (s, e) =>
                            {
                                label32.Text = "";
                                t.Stop();
                            };
                            t.Start();

                        }
                        else
                        {
                            try
                            {
                                if (input.StartsWith("SELECT") || input.StartsWith("select"))
                                {

                                    using (SqlConnection connection = new SqlConnection(connectionString))
                                    {
                                        connection.Open();
                                        SqlDataAdapter data3 = new SqlDataAdapter(query, connection);
                                        DataTable diagram3 = new DataTable();
                                        data3.Fill(diagram3);
                                        dataGridView1.DataSource = diagram3;
                                        connection.Close();
                                    }

                                }
                                else
                                {
                                    using (SqlConnection connection = new SqlConnection(connectionString))
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        connection.Open();
                                        cmd.ExecuteNonQuery();

                                        RundemoHotel();
                                        RundemoGuest();
                                        RunDemoBooking();
                                        RunDemoFacilities();
                                        RunDemoRooms();

                                        connection.Close();

                                        label33.Text = $"{input}";
                                        var t = new Timer();
                                        t.Interval = sec; // it will Tick in 3 seconds
                                        t.Tick += (s, e) =>
                                        {
                                            label33.Text = "";
                                            t.Stop();
                                        };
                                        t.Start();

                                    }
                                }

                            }
                            catch (System.Data.SqlClient.SqlException)
                            {

                                label32.Text = $"{exception4.Message}";

                                var t = new Timer();
                                t.Interval = sec; // it will Tick in 3 seconds
                                t.Tick += (s, e) =>
                                {
                                    label32.Text = "";
                                    t.Stop();
                                };
                                t.Start();
                            }
                        }

                    }
                }
            }
        }

        #endregion

        #region Luk

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                textBox2.Text = string.Empty;
            }
            else
            {
                textBox2.Text = comboBox2.SelectedItem.ToString();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion


    }
}
