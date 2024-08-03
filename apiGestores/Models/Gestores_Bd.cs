using System.ComponentModel.DataAnnotations;

namespace apiGestores.Models
{
    public class Gestores_Bd
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public int stock { get; set; }
        public string descripcion { get; set; }


    }
}
