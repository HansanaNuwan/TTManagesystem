﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TTManagesyst.CRUDclasses
{
    class TagsClass
    {
        //Getter and setters
        //Act as a Data carrier
        public int TagID { get; set; }
        public string TagName { get; set; }
        public string TagCode { get; set; }
        public string RelatedTag { get; set; }
       
        
        //this can be an error01
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        //selecting data from database
        public DataTable Select()
        {
            //step 1 : DB connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                //writing sql query
                string sql = "select * from ManageTag";

                //creating cmd usin sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //creating sql data adapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {

            }
            finally
            {

                conn.Close();
            }
            return dt;
        }


        //Insering data to the database
        public bool Insert(TagsClass c)
        {
            //creating default retun type and setting its value to false
            bool isSuccess = false;

            //step 1 : connect database
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //sql query to insert data
                string sql = "Insert into ManageTag (SubjectName , SubjectCode , RelatedTag) values ( @SubjectName , @SubjectCode , @RelatedTag)";
                //creating cmd usin sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //create parameters to add data
                cmd.Parameters.AddWithValue("@SubjectName", c.TagName);
                cmd.Parameters.AddWithValue("@SubjectCode", c.TagCode);
                cmd.Parameters.AddWithValue("@RelatedTag", c.RelatedTag);

                //connection open
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //if the query runs successfully then the value of rows will be greater than zero else its value will be zero
                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally 
            {
                conn.Close();
            }
            return isSuccess;
        }

        //Method to update data in database
        public bool Update(TagsClass c) 
        {
            //create a default return type and set its value to false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //sql to update data in database
                string sql = "Update ManageTag set SubjectName =@SubjectName , SubjectCode =@SubjectCode , RelatedTag=@RelatedTag where TagID =@TagID";

                //creating sql command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //create parameters to add values
                cmd.Parameters.AddWithValue("@SubjectName", c.TagName);
                cmd.Parameters.AddWithValue("@SubjectCode", c.TagCode);
                cmd.Parameters.AddWithValue("@RelatedTag", c.RelatedTag);
                cmd.Parameters.AddWithValue("TagID", c.TagID);

                //open DB connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                //if the query runs successfully then the value of rows will be greater than zero else its value will be zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally 
            {
                conn.Close();
            }
            return isSuccess;

        }

        //Method to delete data in database
        public bool Delete(TagsClass c)
        {
            //default return value and set if false
            bool isSuccess = false;
            //create sql connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //sql to delete data
                string sql = "Delete from ManageTag where TagID = @TagID";

                //creating sql command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TagID", c.TagID);

                //open connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                //if run success value will be greater than ero othrwise it will be zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else 
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally 
            {
                //close connection
                conn.Close();
            }

            return isSuccess;

        }

    }
}
