using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Friends.Models
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "שם פרטי")]
        public string FirstName { get; set; } = string.Empty;
        [Display(Name = "שם משפחה")] 
        public string LastName { get; set; } = string.Empty;
        [Display(Name = "שם מלא"), NotMapped] 
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        [Display(Name = "כתובת מייל"), EmailAddress(ErrorMessage = "כתובת מייל אינה תקינה")]
        public string Email { get; set; } = string.Empty;
        [Display(Name = "טלפון"), Phone(ErrorMessage = "מספר טלפון אינו תקין")]
        public string Phone { get; set; } = string.Empty;

        [MinLength(1,ErrorMessage ="חייב להכניס תמונה")]
        public List<Image> Images { get; set; }
        [Display(Name="הוספת תמונה"), NotMapped]
        public IFormFile setImage { 
            get { return null; } 
            set { 
                if (value == null)  return; 
                AddImage(value); 
            }
         }
        public Friend()
        {
            Images = new List<Image>();
        }
        public void AddImage(IFormFile image)
        {
            MemoryStream stream = new MemoryStream();
            image.CopyTo(stream);
            AddImage(stream.ToArray());
        }
        public void AddImage(byte[] image)
        { 
            Images.Add(new Image { friend = this, myImage = image});
        }


    }
}