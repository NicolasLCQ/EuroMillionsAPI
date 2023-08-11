namespace EuroMillionsAPI.Entities
{
    public class Draw : BaseEntity
    {
        public override int ID { get; set; }
        public DateTime DrawDate { get; set; }
        public string Day {  get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public int Number4 { get; set; }
        public int Number5 { get; set; }
        public int Star1 { get; set; }
        public int Star2 { get; set; }
    }
}
