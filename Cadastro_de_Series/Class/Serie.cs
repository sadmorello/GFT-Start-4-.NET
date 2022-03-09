namespace Cadastro_de_Series
{
    public class Serie : Entity
    {
        private Category Category { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool D_E_L_E_T_ { get; set; }

        public Serie(int id, Category category, string title, string description, int year)
        {
            this.Id = id;
            this.Category = category;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.D_E_L_E_T_ = false;
        }

        public override string ToString()
        {
            return @$"Information
            Category: {this.Category}
            Title: {this.Title}
            Description: {this.Description}
            Year: {this.Year}";
        }
        public string returnTitle()
        {
            return this.Title;
        }
        public int returnId()
        {
            return this.Id;
        }
        public bool returnDelete()
        {
            return this.D_E_L_E_T_;
        }
        public void Delete()
        {
            this.D_E_L_E_T_ = true;
        }
    }
}