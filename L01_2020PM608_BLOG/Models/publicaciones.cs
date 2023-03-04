using System.ComponentModel.DataAnnotations;

namespace L01_2020PM608_BLOG.Models {
    public class publicaciones {

        //publicaciones
        [Key]
        public int publicacionId { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int usuarioId { get; set; }
    }
}
