using System.Data.SqlClient;
using Dapper;
namespace TP6;

public class BD{
    private static string ConnectionString = @"Server=localhost;DataBase=TP6;Trusted_Connection=True;";
    public static void AgregarCandidato(Candidato candidato){
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "INSERT INTO Candidato(IDCandidato, IdPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) VALUES (@pIDCandidato, @pIdPartido, @pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pPostulacion)";
            db.Execute(sql, new { pIDCandidato = candidato.IdCandidato, pIdPartido = candidato.IdPartido, pApellido = candidato.Apellido, pNombre = candidato.Nombre, pFechaNacimiento = candidato.FechaNacimiento, pFoto = candidato.Foto, pPostulacion = candidato.Postulacion });
        }    
    }
    public static void EliminarCandidato(int idCandidato){
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "DELETE FROM Candidato WHERE idCandidato = @pidCandidato";
            db.Execute(sql, new { pidCandidato = idCandidato });
        }
    }
    public static Partido VerInfoPartido(int idPartido){
        Partido partido = null;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Partido WHERE IdPartido = @pIdPartido";
            partido = db.QueryFirstOrDefault<Partido>(sql, new { pIdPartido = idPartido});
        }
        return partido;
    }
    public static Candidato VerInfoCandidato(int idCandidato){
        Candidato candidato = null;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Candidato WHERE IdCandidato = @pIdCandidato";
            candidato = db.QueryFirstOrDefault<Candidato>(sql, new { pIdCandidato = idCandidato});
        }
        return candidato;
    }
    public static List<Partido> ListarPartidos(){
        List <Partido> listaPartidos = new List<Partido>();
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Partido";
            listaPartidos = db.Query<Partido>(sql).ToList();
        }
        return listaPartidos;
    }
    public static List<Candidato> ListarCandidatos(int IdPartido){
        List <Candidato> listaCandidatos = new List<Candidato>();
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Candidato WHERE IdPartido = @IdPartido";
            listaCandidatos = db.Query<Candidato>(sql, new {IdPartido = IdPartido}).ToList();
        }
        return listaCandidatos;
    }
}