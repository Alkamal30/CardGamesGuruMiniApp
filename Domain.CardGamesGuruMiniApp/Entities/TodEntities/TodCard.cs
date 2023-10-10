namespace Domain.CardGamesGuruMiniApp.Entities.TodEntities
{
    public class TodCard
    {
        public Guid CardId { get; set; }
        public string Truth { get; set; }
        public string Dare { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}