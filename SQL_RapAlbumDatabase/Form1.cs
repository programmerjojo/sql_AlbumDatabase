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

namespace SQL_RapAlbumDatabase
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Owner\Documents\RapAlbum_Server1.mdf;Integrated Security = True; Connect Timeout = 30");

        public Form1()
        {
            InitializeComponent();
        }

        //to display data
        public void displayData()
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from [Albums] order by Id";
            cmd.ExecuteNonQuery();

            DataTable data = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(data);
            datagridview1.DataSource = data;

            connection.Close();
        }

        //form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            displayData();
        }


        //---------------------------------------------------------------------------


        //insert button clicked
        private void btnInsert_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "insert into [Albums] (Id, Title, Rating, Artist, FavSong) values ('" + bxID.Text + "', '" + bxTitle.Text + "', '" + bxRating.Text + "', '" + bxArtist.Text + "', '" + bxFavoriteSong.Text + "')";
            cmd.ExecuteNonQuery();
            connection.Close();

            bxID.Text = "";
            bxTitle.Text = "";
            bxArtist.Text = "";
            bxFavoriteSong.Text = "";
            bxRating.Text = "";

            displayData();
        }

        //delete button clicked
        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "delete from [Albums] where Id = '" + bxIDdelete.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();

            bxIDdelete.Text = ""; 

            displayData();
        }

        //search button clicked
        private void btnSearch_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from [Albums] where Title = '" + bxISearch.Text + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagridview1.DataSource = dt;

            connection.Close();

            bxISearch.Text = "";
        }

        //search by artist button clicked
        private void btnSearchArtist_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from [Albums] where Artist = '" + bxArtistSearch.Text + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagridview1.DataSource = dt;

            connection.Close();

            bxArtistSearch.Text = "";
        }


        //---------------------------------------------------------------------------


        //display by id button clicked
        private void btnDisplaybyID_Click(object sender, EventArgs e)
        {
            displayData();
        }

        //change rating
        private void personal_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "update [Albums] set Rating = '" + bxRatingRefer.Text + "' where Title = '" + bxTitleRefer.Text + "'";
            cmd.ExecuteNonQuery();

            connection.Close();

            bxRatingRefer.Text = "";
            bxTitleRefer.Text = "";

            displayData();
        }

        //higher than
        private void btnHigherThen_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from [Albums] where Rating >= '" + bxRatingHighRef.Text + "'";
            cmd.ExecuteNonQuery();

            connection.Close();

            bxRatingHighRef.Text = "";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagridview1.DataSource = dt;
        }

        //lower than
        private void btnLowerThen_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from [Albums] where Rating <= '" + bxRatingLowRef.Text + "'";
            cmd.ExecuteNonQuery();

            connection.Close();

            bxRatingLowRef.Text = "";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            datagridview1.DataSource = dt;
        }
    }
}