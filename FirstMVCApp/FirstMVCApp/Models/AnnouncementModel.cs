﻿using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class AnnouncementModel
    {
        [Key]
        public Guid? IdAnnouncement { get; set; }

        [Required(ErrorMessage ="Acest camp este obligatoriu!!!")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public DateTime ValidTo { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [MaxLength(250, ErrorMessage = "Campul title poate sa contina maxim 250 caractere.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(250, ErrorMessage = "Campul text poate sa contina maxim 250 caractere.")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(1000, ErrorMessage = "Campul tags poate sa contina maxim 1000 caractere.")]
        public string Tags { get; set; }
    }
}
