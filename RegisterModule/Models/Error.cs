namespace RegisterModule.Models
{
    public class Error
    {
        public int? StatusCode { get; set; }
        public string? Source { get; set; }
        public string? ErrorMessage { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;

        public string? StackTrace { get; set; }

        public string GetErrorDetails()
        {
            string details = $"StatusCode : {this.StatusCode},\nSource : {this.Source}\nErrorMessage : {this.ErrorMessage}\nDateTime : {this.DateTime}\nStackTrace : {this.StackTrace}\n\n";
            return details;
        }
    }
}
