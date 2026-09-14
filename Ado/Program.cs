using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

string connectionString = "Server=(LocalDb)\\MSSQLLocalDB;Database=DbSlide;Integrated Security=True;TrustServerCertificate=True;";

//DataTable dtSections = new DataTable();

//using(SqlConnection c = new SqlConnection(connectionString))
//{
//    string q = "SELECT section_id, section_name FROM section";
//    SqlDataAdapter sqlAd = new SqlDataAdapter(q, c);
//    sqlAd.Fill(dtSections);
//}

//foreach (DataRow row in dtSections.Rows)
//{
//    int id = Convert.ToInt32(row["section_id"]);
//    string nom = row["section_name"].ToString()!;
//    Console.WriteLine($"La section id : {id} porte le nom : :{nom}");
//}


//using(SqlConnection c = new SqlConnection(connectionString))
//{
//    string q = "SELECT AVG(year_result) FROM student";
//    SqlCommand cmd = new SqlCommand(q, c);
//    c.Open();
//    object result = cmd.ExecuteScalar();
//    if(result != DBNull.Value && result != null)
//    {
//        double moyAnnStudent = Convert.ToDouble(result);
//        Console.WriteLine($"La moyenne annuelle des élèves est de : {moyAnnStudent}");
//    }
//    else
//    {
//        Console.WriteLine("Aucune donnée a calculer");
//    }
//    c.Close();
//}


//Student std = new Student()
//{
//    Id = 27,
//    Nom = "Van Oostveldt",
//    Prenom = "Benjamin",
//    DateNaiss = new DateTime(1996,7,24),
//    SectionId = 1010,
//    courseId = "EING2234"
//};

//string q = @"INSERT INTO Student(student_id, first_name, last_name, birth_date, section_id, course_id)
//             OUTPUT INSERTED.student_id
//             VALUES(@studentId, @nom,@prenom,@datenaiss,@sectionId,@courseId)";

//using(SqlConnection c = new SqlConnection(connectionString))
//{
//    using(SqlCommand cmd = new SqlCommand(q, c))
//    {
//        cmd.Parameters.AddWithValue("@studentId", std.Id);
//        cmd.Parameters.AddWithValue("@nom", std.Nom);
//        cmd.Parameters.AddWithValue("@prenom", std.Prenom);
//        cmd.Parameters.AddWithValue("@datenaiss", std.DateNaiss);
//        cmd.Parameters.AddWithValue("@sectionId", std.SectionId);
//        cmd.Parameters.AddWithValue("@courseId", std.courseId);

//        c.Open();
//        object result = cmd.ExecuteScalar();

//        if (result != DBNull.Value && result != null)
//        {
//            std.Id = Convert.ToInt32(result);
//            Console.WriteLine($"Etudiant inserer a l'Id : {std.Id} , son nom : {std.Nom}, prenom : {std.Prenom}");
//        }
//    }
//}


//public class Student
//{
//    public int Id { get; set; }
//    public string Nom { get; set; }
//    public string Prenom { get; set; }
//    public DateTime DateNaiss { get; set; }
//    public int SectionId { get; set; }
//    public string courseId { get; set; }
//}


//int monId = 26;
//int newSectionId = 1320;
//int stdId = 2;

//// 1
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    using (SqlCommand command = new SqlCommand("UpdateStudentSection", connection))
//    {
//        command.CommandType = CommandType.StoredProcedure;

//        command.Parameters.AddWithValue("@StudentId", monId);
//        command.Parameters.AddWithValue("@NewSectionId", newSectionId);

//        connection.Open();
//        int rowsAffected = command.ExecuteNonQuery();
//        Console.WriteLine($"Lignes modifiées : {rowsAffected}");
//        connection.Close();
//    }
//}

//// 2

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    using (SqlCommand command = new SqlCommand("DeleteStudentSoft", connection))
//    {
//        command.CommandType = CommandType.StoredProcedure;

//        command.Parameters.AddWithValue("@StudentId", stdId);

//        connection.Open();
//        int rowsAffected = command.ExecuteNonQuery();
//        Console.WriteLine($"Lignes modifiées : {rowsAffected}");
//        connection.Close();
//    }
//}

//// 3

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    string checkSql = "SELECT active FROM student WHERE student_id = @StudentId;";

//    using (SqlCommand command = new SqlCommand(checkSql, connection))
//    {
//        command.Parameters.AddWithValue("@StudentId", stdId);

//        connection.Open();
//        object result = command.ExecuteScalar();

//        if (result != null && result != DBNull.Value)
//        {
//            bool isActive = Convert.ToBoolean(result);
//            Console.WriteLine($" État actif du voisin (ID {stdId}) : {isActive} (Active = {(isActive ? 1 : 0)})");
//        }
//        else
//        {
//            Console.WriteLine("Étudiant introuvable.");
//        }
//    }
//}




DbProviderFactory factory = SqlClientFactory.Instance;

using (DbConnection connection = factory.CreateConnection())
{
    connection.ConnectionString = connectionString;
    connection.Open();

    using (DbCommand command = connection.CreateCommand())
    {
        command.CommandText = "SELECT Id, Name FROM Section;";

        using (DbDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine($"[Générique] ID: {reader[0]} | Nom: {reader[1]}");
            }
        }
    }
}

