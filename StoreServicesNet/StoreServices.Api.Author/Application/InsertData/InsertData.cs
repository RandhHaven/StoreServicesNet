namespace StoreServices.Api.Author.Application.InsertData
{
    public class InsertData
    {
        public InsertData()
        {
            ExecuteData = new ExecuteData();
        }

        public ExecuteData ExecuteData { get; set; }
        HandlerData HandlerData { get; set; }
    }
}
