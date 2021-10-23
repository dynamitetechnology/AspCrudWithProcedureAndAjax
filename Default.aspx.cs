using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using Newtonsoft.Json;


namespace AspCrudWithProcedureAndAjax
{
    public partial class _Default : Page
    {

        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string addNote(string title, string note)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_insert_note", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@notes", note);
            int status  = cmd.ExecuteNonQuery();
            if(status > 0)
            {
                return "Success";
            }
            else
            {
                return "Fail";
            }
            con.Close();
        }


        [WebMethod]
        public static string UpdateNote(string title, string note, int id)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_update_note", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@notes", note);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Fail";
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return null;
        }


        [WebMethod]
        public static string deleteNote(int id)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_delete_note", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Fail";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return null;
        }


        [WebMethod]
        public static string getNote()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_select_note", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sda = cmd.ExecuteReader();

                List<Notes> notelist = new List<Notes>();
                while (sda.Read())
                {
                    Notes note = new Notes();
                    note.id = Convert.ToInt32(sda["id"]);
                    note.title = sda["title"].ToString();
                    note.notes = sda["notes"].ToString();
                    notelist.Add(note);
                }

                string json = JsonConvert.SerializeObject(notelist);

                
                return json;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return null;
        }
    }
}