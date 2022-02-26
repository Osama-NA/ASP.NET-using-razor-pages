using System.ComponentModel.DataAnnotations;

namespace ASP.NET_with_razor_pages.Model
{
    /* Creating a database model Category */
    public class Category
    {
        [Key] /* Setting Id as primary key */
        public int Id { get; set; }
        [Required] /* Setting Name as a required field */
        public string Name { get; set; }
        [Display(Name="Display Order")] /* To display DisplayOrder as Display Order on UI */
        [Range(1,100, ErrorMessage ="Order not in range 1 - 100")]
        public int DisplayOrder { get; set; }
    }
}

// For more data annotations check: https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/data-annotations