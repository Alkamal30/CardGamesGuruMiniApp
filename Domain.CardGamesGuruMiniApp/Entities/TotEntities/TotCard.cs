namespace Domain.CardGamesGuruMiniApp.Entities.TotEntities
{
    public class TotCard
    {
        public Guid CardId { get; set; }
        public string FirstQuestion { get; set; }
        public string SecondQuestion { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}