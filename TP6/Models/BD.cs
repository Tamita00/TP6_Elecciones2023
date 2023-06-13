using System.Data.SqlClient;
using Dapper;
namespace TP6;

public class BD{
    private static string ConnectionString = @"Server=localhost;DataBase=TP6;Trusted_Connection=True;";
    public static void AgregarCandidato(Candidato candidato){
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "INSERT INTO Candidato(IDCandidato, IdPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) VALUES (@pIDCandidato, @pIdPartido, @pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pPostulacion)";
            db.Execute(sql, new { pIDCandidato = candidato.IdCandidato, pIdPartido = candidato.IdPartido, pApellido =candidato.Apellido, pNombre = candidato.Nombre, pFechaNacimiento = candidato.FechaNacimiento, pFoto = candidato.Foto, pPostulacion = candidato.Postulacion });
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
        Partido infoPartido;
        
        return infoPartido;
    }
    /*VerInfoCandidato(int idCandidato): Devuelve un objeto Candidato
    ListarPartidos(): Devuelve un List de Partidos
    ListarCandidatos(int idPartido): Devuelve un List de Candidatos*/
}