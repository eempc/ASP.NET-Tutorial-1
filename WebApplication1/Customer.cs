using System.ComponentModel.DataAnnotations;

//Database Step 3: this class has no constructor

namespace WebApplication1 {
    public class Customer {
        // No constructor required, set the parameters of the customer class, i.e. ID number and name

        public int Id { get; set; }

        [Required, StringLength(49)] //Use validation
        public string Name { get; set; }
        

    }
}