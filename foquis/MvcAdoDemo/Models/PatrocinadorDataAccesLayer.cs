using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks; 

namespace MVCAdoDemo.Models {   
    public class EmployeeDataAccessLayer  {   
        string connectionString = "Your Connection String here";
        //To View all Patrocinador details
            public IEnumerable<Patrocinador> GetAllpateocinador() {  
                List<Patrocinador> lstpatrocinador = new List<Patrocinador>(); 
                using (SqlConnection con = new SqlConnection(connectionString))
                { SqlCommand cmd = new SqlCommand("spGetAllPatrocinador", con);
                cmd.CommandType = CommandType.StoredProcedure;   
                con.Open(); 
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {  mployee patrocinador = new Patrocinador(); 
                patrocinador.Run = Convert.ToInt32(rdr["Run"]);  
                patrocinador.Name = rdr["Name"].ToString();
                patrocinador.Appellido = rdr["Appellido"].ToString();  
                patrocinador.Telefono = rdr["Telefono"].ToString(); 
                patrocinador.Region = rdr["Region"].ToString(); 
                patrocinador.Comuna = rdr["Comuna"].ToString();
                patrocinador.Apoyo = rdr["Apoyo"].ToString();
                lstpatrocinador.Add(patrocinador); } con.Close(); } return lstpatrocinador;} 
        //To Add new Patrocinador record
            public void AddPatrocinador(Patrocinador patrocinador) { 
                using (SqlConnection con = new SqlConnection(connectionString)) 
                { SqlCommand cmd = new SqlCommand("spAddPatrocinador", con); 
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("@Name", patrocinador.Name);   
                cmd.Parameters.AddWithValue("@Appellido", patrocinador.Appellido); 
                cmd.Parameters.AddWithValue("@Telefono", patrocinador.Telefono); 
                cmd.Parameters.AddWithValue("@Region", patrocinador.Region); 
                cmd.Parameters.AddWithValue("@Comuna", patrocinador.Comuna); 
                cmd.Parameters.AddWithValue("@Apoyo", patrocinador.Apoyo);  
                con.Open();
                cmd.ExecuteNonQuery();  
                con.Close(); }  }
        //To Update the records of a particluar Patrocinador 
            public void UpdatePatrocinador(Patrocinador patrocinador) { 
                using (SqlConnection con = new SqlConnection(connectionString)) 
                { SqlCommand cmd = new SqlCommand("spUpdatePatrocinador", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rut", patrocinador.Run); 
                cmd.Parameters.AddWithValue("@Name", patrocinador.Name); 
                cmd.Parameters.AddWithValue("@Appellido", patrocinador.Appaellido);  
                cmd.Parameters.AddWithValue("@Telefono", patrocinador.Telefono); 
                cmd.Parameters.AddWithValue("@Region", patrocinador.Region);
                cmd.Parameters.AddWithValue("@Comuna", patrocinador.Comuna);
                cmd.Parameters.AddWithValue("@Apoyo", patrocinador.Apoyo);   
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close(); } }  
        //Get the details of a particular Patrocinador  
            public Patrocinador GetPatrocinadorData(int? id) {  
                Patrocinador patrocinador = new Patrocinador();
                using (SqlConnection con = new SqlConnection(connectionString)) 
                { string sqlQuery = "SELECT * FROM tblPatrocinador WHERE Rut= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open(); 
                SqlDataReader rdr = cmd.ExecuteReader();  
                while (rdr.Read())  { patrocinador.Run = Convert.ToInt32(rdr["Rut"]);
                patrocinador.Name = rdr["Name"].ToString(); 
                patrocinador.Appellido = rdr["Appellido"].ToString();
                patrocinador.Telefono = rdr["Telefono"].ToString();   
                patrocinador.Region = rdr["Region"].ToString();
                patrocinador.Comuna = rdr["Comuna"].ToString();
                patrocinador.Apoyo = rdr["Apoyo"].ToString(); }  } return patrocinador; } 
        //To Delete the record on a particular Patrocinador  
            public void DeleteEmployee(int? id){ 
                using (SqlConnection con = new SqlConnection(connectionString)) 
                {  SqlCommand cmd = new SqlCommand("spDeleteEmployee", con); 
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("@EmpId", id);
                con.Open();  
                cmd.ExecuteNonQuery();  
                con.Close(); }  }  }  }
            