using System;
using System.ComponentModel.DataAnnotations;

namespace HighFlyerCompanion.Data
{
    /// <summary>
    /// Data for validate a mission form 
    /// </summary>
    public class MissionSubmit
    {
        [Display(Name = "Commentary")]
        public string Commentary { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "Building's name too long (16 character limit).")]
        [Display(Name = "Building's name")]
        public string BuildingName { get; set; }

        [Display(Name = "Face's orirentation")]
        public FaceOrientation Face { get; set; }
    }
}