﻿using System.ComponentModel.DataAnnotations;

namespace L01_2020PM608_BLOG.Models {
    public class comentarios {
        [Key]
        public int cometarioId { get; set; }
        public int publicacionId { get; set; }
        public string comentario { get; set; }
        public int usuarioId { get; set; }
    }
}
