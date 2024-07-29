using System.ComponentModel.DataAnnotations;

namespace Friends.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public Friend friend { get; set; }
        [Display(Name = "תמונה")]
        public byte[] myImage { get; set; }
        public Image(Friend friend, byte[] img)
        {
            this.friend = friend;
            myImage = img;
        }
        public Image()
        {
            
        }
    }
}
