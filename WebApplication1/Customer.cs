using System.ComponentModel.DataAnnotations;

//Database Step 3: this class has no constructor

namespace WebApplication1 {
    public class Customer {
        // No constructor required
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string Name { get; set; }
        

    }
}